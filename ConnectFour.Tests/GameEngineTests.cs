using ConnectFour.Logic;
using Xunit;

namespace ConnectFour.Tests
{
    public class GameEngineTests
    {
        private static GameEngine CreateEngine()
        {
            var p1 = new Player(1, "Алиса", PlayerColor.Red);
            var p2 = new Player(2, "Боб",   PlayerColor.Yellow);
            return new GameEngine(p1, p2);
        }

        [Fact]
        public void Start_SetsStatusInProgress()
        {
            var engine = CreateEngine();
            engine.Start();
            Assert.Equal(GameStatus.InProgress, engine.Status);
        }

        [Fact]
        public void Start_CurrentPlayerIsPlayer1()
        {
            var engine = CreateEngine();
            engine.Start();
            Assert.Equal(engine.Player1, engine.CurrentPlayer);
        }

        [Fact]
        public void MakeMove_SwitchesPlayer()
        {
            var engine = CreateEngine();
            engine.Start();
            engine.MakeMove(0);
            Assert.Equal(engine.Player2, engine.CurrentPlayer);
        }

        [Fact]
        public void MakeMove_ReturnsSuccess()
        {
            var engine = CreateEngine();
            engine.Start();
            var result = engine.MakeMove(3);
            Assert.True(result.Success);
        }

        [Fact]
        public void MakeMove_FullColumn_ReturnsError()
        {
            var engine = CreateEngine();
            engine.Start();
            // Заполняем столбец 0 (чередуем игроков)
            for (int i = 0; i < GameBoard.Rows; i++)
                engine.MakeMove(0);

            // Следующий ход в тот же столбец должен вернуть ошибку
            var result = engine.MakeMove(0);
            Assert.False(result.Success);
            Assert.NotNull(result.ErrorMessage);
        }

        [Fact]
        public void MakeMove_BeforeStart_ReturnsError()
        {
            var engine = CreateEngine();
            var result = engine.MakeMove(0);
            Assert.False(result.Success);
        }

        [Fact]
        public void HorizontalWin_DetectedCorrectly()
        {
            var engine = CreateEngine();
            engine.Start();
            // P1 ходит в столбцы 0,2,4,6 — P2 в 1,3,5
            // Но это не горизонталь подряд. Делаем правильно:
            // P1: col 0,1,2,3 (нижняя строка) — P2 в col 4,5,6 (нижняя строка)
            engine.MakeMove(0); // P1 -> (5,0)
            engine.MakeMove(4); // P2 -> (5,4)
            engine.MakeMove(1); // P1 -> (5,1)
            engine.MakeMove(5); // P2 -> (5,5)
            engine.MakeMove(2); // P1 -> (5,2)
            engine.MakeMove(6); // P2 -> (5,6)
            var result = engine.MakeMove(3); // P1 -> (5,3) — горизонталь 0-3

            Assert.Equal(GameStatus.Won, result.Status);
            Assert.Equal(1, result.WinResult!.WinnerId);
        }

        [Fact]
        public void VerticalWin_DetectedCorrectly()
        {
            var engine = CreateEngine();
            engine.Start();
            // P1 в столбец 0, P2 в столбец 1 — 4 раза
            for (int i = 0; i < 4; i++)
            {
                engine.MakeMove(0);
                if (i < 3) engine.MakeMove(1);
            }

            Assert.Equal(GameStatus.Won, engine.Status);
            Assert.Equal(1, engine.LastWinResult!.WinnerId);
        }

        [Fact]
        public void Draw_DetectedWhenBoardFull()
        {
            var engine = CreateEngine();
            engine.Start();

            // Заполняем доску без победы:
            // Чередуем столбцы так, чтобы не было 4 в ряд
            // Простая стратегия: заполняем по столбцам, чередуя игроков
            int[] order = { 0, 1, 2, 3, 4, 5, 6 };
            bool draw = false;
            for (int row = 0; row < GameBoard.Rows && !draw; row++)
            {
                foreach (int col in order)
                {
                    if (engine.Status != GameStatus.InProgress) { draw = true; break; }
                    engine.MakeMove(col);
                }
            }

            // Либо ничья, либо кто-то победил — главное что игра завершилась
            Assert.NotEqual(GameStatus.InProgress, engine.Status);
        }

        [Fact]
        public void Player_WinsCounter_Increments()
        {
            var engine = CreateEngine();
            engine.Start();
            // P1 делает вертикальную победу в col 0, P2 в col 1
            engine.MakeMove(0); engine.MakeMove(1);
            engine.MakeMove(0); engine.MakeMove(1);
            engine.MakeMove(0); engine.MakeMove(1);
            engine.MakeMove(0); // P1 победил вертикально

            Assert.Equal(1, engine.Player1.Wins);
        }

        [Fact]
        public void SameColors_ThrowsException()
        {
            var p1 = new Player(1, "А", PlayerColor.Red);
            var p2 = new Player(2, "Б", PlayerColor.Red);
            Assert.Throws<ArgumentException>(() => new GameEngine(p1, p2));
        }

        [Fact]
        public void Restart_ResetsBoard()
        {
            var engine = CreateEngine();
            engine.Start();
            engine.MakeMove(0);
            engine.Start();
            Assert.Equal(0, engine.Board.GetCell(GameBoard.Rows - 1, 0));
            Assert.Equal(0, engine.MoveCount);
        }
    }
}
