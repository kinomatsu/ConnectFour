using System;

namespace ConnectFour.Logic
{
    /// <summary>
    /// Игровое поле 7×6.
    /// Значения ячеек: 0 — пусто, 1 — Игрок 1, 2 — Игрок 2.
    /// </summary>
    public class GameBoard
    {
        public const int Rows = 6;
        public const int Columns = 7;

        private readonly int[,] _cells;

        public GameBoard()
        {
            _cells = new int[Rows, Columns];
        }

        /// <summary>Возвращает значение ячейки.</summary>
        public int GetCell(int row, int col)
        {
            ValidateCoords(row, col);
            return _cells[row, col];
        }

        /// <summary>
        /// Бросает фишку в указанный столбец.
        /// Возвращает строку, в которую упала фишка, или -1 если столбец полон.
        /// </summary>
        public int DropDisc(int column, int playerId)
        {
            for (int row = Rows - 1; row >= 0; row--)
            {
                if (_cells[row, column] == 0)
                {
                    _cells[row, column] = playerId;
                    return row;
                }
            }
            return -1; // столбец полон
        }

        /// <summary>Возвращает true, если в столбце есть свободные ячейки.</summary>
        public bool IsColumnAvailable(int column)
        {
            if (column < 0 || column >= Columns)
                throw new ArgumentOutOfRangeException(nameof(column));
            return _cells[0, column] == 0;
        }

        /// <summary>Возвращает true, если всё поле заполнено.</summary>
        public bool IsFull()
        {
            for (int col = 0; col < Columns; col++)
                if (_cells[0, col] == 0) return false;
            return true;
        }

        /// <summary>Сбрасывает поле в начальное состояние.</summary>
        public void Reset() => Array.Clear(_cells, 0, _cells.Length);

        /// <summary>Возвращает копию поля (снимок состояния).</summary>
        public int[,] GetSnapshot()
        {
            var snap = new int[Rows, Columns];
            Array.Copy(_cells, snap, _cells.Length);
            return snap;
        }

        private static void ValidateCoords(int row, int col)
        {
            if (row < 0 || row >= Rows)
                throw new ArgumentOutOfRangeException(nameof(row));
            if (col < 0 || col >= Columns)
                throw new ArgumentOutOfRangeException(nameof(col));
        }
    }
}
