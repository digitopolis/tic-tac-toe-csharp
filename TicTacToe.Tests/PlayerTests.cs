using System;
using Xunit;
using Xunit.Abstractions;

namespace TicTacToe.Tests
{
    public class PlayerTests
    {
        static string name = "Matt";
        static string marker = "X";
        Player player = new Player(name, marker);

        [Fact]
        public void CanCreateNewPlayer() => Assert.IsType<Player>(player);

        [Fact]
        public void PlayerHasName() => Assert.Equal(name, player.Name);

        [Fact]
        public void PlayerHasMarker() => Assert.Equal(marker, player.Marker);
    }
}