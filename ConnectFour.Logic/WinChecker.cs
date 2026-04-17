namespace ConnectFour.Logic
{
    /// <summary>
    /// Проверяет условия победы после каждого хода.
    /// Проверяет горизонталь, вертикаль и обе диагонали.
    /// </summary>
    public class WinChecker
    {
        private const int WinLength = 4;

        // Направления: горизонталь, вертикаль, диагональ \, диагональ /
        private static readonly (int dr, int dc)[] Directions =
        [
            (0,  1),
            (1,  0),
            (1,  1),
            (1, -1)
        ];

        /// <summary>
        /// Проверяет, создал ли последний ход (row, col) выигрышную линию.
        /// Возвращает WinResult или null.
        /// </summary>
        public WinResult? CheckWin(GameBoard board, int row, int col, int playerId)
        {
            var snap = board.GetSnapshot();

            foreach (var (dr, dc) in Directions)
            {
                var line = BuildLine(snap, row, col, dr, dc, playerId);
                if (line.Count >= WinLength)
                    return new WinResult(playerId, line);
            }
            return null;
        }

        private static List<(int Row, int Col)> BuildLine(
            int[,] snap, int row, int col,
            int dr, int dc, int playerId)
        {
            var line = new List<(int, int)> { (row, col) };
            Extend(snap, row, col, dr, dc, playerId, line);
            Extend(snap, row, col, -dr, -dc, playerId, line);
            return line;
        }

        private static void Extend(
            int[,] snap, int r0, int c0,
            int dr, int dc, int playerId,
            List<(int, int)> line)
        {
            int r = r0 + dr;
            int c = c0 + dc;
            while (r >= 0 && r < GameBoard.Rows &&
                   c >= 0 && c < GameBoard.Columns &&
                   snap[r, c] == playerId)
            {
                line.Add((r, c));
                r += dr;
                c += dc;
            }
        }
    }
}
