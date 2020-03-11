using System;
using System.Linq;

namespace TicTacToe
{
    public class Game
    {
        public string Player1Marker = "X";
        public string Player2Marker = "O";
        public Game()
        {
            this.State = "";
        }

        public Board Board { get; set; }
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
            output.PrintBoard(Board.gameBoard);
        }

        public int NextPlayerMove(IUserInput input)
        {
            int move = input.GetPlayerMove(this.CurrentPlayer);
            return move;
        }

        public void SwitchCurrentPlayer()
        {
            CurrentPlayer = CurrentPlayer == Player1 ? Player2 : Player1;
        }

        public bool IsOver()
        {
            if (Board.HasWinningCombination())
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
