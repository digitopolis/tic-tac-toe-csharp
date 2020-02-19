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
    }
}
