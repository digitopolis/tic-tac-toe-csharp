using System;
using Xunit;
using Xunit.Abstractions;

namespace TicTacToe.Tests
{
    public class CLITests
    {

        [Fact]
        public void TestLogToConsole()
        {
            var cli = new CLI();
            string message = "test message";
            var currentConsoleOut = Console.Out;
            using (var consoleOutput = new ConsoleOutput())
            {
              cli.LogToConsole(message);
              Assert.Equal(message, consoleOutput.GetOutput());
            }
        }

        [Fact]
        public void TestPrintCurrentBoard()
        {
            CLI cli = new CLI();
            char[] board = { ' ', 'X', ' ', ' ', ' ', 'O',  'X', ' ', ' ' };
            string topLine = "       |   X   |     ";
            string divider = "  - - -+- - - -+- - -";
            var currentConsoleOut = Console.Out;
            using (var consoleOutput = new ConsoleOutput())
            {
              cli.PrintBoard(board);
              Assert.Contains(topLine, consoleOutput.GetOutput());
              Assert.Contains(divider, consoleOutput.GetOutput());
            }
        }
    }
}


/* 
   1   |   2   |   3 
  - - -+- - - -+- - -
   4   |   5   |   6 
  - - -+- - - -+- - -
   7   |   8   |   9 

*/