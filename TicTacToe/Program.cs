using System;

namespace TicTacToe
{
    class Program
    {
        static CLI cli = new CLI();
        public static string play = "Y";

        static void Main(string[] args)
        {
            while (play == "Y")
            {
                Game game = StartNewGame();
                Play(game);
                play = PlayAnotherGame();
            }
        }

        static Game StartNewGame()
        {
            Game game = new Game();
            cli.WelcomeToGame();
            game.AddPlayers(cli);
            return game;
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

        static void Play(Game game)
        {
            while (!game.IsOver())
            {
                PlayerTurn(game);
            }
            game.DisplayCurrentBoard(cli);
            cli.LogToConsole(game.DisplayResult());
        }

        static string PlayAnotherGame()
        {
            cli.LogToConsole("Would you like to play another game?\nEnter 'Y' to play again or 'N' to quit:");
            string userSelection = cli.GetMenuSelection();
            return userSelection;
        }
    }
}
