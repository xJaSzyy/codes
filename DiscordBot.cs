using System;
using System.Text;
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

            var Token = "OTYyOTIxODUwNzkzNTA0Nzg4.YlOk2w.H2TC1MqirtTqsXvUjtL94Z2-BxU";
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
                            msg.Channel.SendMessageAsync("1 - !рус\n2 - !англ");
                            break;
                        }
                    case "!рус":
                        {
                            msg.Channel.SendMessageAsync($"Привет, {msg.Author}");
                            break;
                        }
                    case "!англ":
                        {
                            string path = @"C:/Users/Степан/Desktop/Bot.txt";
                            string line;
                            int LineNumber = 0;
                            Random rnd = new Random();
                            int TaskNumber = rnd.Next(1, 5); 

                            StreamReader sr = new StreamReader(path);
                                
                            line = sr.ReadLine();
                            LineNumber = 1;

                            while (line != null)
                            {
                                if (TaskNumber == LineNumber)
                                {
                                    msg.Channel.SendMessageAsync(line);
                                    break;
                                }
                                line = sr.ReadLine();
                                ++LineNumber;
                            }  
                            sr.Close();
                            break;
                        }
                }
            }
            return Task.CompletedTask;

        }


    }
}
