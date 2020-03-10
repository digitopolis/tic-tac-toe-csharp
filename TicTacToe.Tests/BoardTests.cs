using System;
using Xunit;

namespace TicTacToe.Tests
{
    public class BoardTests
    {
        [Fact]
        public void CreateNew3x3Board()
        {
            BoardFactory boardFactory = new BoardFactory();
            Board newBoard = boardFactory.BuildBoard(3);

            Assert.Equal(9, newBoard.Length());
        }

        [Fact]
        public void CreateNew5x5Board()
        {
            BoardFactory boardFactory = new BoardFactory();
            Board newBoard = boardFactory.BuildBoard(5);

            Assert.Equal(25, newBoard.Length());
        }
    }
}