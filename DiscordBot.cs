using System;
using System.Threading.Tasks;
using Discord;
using Discord.WebSocket;

namespace DiscordBot
{
    class Program
    {
        DiscordSocketClient Client;
        static void Main(string[] args)
        {
            new Program().MainAsync().GetAwaiter().GetResult();
        }

        private async Task MainAsync()
        {
            Client = new DiscordSocketClient();
            Client.MessageReceived += CommandHandler;

            var Token = "OTYyOTIxODUwNzkzNTA0Nzg4.YlOk2w.M4NrFyvMvcPcXIV3gS9j_NdfFjM";
            await Client.LoginAsync(TokenType.Bot, Token);
            await Client.StartAsync();

            Console.ReadLine();
        }

        private Task CommandHandler(SocketMessage arg)
        {
            throw new NotImplementedException();
        }
    }
}
