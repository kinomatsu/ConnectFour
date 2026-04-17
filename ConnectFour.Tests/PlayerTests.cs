using ConnectFour.Logic;
using Xunit;

namespace ConnectFour.Tests
{
    public class PlayerTests
    {
        [Fact]
        public void Player_CreatedWithCorrectProperties()
        {
            var p = new Player(1, "Алиса", PlayerColor.Red);
            Assert.Equal(1, p.Id);
            Assert.Equal("Алиса", p.Name);
            Assert.Equal(PlayerColor.Red, p.Color);
            Assert.Equal(0, p.Wins);
        }

        [Fact]
        public void Player_EmptyName_ThrowsException()
        {
            Assert.Throws<ArgumentException>(() => new Player(1, "", PlayerColor.Red));
            Assert.Throws<ArgumentException>(() => new Player(1, "   ", PlayerColor.Red));
        }

        [Fact]
        public void Player_InvalidId_ThrowsException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new Player(0, "Тест", PlayerColor.Red));
            Assert.Throws<ArgumentOutOfRangeException>(() => new Player(3, "Тест", PlayerColor.Red));
        }

        [Fact]
        public void Player_WinsCanBeIncremented()
        {
            var p = new Player(1, "Боб", PlayerColor.Yellow);
            p.Wins++;
            Assert.Equal(1, p.Wins);
        }
    }
}
