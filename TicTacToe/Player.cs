using System;

namespace TicTacToe
{
    public class Player
    {
        public Player(string name, char marker)
        {
            this.Name = name;
            this.Marker = marker;
        }

        public string Name { get; set; }
        public char Marker { get; set; }
    }
}