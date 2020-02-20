using System;
using Xunit;
using Xunit.Abstractions;

namespace TicTacToe.Tests
{
    public class PlayerTests
    {
        [Fact]
        public void CanCreateNewPlayer(){
            Player player = new Player("player");
        }

        [Fact]
        public void PlayerHasName(){
            var name = "Matt";
            Player player = new Player(name);
            Console.WriteLine(player.Name);
        }
    }
}