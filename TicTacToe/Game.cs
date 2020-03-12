using System;
using System.Linq;

namespace TicTacToe
{
    public class Game
    {
        static BoardFactory boardFactory = new BoardFactory();

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
            NumberOfPlayers = input.GetNumberOfPlayers();
            string[] names = input.GetPlayerNames(this);
            Player1 = new Player(names[0], Player1Marker);
            Player2 = new Player(names[1], Player2Marker);
            if (NumberOfPlayers == 1)
            {
                int selectedDifficulty = input.GetDifficultyLevel();
                if (selectedDifficulty == 1)
                {
                    ComputerPlayer = new EasyComputerPlayer();
                }
                else
                {
                    ComputerPlayer = new HardComputerPlayer();
                }
            }
            CurrentPlayer = Player1;
        }

        public void SetBoardSize(IUserInput input)
        {
            int boardSize = input.GetBoardSize();
            Board = boardFactory.BuildBoard(boardSize);
        }

        public void DisplayCurrentBoard(IOutput output)
        {
            output.PrintBoard(Board);
        }

        public int NextPlayerMove(IUserInput input)
        {
            int move = input.GetPlayerMove(CurrentPlayer, Board.side);
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
                    State = "LOSE";
                    return true;
                }
                State = "WIN";
                return true;
            }
            else if (Board.IsFull())
            {
                State = "DRAW";
                return true;
            }
            return false;
        }

        public string DisplayResult()
        {
            string result = "";
            switch (State)
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
