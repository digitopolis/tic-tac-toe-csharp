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
            this.LogToConsole("Welcome to Tic Tac Toe!\n\nTo start a new game, please enter both players' names\n\n");
        }

        public string[] GetPlayerNames(Game game)
        {
            Console.WriteLine($"Player 1 ({game.Player1Marker}), please enter your name:");
            string player1Name  = Console.ReadLine();
            Console.WriteLine($"Player 2 ({game.Player2Marker}), please enter your name:");
            string player2Name  = Console.ReadLine();
            string[] names = { player1Name, player2Name };
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
            Console.WriteLine($"You selected {playerInput}");
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

        public void PrintBoard(char[] board)
        {
            string horizDivider = "  - - -+- - - -+- - -";
            this.LogToConsole($"   {board[0]}   |   {board[1]}   |   {board[2]} ");
            this.LogToConsole(horizDivider);
            this.LogToConsole($"   {board[3]}   |   {board[4]}   |   {board[5]} ");
            this.LogToConsole(horizDivider);
            this.LogToConsole($"   {board[6]}   |   {board[7]}   |   {board[8]} ");
        }

        public bool IsValidInput(string input, string inputFor)
        {
            switch (inputFor)
            {
                case "MOVE":
                    int number;
                    return Int32.TryParse(input, out number) && number > 0 && number <= 9;
                case "MENU":
                    return input.ToUpper() == "Y" || input.ToUpper() == "N" ? true : false;
                default:
                    return false;
            }
            
        }
    }

    public interface IUserInput
    {
        string[] GetPlayerNames(Game game);
        int GetPlayerMove(Player player);
    }

    public interface IOutput
    {
        void PrintBoard(char[] board);
        void LogToConsole(string message);
    }
}
