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

        public string[] GetPlayerNames()
        {
            Console.WriteLine("Player 1 (X), please enter your name:");
            string player1Name  = Console.ReadLine();
            Console.WriteLine("Player 2 (O), please enter your name:");
            string player2Name  = Console.ReadLine();
            string[] names = { player1Name, player2Name };
            return names;
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
    }

    public interface IUserInput
    {
        string[] GetPlayerNames();
    }

    public interface IOutput
    {
        void PrintBoard(char[] board);
    }
}
