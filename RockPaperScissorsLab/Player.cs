using System;
using System.Collections.Generic;
using System.Text;

namespace RockPaperScissorsLab
{
    abstract class Player
    {
        public string Name { get; set; }
        public RPS Hand { get; set; }

        public Player (string name)
        {
            this.Name = name;
        }


        public abstract RPS GenerateRPS();
    }
}
