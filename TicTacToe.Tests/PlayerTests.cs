using System;
using Xunit;
using Xunit.Abstractions;

namespace TicTacToe.Tests
{
    public class PlayerTests
    {
        [Fact]
        public void CanCreateNewPlayer(){
            Player player = new Player;
        }
    }
}