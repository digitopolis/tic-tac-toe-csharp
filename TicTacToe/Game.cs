using System;

namespace TicTacToe
{
    public class Game
    {
        public Game()
        {
            this.Board = new string[] { "", "", "", "", "", "", "", "", "" };
        }

        public string[] Board { get; set; }
    }
}
