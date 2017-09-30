using Discord;
using System;
using Discord.Commands;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WitchBot.Games.TwentyOneGame;
using WitchBot.Extensions;

namespace WitchBot.Games.TwentyOneGame
{
    public class TwentyOne
    {
        private static TwentyOne instance;
        public bool isPlaying = false;
        public bool isStarted = false;
        public List<Player> users;
        public Player currentUser;

        public List<Dictionary<int,string>> cards;
        
        public TwentyOne()
        {
            users = new List<Player>();
            cards = new List<Dictionary<int, string>>();
        }

        public static TwentyOne GetInstance()
        {
            if (instance == null)
                instance = new TwentyOne();
            return instance;
        }

        public void Start()
        {
            currentUser = users.First();
        }

        public void Hold()
        {
            currentUser = users.NextOf(currentUser);
        }

        public void Draw()
        {

        }
    }
}
