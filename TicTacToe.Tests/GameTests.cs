using System;
using Xunit;
using Xunit.Abstractions;

namespace TicTacToe.Tests
{
    public class GameTests
    {
        [Fact]
        public void CanCreateNewGame()
        {
            Game game = new Game();
        }

        public void GameHasABoard()
        {
            Game game = new Game();
        }
    }
}
