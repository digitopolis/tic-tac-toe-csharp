using System;
using Xunit;

namespace TicTacToe.Tests
{
    public class ComputerPlayerTests
    {
        [Fact]
        public void CanDetermineBestMoveOnBoard()
        {
            var computer = new HardComputerPlayer();
            Board newBoard = new Board(3);
            Game game = new Game();
            game.Board = newBoard;

            // Finds a move that would result in a win for either player
            game.Board.gameBoard = new string[] { "1", "X", "X", "O", "5", "6", "O", "8", "9" };

            int move = computer.FindBestMove(game);
            Assert.Equal(1, move);

            // Returns -1 if no move would result in a win for either player
            game.Board.gameBoard = new string[] { "1", "2", "3", "4", "5", "6", "7", "8", "9" };
            move = computer.FindBestMove(game);
            Assert.Equal(-1, move);         
        }
    }
}