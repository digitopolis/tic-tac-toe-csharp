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

        [Fact]
        public void GameHasTwoPlayers()
        {
            Player player1 = new Player("first", 'X');
            Player player2 = new Player("second", 'O');
            game.Player1 = player1;
            game.Player2 = player2;

            Assert.Equal("first", game.Player1.Name);
            Assert.Equal("second", game.Player2.Name);
        }
    }
}
