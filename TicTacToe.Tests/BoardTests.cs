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

        [Fact]
        public void CanGetDownDiagonal()
        {
            Board new3x3Board = boardFactory.BuildBoard(3);
            Board new4x4Board = boardFactory.BuildBoard(4);
            string[] down3x3 = new string[] { "1", "5", "9" };
            string[] down4x4 = new string[] { "1", "6", "11", "16" };

            Assert.Equal(down3x3, new3x3Board.GetDownDiagonal());
            Assert.Equal(down4x4, new4x4Board.GetDownDiagonal());
        }

        [Fact]
        public void CanGetUpDiagonal()
        {
            Board new3x3Board = boardFactory.BuildBoard(3);
            Board new4x4Board = boardFactory.BuildBoard(4);
            string[] up3x3 = new string[] { "7", "5", "3" };
            string[] up4x4 = new string[] { "13", "10", "7", "4" };

            Assert.Equal(up3x3, new3x3Board.GetUpDiagonal());
            Assert.Equal(up4x4, new4x4Board.GetUpDiagonal());
        }

        [Fact]
        public void CanGenerateRandomNumber()
        {
            var computer = new HardComputerPlayer();
            Game game = new Game();
            game.Board = boardFactory.BuildBoard(4);

            int space = game.Board.GetRandomSpace();
            Assert.InRange(space, 1, 16);
            space = game.Board.GetRandomSpace();
            Assert.InRange(space, 1, 16);
            space = game.Board.GetRandomSpace();
            Assert.InRange(space, 1, 16);
            space = game.Board.GetRandomSpace();
            Assert.InRange(space, 1, 16);
        }
    }
}