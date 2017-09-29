using Discord;
using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WitchBot.Games;

namespace WitchBot.Modules
{
    public class TwentyOneModule : ModuleBase
    {
        [Command("TwentyOne-start"),Summary("TwentyOne start")]
        public async Task Start()
        {
            TwentyOne.GetInstance().isPlaying = true;

            await ReplyAsync("Начало регистрации игроков");
        }

        [Command("TwentyOne-stop"), Summary("TwentyOne stop")]
        public async Task Stop()
        {
            TwentyOne.GetInstance().isPlaying = false;
            TwentyOne.GetInstance().users.Clear();

            await ReplyAsync("Остановка игры");
        }

        [Command("TwentyOne"), Summary("TwentyOne info")]
        public async Task Info()
        {
            await ReplyAsync("Игра до 21");
        }

        [Command("TwentyOne-join"), Summary("TwentyOne start")]
        public async Task Join()
        {
            if (!TwentyOne.GetInstance().isPlaying)
                return;
            if(!TwentyOne.GetInstance().users.Any(x => x.Id == Context.User.Id))
            {
                TwentyOne.GetInstance().users.Add(Context.User);
            }
            
        }
    }
}
