using System;
using System.Timers;
using System.Text;
using System.Threading.Tasks;
using Discord;
using Discord.WebSocket;

namespace DiscordBot
{
    
    class Program
    {
        DiscordSocketClient? Client;
        System.Timers.Timer timer = new System.Timers.Timer() { Interval = 600000 };
        static int task = 1;
        static void Main(string[] args)
        {
            
            new Program().MainAsync().GetAwaiter().GetResult();
        }

        public static int GenerateRandomOddNumber()
        {
            Random rnd = new Random();

            int number = 0;
            while (number % 2 == 0)
            {
                if (number % 2 != 0)
                {
                    return number;
                }
                else
                {
                    number = rnd.Next(1, 10);
                }
            }
            return number;
            
        }

        private void SetTimer(SocketMessage msg)
        {
            timer.Start();
            timer.Elapsed += (o, e) =>
            {
                EnglishTasks(msg);
            };
        }

        private void StopTimer()
        {
            timer.Stop();
        }

        public static void EnglishTasks(SocketMessage msg)
        {
            string path = @"C:/Users/Степан/Desktop/Bot.txt";
            string line;
            int LineNumber = 1;
            int TaskNumber = GenerateRandomOddNumber();

            StreamReader sr = new StreamReader(path);

            line = sr.ReadLine();

            while (line != null)
            {
                if (TaskNumber == LineNumber)
                {
                    msg.Channel.SendMessageAsync($"Задание {task}");
                    ++task;
                    msg.Channel.SendMessageAsync(line);
                    line = sr.ReadLine();
                    ++LineNumber;
                    msg.Channel.SendMessageAsync(line);
                    break;
                }
                line = sr.ReadLine();
                ++LineNumber;
            }
            sr.Close();
        }
        private async Task MainAsync()
        {
            Client = new DiscordSocketClient();
            Client.MessageReceived += CommandHandler;
            Client.Log += Log;

            var Token = "OTYyOTIxODUwNzkzNTA0Nzg4.YlOk2w.w2aVDGjwDqjVSIvuqW8BubP20aU";
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
                            EnglishTasks(msg);
                            SetTimer(msg);
                            break;
                        }
                    case "!стоп":
                        {
                            StopTimer();
                            break;
                        }
                }
            }
            return Task.CompletedTask;

        }


    }
}
