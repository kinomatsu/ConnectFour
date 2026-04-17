namespace ConnectFour.Logic
{
    /// <summary>Результат попытки сделать ход.</summary>
    public class MoveResult
    {
        public bool Success { get; init; }
        public int LandedRow { get; init; }
        public int LandedCol { get; init; }
        public GameStatus Status { get; init; }
        public WinResult? WinResult { get; init; }
        public string? ErrorMessage { get; init; }

        public static MoveResult Fail(string message) => new()
        {
            Success = false,
            ErrorMessage = message,
            Status = GameStatus.InProgress
        };
    }
}
