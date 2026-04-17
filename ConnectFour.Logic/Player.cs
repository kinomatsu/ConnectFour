namespace ConnectFour.Logic
{
    /// <summary>Представляет одного из двух игроков.</summary>
    public class Player
    {
        public int Id { get; }
        public string Name { get; }
        public PlayerColor Color { get; }
        public int Wins { get; set; }

        public Player(int id, string name, PlayerColor color)
        {
            if (id != 1 && id != 2)
                throw new ArgumentOutOfRangeException(nameof(id), "ID игрока должен быть 1 или 2.");
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Имя игрока не может быть пустым.", nameof(name));

            Id = id;
            Name = name;
            Color = color;
            Wins = 0;
        }

        public override string ToString() => $"{Name} ({Color})";
    }
}
