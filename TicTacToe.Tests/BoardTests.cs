using System;
using Xunit;

namespace TicTacToe.Tests
{
    public class BoardTests
    {
        BoardFactory boardFactory = new BoardFactory();

        [Fact]
        public void CreateNew3x3Board()
        {
            // BoardFactory boardFactory = new BoardFactory();
            Board newBoard = boardFactory.BuildBoard(3);

            Assert.Equal(9, newBoard.Length());
        }

        [Fact]
        public void CreateNew5x5Board()
        {
            // BoardFactory boardFactory = new BoardFactory();
            Board newBoard = boardFactory.BuildBoard(5);

            Assert.Equal(25, newBoard.Length());
        }

        [Fact]
        public void FillInSpaces()
        {
            Board new3x3Board = boardFactory.BuildBoard(3);
            Board new5x5Board = boardFactory.BuildBoard(5);

            Assert.Equal("3", new3x3Board.gameBoard[ 2 ]);
            Assert.Equal("25", new5x5Board.gameBoard[ 24 ]);
        }
    }
}