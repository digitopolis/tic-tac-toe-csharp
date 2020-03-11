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
        public IComputerPlayer ComputerPlayer {get; set; }
        public Player CurrentPlayer { get; set; }
        public string State { get; set; }

        public void MakeMove(int space)
        {
            Board.UpdateSpace(space, CurrentPlayer.Marker);
        }

        public void AddPlayers(IUserInput input)
        {
            this.NumberOfPlayers = input.GetNumberOfPlayers();
            string[] names = input.GetPlayerNames(this);
            this.Player1 = new Player(names[0], Player1Marker);
            this.Player2 = new Player(names[1], Player2Marker);
            if (this.NumberOfPlayers == 1)
            {
                int selectedDifficulty = input.GetDifficultyLevel();
                if (selectedDifficulty == 1)
                {
                    this.ComputerPlayer = new EasyComputerPlayer();
                }
                else
                {
                    this.ComputerPlayer = new HardComputerPlayer();
                }
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

        // public bool SpaceIsAvailable(int space)
        // {
        //     int index = space - 1;
        //     return Board.gameBoard[index] != Player1Marker && Board.gameBoard[index] != Player2Marker;
        // }

        // public bool BoardIsFull()
        // {
        //     for ( int i = 1; i < this.Board.gameBoard.Length + 1; i++ )
        //     {
        //         if (SpaceIsAvailable(i))
        //         {
        //             return false;
        //         }
        //     }
        //     return true;
        // }

        public void SwitchCurrentPlayer()
        {
            CurrentPlayer = CurrentPlayer == Player1 ? Player2 : Player1;
        }

        public bool[] WinningCombinations()
        {
            return new bool[] {
                Board.gameBoard[0] == Board.gameBoard[1] && Board.gameBoard[1] == Board.gameBoard[2],
                Board.gameBoard[3] == Board.gameBoard[4] && Board.gameBoard[4] == Board.gameBoard[5],
                Board.gameBoard[6] == Board.gameBoard[7] && Board.gameBoard[7] == Board.gameBoard[8],
                Board.gameBoard[0] == Board.gameBoard[3] && Board.gameBoard[3] == Board.gameBoard[6],
                Board.gameBoard[1] == Board.gameBoard[4] && Board.gameBoard[4] == Board.gameBoard[7],
                Board.gameBoard[2] == Board.gameBoard[5] && Board.gameBoard[5] == Board.gameBoard[8],
                Board.gameBoard[0] == Board.gameBoard[4] && Board.gameBoard[4] == Board.gameBoard[8],
                Board.gameBoard[2] == Board.gameBoard[4] && Board.gameBoard[4] == Board.gameBoard[6],
            };
        }

        public bool IsOver()
        {
            if (WinningCombinations().Contains(true))
            {
                if (NumberOfPlayers == 1 && CurrentPlayer == Player2)
                {
                    this.State = "LOSE";
                    return true;
                }
                this.State = "WIN";
                return true;
            }
            else if (Board.IsFull())
            {
                this.State = "DRAW";
                return true;
            }
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
                case "LOSE":
                    result = $"I'm sorry {this.Player1.Name}, you lost.";
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
