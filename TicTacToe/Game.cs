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
            this.State = "";
        }

        public char[] Board { get; set; }
        public int NumberOfPlayers { get; set; }
        public Player Player1 { get; set; }
        public Player Player2 { get; set; }
        public Player CurrentPlayer { get; set; }
        public string State { get; set; }

        public void MakeMove(int space)
        {
            int index = space - 1;
            this.Board[index] = this.CurrentPlayer.Marker;
        }

        public void AddPlayers(IUserInput input)
        {
            this.NumberOfPlayers = input.GetNumberOfPlayers();
            string[] names = input.GetPlayerNames(this);
            this.Player1 = new Player(names[0], Player1Marker);
            this.Player2 = new Player(names[1], Player2Marker);
            if (this.NumberOfPlayers == 1)
            {
                this.ComputerPlayer = new HardComputerPlayer();
            }
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

        public bool BoardIsFull()
        {
            for ( int i = 1; i < this.Board.Length + 1; i++ )
            {
                if (SpaceIsAvailable(i))
                {
                    return false;
                }
            }
            return true;
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
                this.State = "WIN";
                return true;
            }
            // Board is full, no winner
            else if (BoardIsFull())
            {
                this.State = "DRAW";
                return true;
            }
            // Board is not full, no winner
            return false;
        }

        public string DisplayResult()
        {
            string result = "";
            switch (this.State)
            {
                case "WIN":
                    result = $"Congratulations {this.CurrentPlayer.Name}, you won!";
                    break;
                case "DRAW":
                    result = "Game ended in a draw.";
                    break;
                default:
                    break;
            }
            return $"Game over! {result}";
        }
    }
}
