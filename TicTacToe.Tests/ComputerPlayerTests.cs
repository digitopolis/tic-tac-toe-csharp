using System;
using Xunit;

namespace TicTacToe.Tests
{
    public class ComputerPlayerTests
    {
        [Fact]
        public void CanDetermineBestMoveOnBoard()
        {
            var computer = new ComputerPlayer();
            Game game = new Game();
            char[] board = { '1', 'X', 'X', 'O', '5', '6', 'O', '8', '9' };

            game.Board = board;
            int move = computer.FindBestMove(game);
            Assert.Equal(1, move);
        }
    }
}