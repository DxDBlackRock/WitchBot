using Discord;
using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WitchBot
{
    class Program
    {
        static void Main(string[] args)
            => new Program().MainAsync().GetAwaiter().GetResult();

        private DiscordSocketClient _client;

        public async Task MainAsync()
        {
            _client = new DiscordSocketClient();

            _client.Log += Log;
            _client.MessageReceived += MessageReceived;
            _client.Ready += Ready;

            string token = "MzYzMzk4NTYxODM4MjY4NDI2.DLAtDA.V-55Rq5-X-qCqu_-5caRyyM6Szs";
            await _client.LoginAsync(TokenType.Bot, token);
            await _client.StartAsync();

            await Task.Delay(-1);

        }

        private Task Log(LogMessage msg)
        {
            Console.WriteLine(msg.ToString());
            return Task.CompletedTask;
        }

        private async Task Ready (SocketTextChannel channel)
        {
            await channel.SendMessageAsync("Ведьмочка");
        }

        private async Task MessageReceived(SocketMessage message)
        {
            if (message.Content == "!gavgav")
            {
                await message.Channel.SendMessageAsync("Шота царь псов ");
            }
        }

    }
}
