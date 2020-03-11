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
        public void GameHasABoard() => Assert.IsType<Board>(game.Board);

        // [Fact]
        // public void GameBoardHasNineSpaces() => Assert.Equal(9, game.Board.Length);

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
            game.Board = new Board(3);
        //Given a player has joined a game
            game.Player1 = player1;
            game.CurrentPlayer = player1;
        //When player picks a valid space
            game.MakeMove(2);
        //Then Board is updated with player's marker
            Assert.Equal(game.Player1Marker, game.Board.gameBoard[1]);
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
            int move = game.NextPlayerMove(new FakeUserInput());
            Assert.Equal(4, move);
        }

        // [Fact]
        // public void GameCanCheckMoveAvailability()
        // {
        //     game.Board = new string[] { 'X', '2', 'O', 'O', '5', '6', 'X', '8', '9' };
        //     Assert.True(game.SpaceIsAvailable(2));
        //     Assert.False(game.SpaceIsAvailable(3));
        // }

        [Fact]
        public void GameCanAlternatePlayers()
        {
            game.Player1 = player1;
            game.Player2 = player2;
            game.CurrentPlayer = player1;

            Assert.Equal(player1, game.CurrentPlayer);
            game.SwitchCurrentPlayer();
            Assert.Equal(player2, game.CurrentPlayer);
            game.SwitchCurrentPlayer();
            Assert.Equal(player1, game.CurrentPlayer);
        }

        [Fact]
        public void GameCanDetermineIfOver()
        {
            Board newBoard = new Board(3);
            game.Board = newBoard;
            
            string[] winnerBoard = { "X", "X", "X", "O", "5", "6", "O", "8", "9" };   // X has three on top row
            string[] drawBoard = { "X", "X", "O", "O", "O", "X", "X", "O", "X" };     // full board with no winner
            string[] inPlayBoard = { "X", "2", "O", "O", "5", "6", "X", "8", "9" };   // board not yet full, no winner yet

            game.Board.gameBoard = winnerBoard;
            Assert.True(game.IsOver());

            game.Board.gameBoard = drawBoard;
            Assert.True(game.IsOver());

            game.Board.gameBoard = inPlayBoard;
            Assert.False(game.IsOver());
        }

        [Fact]
        public void GameCanDisplayResult()
        {
            Player matt = new Player("Matt", game.Player1Marker);
            game.Player1 = matt;
            game.CurrentPlayer = matt;

            string winResult = "Congratulations Matt, you won!";
            game.State = "WIN";

            string result = game.DisplayResult();
            Assert.Contains(winResult, result);

            string drawResult = "Game ended in a draw.";
            game.State = "DRAW";
            result = game.DisplayResult();
            Assert.Contains(drawResult, result);
        }

        [Fact]
        public void GameSetsDifficultyLevel()
        {
            Game game = new Game();
            game.AddPlayers(new FakeUserInput());

            Assert.IsType<HardComputerPlayer>(game.ComputerPlayer);
        }
    }
}
