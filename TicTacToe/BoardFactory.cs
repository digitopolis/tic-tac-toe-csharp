using System;

namespace TicTacToe
{
    public class BoardFactory
    {
        public Board BuildBoard(int size)
        {
            Board newBoard = new Board(size);
            return newBoard;
        }
    }
}