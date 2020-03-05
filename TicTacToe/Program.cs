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
            FinishTurn(game, nextMove);
            // cli.LogToConsole($"\n{game.CurrentPlayer.Name} selected {nextMove}");
            // game.MakeMove(nextMove);
            // if (!game.IsOver())
            // {
            //     game.SwitchCurrentPlayer();
            // }
        }

        static void FinishTurn(Game game, int move)
        {
            cli.LogToConsole($"\n{game.CurrentPlayer.Name} selected {move}");
            game.MakeMove(move);
            if (!game.IsOver())
            {
                game.SwitchCurrentPlayer();
            }
        }

        static void ComputerTurn(Game game)
        {
            if(!game.IsOver())
            {
                int nextMove = game.ComputerPlayer.MakeMove(game);
                FinishTurn(game, nextMove);
            }
        }

        static void Play(Game game)
        {
            while (!game.IsOver())
            {
                PlayerTurn(game);
                if (game.NumberOfPlayers == 1)
                {
                    ComputerTurn(game);
                }
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
