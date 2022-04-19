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
            Client.Log += Log;

            var Token = "OTYyOTIxODUwNzkzNTA0Nzg4.YlOk2w.DMSk2oBM7aOkFHpUXhmNf5qS5iU";
            await Client.LoginAsync(TokenType.Bot, Token);
            await Client.StartAsync();

            Console.ReadLine();
        }
        private Task Log(LogMessage msg)
        {
            Console.WriteLine(msg.ToString());
            return Task.CompletedTask;
        }

        private Task CommandHandler(SocketMessage msg)
        {
            if (!msg.Author.IsBot)
            {
                switch (msg.Content)
                {
                    case "!help": 
                        {
                            msg.Channel.SendMessageAsync("1 - !Привет\n2 - !.\n3 - !.");
                            break;
                        }
                    case "!Привет":
                        {
                            msg.Channel.SendMessageAsync($"Привет, {msg.Author}");
                            break;
                        }
                }
            }
            return Task.CompletedTask;
            
        }

        
    }
}
лдд
