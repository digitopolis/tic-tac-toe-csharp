using System;

namespace TicTacToe
{
    public class CLI : IUserInput
    {
        public void LogToConsole(string message)
        {
            Console.WriteLine(message);
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
    }

    public interface IUserInput
    {
        string[] GetPlayerNames();
    }
}
