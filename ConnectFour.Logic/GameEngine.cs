namespace ConnectFour.Logic
{
    /// <summary>
    /// Главный класс игровой логики.
    /// Управляет ходами, сменой игроков и определением победителя.
    /// </summary>
    public class GameEngine
    {
        private readonly WinChecker _winChecker = new();

        public GameBoard Board { get; }
        public Player Player1 { get; }
        public Player Player2 { get; }
        public Player CurrentPlayer { get; private set; }
        public GameStatus Status { get; private set; }
        public WinResult? LastWinResult { get; private set; }
        public int MoveCount { get; private set; }

        /// <summary>Вызывается после каждого хода.</summary>
        public event EventHandler<MoveResult>? MoveMade;
        /// <summary>Вызывается при изменении статуса игры.</summary>
        public event EventHandler<GameStatus>? StatusChanged;

        public GameEngine(Player player1, Player player2)
        {
            ArgumentNullException.ThrowIfNull(player1);
            ArgumentNullException.ThrowIfNull(player2);

            if (player1.Color == player2.Color)
                throw new ArgumentException("Игроки должны иметь разные цвета фишек.");

            Player1 = player1;
            Player2 = player2;
            Board = new GameBoard();
            CurrentPlayer = Player1;
            Status = GameStatus.NotStarted;
        }

        /// <summary>Запускает (или перезапускает) игру.</summary>
        public void Start()
        {
            Board.Reset();
            CurrentPlayer = Player1;
            Status = GameStatus.InProgress;
            LastWinResult = null;
            MoveCount = 0;
            StatusChanged?.Invoke(this, Status);
        }

        /// <summary>
        /// Выполняет ход текущего игрока в указанный столбец.
        /// Возвращает MoveResult с описанием результата.
        /// </summary>
        public MoveResult MakeMove(int column)
        {
            if (Status != GameStatus.InProgress)
            {
                var err = MoveResult.Fail("Игра не идёт.");
                MoveMade?.Invoke(this, err);
                return err;
            }

            if (column < 0 || column >= GameBoard.Columns)
            {
                var err = MoveResult.Fail($"Столбец {column} вне диапазона.");
                MoveMade?.Invoke(this, err);
                return err;
            }

            if (!Board.IsColumnAvailable(column))
            {
                var err = MoveResult.Fail("Этот столбец заполнен. Выберите другой.");
                MoveMade?.Invoke(this, err);
                return err;
            }

            int row = Board.DropDisc(column, CurrentPlayer.Id);
            MoveCount++;

            var winResult = _winChecker.CheckWin(Board, row, column, CurrentPlayer.Id);

            GameStatus newStatus;
            if (winResult != null)
            {
                newStatus = GameStatus.Won;
                LastWinResult = winResult;
                CurrentPlayer.Wins++;
            }
            else if (Board.IsFull())
            {
                newStatus = GameStatus.Draw;
            }
            else
            {
                newStatus = GameStatus.InProgress;
            }

            Status = newStatus;

            var result = new MoveResult
            {
                Success = true,
                LandedRow = row,
                LandedCol = column,
                Status = newStatus,
                WinResult = winResult
            };

            MoveMade?.Invoke(this, result);

            if (newStatus != GameStatus.InProgress)
                StatusChanged?.Invoke(this, newStatus);
            else
                SwitchPlayer();

            return result;
        }

        /// <summary>Возвращает игрока по его ID (1 или 2).</summary>
        public Player GetPlayerById(int id) => id == 1 ? Player1 : Player2;

        private void SwitchPlayer() =>
            CurrentPlayer = CurrentPlayer == Player1 ? Player2 : Player1;
    }
}
