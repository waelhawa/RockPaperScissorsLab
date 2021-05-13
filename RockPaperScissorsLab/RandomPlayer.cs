using System;
using System.Collections.Generic;
using System.Text;

namespace RockPaperScissorsLab
{
    class RandomPlayer : Player
    {
        public RandomPlayer () : base("Random Player")
        {
            
        }
        public override RPS GenerateRPS()
        {
            Random rand = new Random();
            int rps = rand.Next(1, 4);
            switch (rps)
            {
                case 1:
                    return RPS.rock;
                case 2:
                    return RPS.paper;
                case 3:
                    return RPS.scissors;
                default:
                    return 0;

            }
        }
    }
}
