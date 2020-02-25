using System;
using Xunit;
using Xunit.Abstractions;

namespace TicTacToe.Tests
{
    public class GameTests
    {
        static Game game = new Game();
        Player player1 = new Player("first", game.Player1Marker);
        Player player2 = new Player("second", game.Player2Marker);

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
            Assert.Equal(game.Player1Marker, game.Board[1]);
        }

        [Fact]
        public void GameCanAddPlayersWithNames()
        {
            game.AddPlayers(new FakeUserInput());
            Assert.Equal("player 1 name", game.Player1.Name);
        }

        [Fact]
        public void GameCanGetPlayerMove()
        {
            int move = game.NextPlayerMove(new FakeUserInput(), player1);
            Assert.Equal(4, move);
        }
    }
}
