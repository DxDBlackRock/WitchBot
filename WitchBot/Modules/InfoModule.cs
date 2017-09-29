using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WitchBot.Modules
{
    public class InfoModule : ModuleBase
    {
        [Command("commands"), Summary("Avaliable commands")]
        public async Task ShowCommands()
        {
            // ReplyAsync is a method on ModuleBase
            StringBuilder echo = new StringBuilder();
            echo.AppendLine("> List of commands <");
            echo.AppendLine("!twentyone");
            echo.AppendLine("2- 32");
            await ReplyAsync(echo.ToString());
        }
    }
}
