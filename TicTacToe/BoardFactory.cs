using System;

namespace TicTacToe
{
    public class BoardFactory
    {
        public Board BuildBoard(int size)
        {
            Board newBoard = new Board(size);
            return PopulateBoard(newBoard);
        }

        public Board PopulateBoard(Board board)
        {
            for (int space = 1; space <= board.gameBoard.Length; space++)
            {
                board.gameBoard[space - 1] = space.ToString();
            }
            return board;
        }
    }
}