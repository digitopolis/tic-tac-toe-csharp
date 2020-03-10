using System;

namespace TicTacToe
{
    public class Board
    {
        public Board(int side)
        {
            this.gameBoard = new char[ side, side ];
        }
        public char[,] gameBoard { get; set; }

        public int Length() => this.gameBoard.Length;
    }
}