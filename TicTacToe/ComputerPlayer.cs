using System;
using System.Linq;

namespace TicTacToe
{
    public interface IComputerPlayer
    {
        int MakeMove(Game game);
    }

    public class HardComputerPlayer : IComputerPlayer
    {
        public HardComputerPlayer()
        {
            this.Name = "Computer";
            this.Marker = 'O';
        }

        public string Name { get; }
        public char Marker { get; }

        public int MakeMove(Game game)
        {
            int nextMove = FindBestMove(game);
            return nextMove != -1 ? nextMove : game.Board.GetRandomSpace();
        }
        public int FindBestMove(Game game)
        {
            int moveToBlock = 0;
            for (int s = 1; s <= game.Board.Length(); s++)
            {
                if (game.Board.SpaceIsAvailable(s))
                {
                    int index = s - 1;
                    game.Board.gameBoard[index] = game.Player2Marker;
                    if (game.Board.HasWinningCombination())
                    {
                        game.Board.gameBoard[index] = s.ToString();
                        return s;
                    }
                    game.Board.gameBoard[index] = game.Player1Marker;
                    if (game.Board.HasWinningCombination())
                    {
                        game.Board.gameBoard[index] = s.ToString();
                        moveToBlock = s;
                    }
                    game.Board.gameBoard[index] = s.ToString();
                }
            }
            return moveToBlock == 0 ? -1 : moveToBlock;
        }
    }

    public class EasyComputerPlayer : IComputerPlayer
    {
        public EasyComputerPlayer()
        {
            this.Name = "Computer";
            this.Marker = 'O';
        }

        public Random rand = new Random();

        public string Name { get; }
        public char Marker { get; }

        public int MakeMove(Game game)
        {
            return game.Board.GetRandomSpace();
        }
    }
}