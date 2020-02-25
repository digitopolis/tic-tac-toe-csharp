using System;

namespace TicTacToe
{
    public class Game
    {
        public char Player1Marker = 'X';
        public char Player2Marker = 'O';
        public Game()
        {
            this.Board = new char[] { ' ', ' ', ' ', ' ', ' ', ' ',  ' ', ' ', ' ' };
            this.CurrentPlayer = this.Player1;
        }

        public char[] Board { get; set; }
        public Player Player1 { get; set; }
        public Player Player2 { get; set; }
        public Player CurrentPlayer { get; set; }

        public void MakeMove(int space, char marker)
        {
            int index = space - 1;
            this.Board[index] = marker;
        }

        public void AddPlayers(IUserInput input)
        {
            string[] names = input.GetPlayerNames(this);
            this.Player1 = new Player(names[0], Player1Marker);
            this.Player2 = new Player(names[1], Player2Marker);
        }

        public void DisplayCurrentBoard(IOutput output)
        {
            output.PrintBoard(this.Board);
        }

        public int NextPlayerMove(IUserInput input, Player player)
        {
            int move = input.GetPlayerMove(player);
            return move;
        }
    }
}
