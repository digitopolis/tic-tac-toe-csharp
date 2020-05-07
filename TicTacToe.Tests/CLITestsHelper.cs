using System;
using System.IO;

namespace TicTacToe.Tests
{
    public class ConsoleOutput : IDisposable
    {
        private StringWriter stringWriter;
        private TextWriter originalOutput;

        public ConsoleOutput()
        {
          stringWriter = new StringWriter();
          stringWriter.NewLine = "";
          originalOutput = Console.Out;
          Console.SetOut(stringWriter);
        }

        public string GetOutput()
        {
            return stringWriter.ToString();
        }

        public void Dispose()
        {
            Console.SetOut(originalOutput);
            stringWriter.Dispose();
        }
    }

    public class FakeUserInput : IUserInput
    {
        public string[] GetPlayerNames(Game game)
        {
            string[] fakeNames = { "player 1 name", "player 2 name" };
            return fakeNames;
        }

        public int GetPlayerMove(Player player)
        {
            return 4;
        }

        public int GetNumberOfPlayers()
        {
            return 2;
        }
    }
}
