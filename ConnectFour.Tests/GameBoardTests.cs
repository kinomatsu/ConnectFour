using ConnectFour.Logic;
using Xunit;

namespace ConnectFour.Tests
{
    public class GameBoardTests
    {
        [Fact]
        public void NewBoard_AllCellsEmpty()
        {
            var board = new GameBoard();
            for (int r = 0; r < GameBoard.Rows; r++)
                for (int c = 0; c < GameBoard.Columns; c++)
                    Assert.Equal(0, board.GetCell(r, c));
        }

        [Fact]
        public void DropDisc_LandsOnBottomRow()
        {
            var board = new GameBoard();
            int row = board.DropDisc(3, 1);
            Assert.Equal(GameBoard.Rows - 1, row);
            Assert.Equal(1, board.GetCell(row, 3));
        }

        [Fact]
        public void DropDisc_StacksCorrectly()
        {
            var board = new GameBoard();
            board.DropDisc(0, 1);
            int row2 = board.DropDisc(0, 2);
            Assert.Equal(GameBoard.Rows - 2, row2);
        }

        [Fact]
        public void DropDisc_ReturnsMinusOne_WhenColumnFull()
        {
            var board = new GameBoard();
            for (int i = 0; i < GameBoard.Rows; i++)
                board.DropDisc(0, 1);
            int result = board.DropDisc(0, 2);
            Assert.Equal(-1, result);
        }

        [Fact]
        public void IsColumnAvailable_FalseWhenFull()
        {
            var board = new GameBoard();
            for (int i = 0; i < GameBoard.Rows; i++)
                board.DropDisc(2, 1);
            Assert.False(board.IsColumnAvailable(2));
        }

        [Fact]
        public void IsFull_TrueWhenAllFilled()
        {
            var board = new GameBoard();
            for (int c = 0; c < GameBoard.Columns; c++)
                for (int r = 0; r < GameBoard.Rows; r++)
                    board.DropDisc(c, 1);
            Assert.True(board.IsFull());
        }

        [Fact]
        public void Reset_ClearsBoard()
        {
            var board = new GameBoard();
            board.DropDisc(0, 1);
            board.Reset();
            Assert.Equal(0, board.GetCell(GameBoard.Rows - 1, 0));
        }

        [Fact]
        public void GetSnapshot_IsIndependentCopy()
        {
            var board = new GameBoard();
            board.DropDisc(0, 1);
            var snap = board.GetSnapshot();
            board.Reset();
            // Снимок не должен измениться
            Assert.Equal(1, snap[GameBoard.Rows - 1, 0]);
        }
    }
}
