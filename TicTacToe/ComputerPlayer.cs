using System;
using System.Linq;

namespace TicTacToe
{
    public class ComputerPlayer
    {
        public int FindBestMove(Game game)
        {
            for (int s = 1; s <= game.Board.Length; s++)
            {
                if (game.SpaceIsAvailable(s))
                {
                    int index = s - 1;
                    game.Board[index] = 'X';
                    if (game.WinningCombinations().Contains(true))
                    {
                        game.Board[index] = char.Parse(s.ToString());
                        return s;
                    }
                    game.Board[index] = 'O';
                    if (game.WinningCombinations().Contains(true))
                    {
                        game.Board[index] = char.Parse(s.ToString());
                        return s;
                    }
                    game.Board[index] = char.Parse(s.ToString());
                }
            }
            return -1;
        }
        public int PickRandomSpace(Game game)
        {
            int randomSpace = rand.Next(1, 10);
            if (game.SpaceIsAvailable(randomSpace))
            {
                return randomSpace;
            }
            else
            {
                return PickRandomSpace(game);
            }
        }
    }
}