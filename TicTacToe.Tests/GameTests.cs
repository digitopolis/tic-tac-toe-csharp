using System;
using Xunit;
using Xunit.Abstractions;

namespace TicTacToe.Tests
{
    public class GameTests
    {
        Game game = new Game();

        [Fact]
        public void CanCreateNewGame() => Assert.IsType<Game>(game);

        [Fact]
        public void GameHasABoard() => Assert.IsType<String[]>(game.Board);

        [Fact]
        public void GameBoardHasNineSpaces() => Assert.Equal(9, game.Board.Length);
    }
}
