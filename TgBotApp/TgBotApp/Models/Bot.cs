using System.Collections.Generic;
using System.Threading.Tasks;
using Telegram.Bot;
using TgBotApp.Models.Commands;

namespace TgBotApp.Models
{
    public static class Bot
    {
        private static TelegramBotClient client;
        private static List<Command> commandsList;

        public static IReadOnlyList<Command> Commands { get => commandsList.AsReadOnly(); }

        public static async Task<TelegramBotClient> Get()
        {
            if (client != null)
            {
                return client;
            }

            commandsList = new List<Command>();
            commandsList.Add(new HelloCommand());
            //ADD MORE COMMANDS

            client = new TelegramBotClient(TgBotSettings.Key);

            var hook = string.Format(TgBotSettings.Url, "api/message/update");
            await client.SetWebhookAsync(hook);


            return client;
        }
    }
}