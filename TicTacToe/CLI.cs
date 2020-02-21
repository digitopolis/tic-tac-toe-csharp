using System;

namespace TicTacToe
{
    public class CLI
    {
        public void LogToConsole(string message)
        {
            Console.WriteLine(message);
        }

        public string GetConsoleInput()
        {
            string input = Console.ReadLine();
            return input;
        }
    }
}
