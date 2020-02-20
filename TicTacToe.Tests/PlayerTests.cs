using System;
using Xunit;
using Xunit.Abstractions;

namespace TicTacToe.Tests
{
    public class PlayerTests
    {
        Player player = new Player("player");

        [Fact]
        public void CanCreateNewPlayer() => Assert.IsType<Player>(player);

        [Fact]
        public void PlayerHasName()
        {
            var name = "Matt";
            player.Name = name;
            Assert.Equal(name, player.Name);
        }

        [Fact]
        public void PlayerHasMarker()
        {
            char marker = 'X';
            player.Marker = marker;
            Assert.Equal(marker, player.Marker);
        }
    }
}