using System;
using System.Collections.Generic;
using System.Text;

namespace jeu.Models
{
    public class Player
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Wins { get; set; }
        public int Losses { get; set; }

        public Player(string name)
        {
            Name = name;
            Wins = 0;
            Losses = 0;
        }
        
        public Player() 
        {
        }
    }
}
