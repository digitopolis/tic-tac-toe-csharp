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
            while (!game.IsOver())
            {
                PlayerTurn(game);
            }
            cli.LogToConsole(game.DisplayResult());
        }

        static void PlayerTurn(Game game)
        {
            game.DisplayCurrentBoard(cli);
            int nextMove = game.NextPlayerMove(cli);
            while (!game.SpaceIsAvailable(nextMove))
            {
                cli.LogToConsole("Sorry, that space isn't available");
                nextMove = game.NextPlayerMove(cli);
            }
            cli.LogToConsole($"{game.CurrentPlayer.Name} selected {nextMove}");
            game.MakeMove(nextMove);
            if (!game.IsOver())
            {
                game.SwitchCurrentPlayer();
            }
        }
    }
}
