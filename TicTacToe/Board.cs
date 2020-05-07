using System;
using System.Linq;

namespace TicTacToe
{
    public class Board
    {
        public Board(int side)
        {
            this.gameBoard = new string[ side * side ];
            this.side = side;
        }
        public string[] gameBoard { get; set; }
        public int side { get; }

        public int Length() => this.gameBoard.Length;

        public string[] GetRow(int rowNumber)
        {
            string[] rowArray = new string[side];
            int startingIndex = (rowNumber - 1) * side;
            for (int i = 0; i < side; i++)
            {
                rowArray[i] = gameBoard[startingIndex + i];
            }
            return rowArray;
        }

        public string[] GetColumn(int colNumber)
        {
            string[] ColArray = new string[side];
            int startingIndex = (colNumber - 1);
            for (int i = 0; i < side; i++)
            {
                ColArray[i] = gameBoard[startingIndex + i * side];
            }
            return ColArray;
        }

        public string[] GetDownDiagonal()
        {
            string[] diagonalArray = new string[side];
            for (int i = 0; i < side; i++)
            {
                diagonalArray[i] = gameBoard[(side + 1) * i];
            }
            return diagonalArray;
        }

        public string[] GetUpDiagonal()
        {
            string[] diagonalArray = new string[side];
            int startingIndex = side * (side - 1);
            for (int i = 0; i < side; i++)
            {
                diagonalArray[i] = gameBoard[startingIndex - (i * (side - 1))];
            }
            return diagonalArray;
        }

        public bool SpaceIsAvailable(int space)
        {
            int index = space - 1;
            return gameBoard[index] == space.ToString();
        }

        public int GetRandomSpace()
        {
            Random rand = new Random();
            int moveMax = side * side;
            int randomSpace = rand.Next(1, moveMax);
            if (SpaceIsAvailable(randomSpace))
            {
                return randomSpace;
            }
            else
            {
                return GetRandomSpace();
            }
        }

        public bool IsFull()
        {
            for ( int i = 1; i < gameBoard.Length + 1; i++ )
            {
                if (SpaceIsAvailable(i))
                {
                    return false;
                }
            }
            return true;
        }

        public void UpdateSpace(int space, string marker)
        {
            int index = space - 1;
            gameBoard[index] = marker;
        }

        public bool HasWinningCombination()
        {
            for (int i = 1; i <= side; i++)
            {
                string[] sortedRow = GetRow(i).OrderBy(s => s).ToArray();
                string[] sortedColumn = GetColumn(i).OrderBy(s => s).ToArray();
                bool rowWin = sortedRow[0] == sortedRow[side - 1];
                bool columnWin = sortedColumn[0] == sortedColumn[side - 1];
                if ( rowWin || columnWin )
                {
                    return true;
                }
            }
            string[] sortedDownDiagonal = GetDownDiagonal().OrderBy(s => s).ToArray();
            string[] sortedUpDiagonal = GetUpDiagonal().OrderBy(s => s).ToArray();
            bool diagonalWin = sortedDownDiagonal[0] == sortedDownDiagonal[side - 1] || sortedUpDiagonal[0] == sortedUpDiagonal[side - 1];
            return diagonalWin ? true : false;
        }
    }
}