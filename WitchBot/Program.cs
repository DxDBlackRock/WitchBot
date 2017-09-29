using Discord;
using Discord.Commands;
using Discord.WebSocket;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace WitchBot
{
    class Program
    {
        private CommandService commands;
        private DiscordSocketClient client;
        private IServiceProvider services;

        static void Main(string[] args)
            => new Program().MainAsync().GetAwaiter().GetResult();

        public async Task MainAsync()
        {
            client = new DiscordSocketClient();
            commands = new CommandService();

            string token = "MzYzMzk4NTYxODM4MjY4NDI2.DLAtDA.V-55Rq5-X-qCqu_-5caRyyM6Szs";

            services = new ServiceCollection()
                .BuildServiceProvider();

            await InstallCommands();

            await client.LoginAsync(TokenType.Bot, token);
            await client.StartAsync();

            await Task.Delay(-1);

        }

        private async Task MessageReceived(SocketMessage message)
        {
            if (message.Content == "!gavgav")
            {
                await message.Channel.SendMessageAsync("Шота царь псов ");
            }
        }

        private async Task InstallCommands()
        {
            client.MessageReceived += HandleCommand;

            await commands.AddModulesAsync(Assembly.GetEntryAssembly());
        }

        private async Task HandleCommand(SocketMessage messageParam)
        {
            var message = messageParam as SocketUserMessage;
            if (message == null) return;
            // Create a number to track where the prefix ends and the command begins
            int argPos = 0;
            // Determine if the message is a command, based on if it starts with '!' or a mention prefix
            if (!(message.HasCharPrefix('!', ref argPos) || message.HasMentionPrefix(client.CurrentUser, ref argPos))) return;
            // Create a Command Context
            var context = new CommandContext(client, message);
            // Execute the command. (result does not indicate a return value, 
            // rather an object stating if the command executed successfully)
            var result = await commands.ExecuteAsync(context, argPos, services);
            if (!result.IsSuccess)
                await context.Channel.SendMessageAsync(result.ErrorReason);
        }

    }
}
