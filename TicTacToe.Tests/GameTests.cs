using System;
using Xunit;
using Xunit.Abstractions;

namespace TicTacToe.Tests
{
    public class GameTests
    {
        Game game = new Game();
        Player player1 = new Player("first", 'X');
        Player player2 = new Player("second", 'O');

        [Fact]
        public void CanCreateNewGame() => Assert.IsType<Game>(game);

        [Fact]
        public void GameHasABoard() => Assert.IsType<Char[]>(game.Board);

        [Fact]
        public void GameBoardHasNineSpaces() => Assert.Equal(9, game.Board.Length);

        [Fact]
        public void GameHasTwoPlayers()
        {
            game.Player1 = player1;
            game.Player2 = player2;

            Assert.Equal("first", game.Player1.Name);
            Assert.Equal("second", game.Player2.Name);
        }

        // Add test for Game.MakeMove()
        [Fact]
        public void GameCanMakeMoveOnBoard()
        {
        //Given a player has joined a game
            game.Player1 = player1;
        //When player picks a valid space
            game.MakeMove(2, game.Player1.Marker);
        //Then Board is updated with player's marker
            Assert.Equal('X', game.Board[1]);
        }

        [Fact]
        public void GameCanAddPlayersWithNames()
        {
            game.AddPlayers(new FakeUserInput());
            Assert.Equal("player 1 name", game.Player1.Name);
        }
    }
}
