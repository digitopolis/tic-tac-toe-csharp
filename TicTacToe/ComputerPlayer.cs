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

        public Random rand = new Random();

        public string Name { get; }
        public char Marker { get; }

        public int MakeMove(Game game)
        {
            int nextMove = FindBestMove(game);
            return nextMove != -1 ? nextMove : PickRandomSpace(game);
        }
        public int FindBestMove(Game game)
        {
            for (int s = 1; s <= game.Board.Length; s++)
            {
                if (game.SpaceIsAvailable(s))
                {
                    int index = s - 1;
                    game.Board[index] = 'O';
                    if (game.WinningCombinations().Contains(true))
                    {
                        game.Board[index] = char.Parse(s.ToString());
                        return s;
                    }
                    game.Board[index] = 'X';
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
            return PickRandomSpace(game);
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