using System;

namespace TicTacToe
{
    public class Game
    {
        public char Player1Marker = 'X';
        public char Player2Marker = 'O';
        public Game()
        {
            this.Board = new char[] { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
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
            this.CurrentPlayer = this.Player1;
        }

        public void DisplayCurrentBoard(IOutput output)
        {
            output.PrintBoard(this.Board);
        }

        public int NextPlayerMove(IUserInput input)
        {
            int move = input.GetPlayerMove(this.CurrentPlayer);
            return move;
        }

        public bool IsValidInput(int move)
        {
            return move > 0 && move <= 9 ? true : false;
        }
    }
}
