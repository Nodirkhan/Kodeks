using Kodeks.TelegramBot.Business.Interface;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace Kodeks.TelegramBot.Business.Services
{
    public class ManageCommand
    {
        private Command command;
        private TableCommand tableCommand;
        private readonly ITelegramBotClient client;
        public ManageCommand(ITelegramBotClient client)
        {
            this.client = client;
            this.tableCommand = new TableCommand();
        }
        public async Task ReplyMessageAsync(Message message)
        {
            this.command = await tableCommand
                .GetCommandForTextMessage(message);

            await InvokeAsync(client, message.Chat.Id);
        }
        public async Task ReplyCallbackQueryAsync(CallbackQuery query)
        {
            this.command = await tableCommand
                .GetCommandForCallBackQuery(query);
            
            await InvokeAsync(client,query.From.Id);
        }
        private async Task InvokeAsync(ITelegramBotClient client, long userId)
        {
            if(command != null)
            {
                await this.command.Execute(client, userId);
            }
        }
    }
}
