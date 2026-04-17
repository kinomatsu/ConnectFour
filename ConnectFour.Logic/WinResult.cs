namespace ConnectFour.Logic
{
    /// <summary>Результат проверки победы: победитель и выигрышные ячейки.</summary>
    public class WinResult
    {
        public int WinnerId { get; }
        public IReadOnlyList<(int Row, int Col)> WinningCells { get; }

        public WinResult(int winnerId, IEnumerable<(int Row, int Col)> cells)
        {
            WinnerId = winnerId;
            WinningCells = cells.ToList().AsReadOnly();
        }
    }
}
