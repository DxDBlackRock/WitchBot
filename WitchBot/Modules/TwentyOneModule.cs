using Discord;
using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WitchBot.Games;
using WitchBot.Games.TwentyOneGame;

namespace WitchBot.Modules
{
    public class TwentyOneModule : ModuleBase
    {
        [Command("TwentyOne-reg"),Summary("TwentyOne registation")]
        public async Task Reg()
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
            if (TwentyOne.GetInstance().isStarted)
                return;
            if (!TwentyOne.GetInstance().isPlaying)
                return;
            if(!TwentyOne.GetInstance().users.Any(x => x.user.Id == Context.User.Id))
            {
                TwentyOne.GetInstance().users.Add( new Player(Context.User));
            }
        }

        [Command("TwentyOne-start")]
        public async Task Start()
        {
            if (!TwentyOne.GetInstance().isPlaying)
                return;

            TwentyOne.GetInstance().Start();
           await ReplyAsync(TwentyOne.GetInstance().currentUser.user.Username + " Vote !");
        }

        public async Task Next()
        {
            await ReplyAsync(TwentyOne.GetInstance().currentUser.user.Username + " Vote !");
        }

        [Command("vote-hold")]
        public async Task Hold()
        {
            if (!TwentyOne.GetInstance().isPlaying)
                return;
            TwentyOne.GetInstance().Hold();
           await ReplyAsync(TwentyOne.GetInstance().currentUser.user.Username + " Vote !");
        }

        [Command("vote-draw")]
        public async Task Draw()
        {
            TwentyOne.GetInstance().Draw();
        }

    }
}
