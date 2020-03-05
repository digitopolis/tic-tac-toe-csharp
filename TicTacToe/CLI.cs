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
            this.LogToConsole("Welcome to Tic Tac Toe!\n\n");
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

        public int GetPlayerMove(Player player)
        {
            Console.WriteLine($"{player.Name}, please select a space on the board");
            string playerInput = Console.ReadLine();
            while (!IsValidInput(playerInput, "MOVE"))
            {
                Console.WriteLine("Please enter a number between 1-9");
                playerInput = Console.ReadLine();
            }
            return Int32.Parse(playerInput);
        }

        public string GetMenuSelection()
        {
            string input = Console.ReadLine();
            while (!IsValidInput(input, "MENU"))
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

        public void PrintBoard(char[] board)
        {
            string horizDivider = "  - - -+- - - -+- - -";
            this.LogToConsole("");
            this.LogToConsole($"   {board[0]}   |   {board[1]}   |   {board[2]} ");
            this.LogToConsole(horizDivider);
            this.LogToConsole($"   {board[3]}   |   {board[4]}   |   {board[5]} ");
            this.LogToConsole(horizDivider);
            this.LogToConsole($"   {board[6]}   |   {board[7]}   |   {board[8]} ");
            this.LogToConsole("");
        }

        public bool IsValidInput(string input, string inputFor)
        {
            int number;
            switch (inputFor)
            {
                case "MOVE":
                    return Int32.TryParse(input, out number) && number > 0 && number <= 9;
                case "MENU":
                    return input.ToUpper() == "Y" || input.ToUpper() == "N" ? true : false;
                case "ONE-OR-TWO":
                    return Int32.TryParse(input, out number) && number > 0 && number <= 2;
                default:
                    return false;
            }
            
        }
    }

    public interface IUserInput
    {
        string[] GetPlayerNames(Game game);
        int GetPlayerMove(Player player);
        int GetNumberOfPlayers();
        int GetDifficultyLevel();
    }

    public interface IOutput
    {
        void PrintBoard(char[] board);
        void LogToConsole(string message);
    }
}
