using System;

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

        public bool SpaceIsAvailable(int space)
        {
            int index = space - 1;
            return gameBoard[index] == space.ToString();
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
    }
}