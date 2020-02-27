using System;

namespace TicTacToe
{
    class Program
    {
        static CLI cli = new CLI();

        static void Main(string[] args)
        {
            Game game = new Game();
            cli.WelcomeToGame();
            game.AddPlayers(cli);
            game.DisplayCurrentBoard(cli);
            int nextMove = game.NextPlayerMove(cli);
        }
    }
}
