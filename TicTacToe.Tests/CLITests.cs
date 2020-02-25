using System;
using Xunit;
using Xunit.Abstractions;

namespace TicTacToe.Tests
{
    public class CLITests
    {
        CLI cli = new CLI();

        [Fact]
        public void TestLogToConsole()
        {
            string message = "test message";
            var currentConsoleOut = Console.Out;
            using (var consoleOutput = new ConsoleOutput())
            {
              cli.LogToConsole(message);
              Assert.Equal(message, consoleOutput.GetOutput());
            }
        }

        [Theory]
        [InlineData("       |   X   |     ")]
        [InlineData("  - - -+- - - -+- - -")]
        [InlineData("       |       |   O ")]
        public void TestPrintCurrentBoard(string line)
        {
            char[] board = { ' ', 'X', ' ', ' ', ' ', 'O',  'X', ' ', ' ' };
            var currentConsoleOut = Console.Out;
            using (var consoleOutput = new ConsoleOutput())
            {
              cli.PrintBoard(board);
              Assert.Contains(line, consoleOutput.GetOutput());
            }
        }

        [Theory]
        [InlineData(1)]
        [InlineData(4)]
        [InlineData(9)]
        public void CLICanValidateInput(int input)
        {
            Assert.True(cli.IsValidInput(input));
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