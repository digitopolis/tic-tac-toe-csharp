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
            int space = 1;
            for (int row = 0; row < board.side; row++)
            {
                for (int col = 0; col < board.side; col++)
                {
                    board.gameBoard[ row, col ] = space.ToString();
                    space++;
                }
            }
            return board;
        }
    }
}