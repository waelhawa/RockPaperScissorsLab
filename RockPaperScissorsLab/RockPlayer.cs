using System;
using System.Collections.Generic;
using System.Text;

namespace RockPaperScissorsLab
{
    class RockPlayer : Player
    {

        public RockPlayer () : base("Rock Player")
        {
            
        }
        public override RPS GenerateRPS()
        {
            return RPS.rock;
        }
    }
}
