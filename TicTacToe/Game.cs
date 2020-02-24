using System;

namespace TicTacToe
{
    public class Game
    {
        public Game()
        {
            this.Board = new char[] { ' ', ' ', ' ', ' ', ' ', ' ',  ' ', ' ', ' ' };
        }

        public char[] Board { get; set; }
        public Player Player1 { get; set; }
        public Player Player2 { get; set; }

        public void MakeMove(int space, char marker)
        {
            int index = space - 1;
            this.Board[index] = marker;
        }

        public void AddPlayers(IUserInput input)
        {
            string[] names = input.GetPlayerNames();
            this.Player1 = new Player(names[0], 'X');
            this.Player2 = new Player(names[1], 'O');
        }
    }
}
