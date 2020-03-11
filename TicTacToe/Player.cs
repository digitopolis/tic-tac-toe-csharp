using System;

namespace TicTacToe
{
    public class Player
    {
        public Player(string name, string marker)
        {
            this.Name = name;
            this.Marker = marker;
        }

        public string Name { get; set; }
        public string Marker { get; set; }
    }
}