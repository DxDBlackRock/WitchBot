using Discord;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WitchBot.Games.TwentyOneGame
{
    public class Player
    {
        public IUser user { get; set; }
        public int currentScore { get; set; }

        public Player(IUser user)
        {
            this.user = user;
            currentScore = 0;
        }
    }
}
