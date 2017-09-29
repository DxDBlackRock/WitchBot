using Discord;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WitchBot.Games
{
    public class TwentyOne
    {
        private static TwentyOne instance;
        public bool isPlaying = false;
        public List<IUser> users;
        
        public TwentyOne()
        {
            users = new List<IUser>();
        }

        public static TwentyOne GetInstance()
        {
            if (instance == null)
                instance = new TwentyOne();
            return instance;
        }
    }
}
