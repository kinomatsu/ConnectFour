using ConnectFour.Logic;
using Xunit;

namespace ConnectFour.Tests
{
    public class WinCheckerTests
    {
        private static (GameBoard board, int row) DropN(int col, int playerId, int count, GameBoard? b = null)
        {
            b ??= new GameBoard();
            int row = -1;
            for (int i = 0; i < count; i++)
                row = b.DropDisc(col, playerId);
            return (b, row);
        }

        [Fact]
        public void Horizontal_Win_Detected()
        {
            var board = new GameBoard();
            int row = -1;
            for (int c = 0; c < 4; c++)
                row = board.DropDisc(c, 1);

            var checker = new WinChecker();
            var result  = checker.CheckWin(board, row, 3, 1);

            Assert.NotNull(result);
            Assert.Equal(1, result!.WinnerId);
            Assert.Equal(4, result.WinningCells.Count);
        }

        [Fact]
        public void Vertical_Win_Detected()
        {
            var board = new GameBoard();
            int row = -1;
            for (int i = 0; i < 4; i++)
                row = board.DropDisc(0, 1);

            var checker = new WinChecker();
            var result  = checker.CheckWin(board, row, 0, 1);

            Assert.NotNull(result);
            Assert.Equal(4, result!.WinningCells.Count);
        }

        [Fact]
        public void Diagonal_Backslash_Win_Detected()
        {
            // Строим диагональ \ : (5,0),(4,1),(3,2),(2,3)
            var board = new GameBoard();
            // col 0: 1 фишка игрока 1
            board.DropDisc(0, 1);
            // col 1: 1 балласт + 1 игрок 1
            board.DropDisc(1, 2);
            board.DropDisc(1, 1);
            // col 2: 2 балласта + 1 игрок 1
            board.DropDisc(2, 2);
            board.DropDisc(2, 2);
            board.DropDisc(2, 1);
            // col 3: 3 балласта + 1 игрок 1
            board.DropDisc(3, 2);
            board.DropDisc(3, 2);
            board.DropDisc(3, 2);
            int row = board.DropDisc(3, 1);

            var checker = new WinChecker();
            var result  = checker.CheckWin(board, row, 3, 1);

            Assert.NotNull(result);
            Assert.Equal(4, result!.WinningCells.Count);
        }

        [Fact]
        public void Diagonal_Slash_Win_Detected()
        {
            // Строим диагональ / : (5,3),(4,2),(3,1),(2,0)
            var board = new GameBoard();
            // col 3: 1 фишка игрока 1
            board.DropDisc(3, 1);
            // col 2: 1 балласт + 1 игрок 1
            board.DropDisc(2, 2);
            board.DropDisc(2, 1);
            // col 1: 2 балласта + 1 игрок 1
            board.DropDisc(1, 2);
            board.DropDisc(1, 2);
            board.DropDisc(1, 1);
            // col 0: 3 балласта + 1 игрок 1
            board.DropDisc(0, 2);
            board.DropDisc(0, 2);
            board.DropDisc(0, 2);
            int row = board.DropDisc(0, 1);

            var checker = new WinChecker();
            var result  = checker.CheckWin(board, row, 0, 1);

            Assert.NotNull(result);
            Assert.Equal(4, result!.WinningCells.Count);
        }

        [Fact]
        public void NoWin_ReturnsNull()
        {
            var board = new GameBoard();
            board.DropDisc(0, 1);
            board.DropDisc(1, 1);
            board.DropDisc(2, 1);

            var checker = new WinChecker();
            var result  = checker.CheckWin(board, GameBoard.Rows - 1, 2, 1);

            Assert.Null(result);
        }

        [Fact]
        public void Win_DoesNotCountOpponentDiscs()
        {
            var board = new GameBoard();
            board.DropDisc(0, 1);
            board.DropDisc(1, 2); // чужая фишка разрывает линию
            board.DropDisc(2, 1);
            int row = board.DropDisc(3, 1);

            var checker = new WinChecker();
            var result  = checker.CheckWin(board, row, 3, 1);

            Assert.Null(result);
        }
    }
}
