using System;

namespace TicTacToe
{
    public class CLI : IUserInput, IOutput
    {
        public void LogToConsole(string message)
        {
            Console.WriteLine(message);
        }

        public void WelcomeToGame()
        {
            LogToConsole("Welcome to Tic Tac Toe!\n\n");
        }

        public string[] GetPlayerNames(Game game)
        {
            string[] names;
            Console.WriteLine($"Player 1 ({game.Player1Marker}), please enter your name:");
            string player1Name  = Console.ReadLine();
            if (game.NumberOfPlayers == 2)
            {
                Console.WriteLine($"Player 2 ({game.Player2Marker}), please enter your name:");
                string player2Name  = Console.ReadLine();
                names = new string[] { player1Name, player2Name };
            }
            else
            {
                names = new string[] { player1Name, "Computer"};
            }
            return names;
        }

        public int GetPlayerMove(Player player, int boardSize)
        {
            int moveMax = boardSize * boardSize;
            Console.WriteLine($"{player.Name}, please select a space on the board");
            string playerInput = Console.ReadLine();
            while (!IsValidInput(playerInput, "MOVE", moveMax))
            {
                Console.WriteLine($"Please enter a number between 1-{moveMax}");
                playerInput = Console.ReadLine();
            }
            return Int32.Parse(playerInput);
        }

        public string GetMenuSelection()
        {
            string input = Console.ReadLine();
            while (!IsValidInput(input, "YES-OR-NO"))
            {
                Console.WriteLine("Please enter 'Y' to play again or 'N' to quit");
                input = Console.ReadLine();
            }
            return input.ToUpper();
        }

        public int GetNumberOfPlayers()
        {
            LogToConsole("Please enter the number of players (1 or 2)");
            string input = Console.ReadLine();
            while (!IsValidInput(input, "ONE-OR-TWO"))
            {
                Console.WriteLine("Please enter '1' to play against the computer or '2' for a two person game");
                input = Console.ReadLine();
            }
            return Int32.Parse(input);
        }

        public int GetDifficultyLevel()
        {
            LogToConsole("Please select the difficulty level (1 for Easy or 2 for Hard)");
            string input = Console.ReadLine();
            while (!IsValidInput(input, "ONE-OR-TWO"))
            {
                Console.WriteLine("Please enter '1' for an easier opponent or '2' for more of a challenge");
                input = Console.ReadLine();
            }
            return Int32.Parse(input);
        }

        public int GetBoardSize()
        {
            LogToConsole("Please select the board size: 3 for 3x3, 4 for 4x4, or 5 for 5x5");
            string input = Console.ReadLine();
            while (!IsValidInput(input, "BOARD-SIZE"))
            {
                Console.WriteLine("Please enter '3' for a 3x3 board, '4' for 4x4, or '5' for 5x5");
                input = Console.ReadLine();
            }
            return Int32.Parse(input);
        }

        public void PrintBoard(Board board)
        {
            string horizDivider = "  - - -";
            for (int i = 1; i < board.side; i++)
            {
                horizDivider += "+- - - -";
            }
            string boardString = "";
            int index = 0;
            LogToConsole("");
            for (int row = 1; row <= board.side; row++)
            {
                string marker = board.gameBoard[index];
                string rowString = $"  {(marker.Length > 1 ? "" : " ")}{marker}   ";
                index++;
                for (int col = 2; col <= board.side; col++)
                {
                    marker = board.gameBoard[index];
                    rowString += $"|  {(marker.Length > 1 ? "" : " ")}{marker}   ";
                    index++;
                }
                if (row == board.side)
                {
                    horizDivider = "";
                }
                boardString += $"{rowString}\n{horizDivider}\n";
            }
            LogToConsole(boardString);
        }

        public bool IsValidInput(string input, string inputFor, int moveMax = 9)
        {
            int number;
            switch (inputFor)
            {
                case "MOVE":
                    return Int32.TryParse(input, out number) && number > 0 && number <= moveMax;
                case "YES-OR-NO":
                    return input.ToUpper() == "Y" || input.ToUpper() == "N" ? true : false;
                case "ONE-OR-TWO":
                    return Int32.TryParse(input, out number) && number > 0 && number <= 2;
                case "BOARD-SIZE":
                    return Int32.TryParse(input, out number) && number >= 3 && number <= 5;
                default:
                    return false;
            }
            
        }
    }

    public interface IUserInput
    {
        string[] GetPlayerNames(Game game);
        int GetPlayerMove(Player player, int boardSize);
        int GetNumberOfPlayers();
        int GetDifficultyLevel();
        int GetBoardSize();
    }

    public interface IOutput
    {
        void PrintBoard(Board board);
        void LogToConsole(string message);
    }
}
