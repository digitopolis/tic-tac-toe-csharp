using System;

namespace TicTacToe
{
    class Program
    {
        static CLI cli = new CLI();

        static void Main(string[] args)
        {
            cli.LogToConsole("Welcome to Tic Tac Toe!");
        }
    }
}
