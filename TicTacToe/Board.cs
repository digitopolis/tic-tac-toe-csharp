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
    }
}