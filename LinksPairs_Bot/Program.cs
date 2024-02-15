using System;
using System.Threading.Channels;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace LinksPairs_Bot
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new TelegramBotClient("6940551975:AAG7MajsHho9ANqdQutFi1v1VkXJEDMmoeM");
            client.StartReceiving(Update, Error);
            Console.ReadLine();
        }

        async static Task Update(ITelegramBotClient botClient, Update update, CancellationToken token)
        {
            var message = update.Message;
            Console.WriteLine($"{message.Chat.FirstName} | {message.Text}");
            if (message.Text != null && message.Text.ToLower() == "привіт")
            {
                await botClient.SendTextMessageAsync(message.Chat.Id, "Привіт");
                return;
            }

            if (message.Photo != null)
            {
                await botClient.SendTextMessageAsync(message.Chat.Id, "Норм фото, но краще документ!");
                return;
            }
            
        }

        private static Task Error(ITelegramBotClient arg1, Exception arg2, CancellationToken arg3)
        {
            Console.WriteLine($"Error: {arg2.Message}");
            return Task.CompletedTask;
        }
    }
}

