using System;
using System.Linq;

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

        public void MakeMove(int space)
        {
            int index = space - 1;
            this.Board[index] = this.CurrentPlayer.Marker;
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

        public bool SpaceIsAvailable(int space)
        {
            int index = space - 1;
            return Board[index] != Player1Marker && Board[index] != Player2Marker;
        }

        public void SwitchCurrentPlayer()
        {
            CurrentPlayer = CurrentPlayer == Player1 ? Player2 : Player1;
        }

        public bool[] WinningCombinations()
        {
            return new bool[] {
                Board[0] == Board[1] && Board[1] == Board[2],
                Board[3] == Board[4] && Board[4] == Board[5],
                Board[6] == Board[7] && Board[7] == Board[8],
                Board[0] == Board[3] && Board[3] == Board[6],
                Board[1] == Board[4] && Board[4] == Board[7],
                Board[2] == Board[5] && Board[5] == Board[8],
                Board[0] == Board[4] && Board[4] == Board[8],
                Board[2] == Board[4] && Board[4] == Board[6],
            };
        }

        public bool IsOver()
        {
            // A player has three in a row
            if (WinningCombinations().Contains(true))
            {
                return true;
            }
            // Board is full, no winner
            // Board is not full, no winner
            return false;
        }
    }
}
