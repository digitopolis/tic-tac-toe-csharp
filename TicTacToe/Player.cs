using System;

namespace TicTacToe
{
    public class Player
    {
        public Player(string name)
        {
            this.Name = name;
        }

        public string Name { get; set; }
        public char Marker { get; set; }
    }
}