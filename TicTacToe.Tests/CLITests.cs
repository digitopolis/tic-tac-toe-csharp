using System;
using Xunit;

namespace TicTacToe.Tests
{
    public class CLITests
    {
        [Fact]
        public void TestLogMessage()
        {
            var cli = new CLI();
            cli.LogToConsole();
        }
    }
}
