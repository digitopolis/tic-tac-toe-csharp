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

        [Fact]
        public void CheckSpaceAvailability()
        {
            Board newBoard = boardFactory.BuildBoard(3);
            newBoard.gameBoard = new string[] { "X", "2", "O", "O", "5", "6", "X", "8", "9" };
            Assert.True(newBoard.SpaceIsAvailable(2));
            Assert.False(newBoard.SpaceIsAvailable(3));
        }

        [Fact]
        public void CanGetSpecificRow()
        {
            Board new3x3Board = boardFactory.BuildBoard(3);
            Board new4x4Board = boardFactory.BuildBoard(4);
            string[] middleRow3x3 = new string[] { "4", "5", "6" };
            string[] lastRow4x4 = new string[] { "13", "14", "15", "16" };

            Assert.Equal(middleRow3x3, new3x3Board.GetRow(2));
            Assert.Equal(lastRow4x4, new4x4Board.GetRow(4));
        }

        [Fact]
        public void CanGetSpecificColumn()
        {
            Board new3x3Board = boardFactory.BuildBoard(3);
            Board new4x4Board = boardFactory.BuildBoard(4);
            string[] middleCol3x3 = new string[] { "2", "5", "8" };
            string[] lastCol4x4 = new string[] { "4", "8", "12", "16" };

            Assert.Equal(middleCol3x3, new3x3Board.GetColumn(2));
            Assert.Equal(lastCol4x4, new4x4Board.GetColumn(4));
        }
    }
}