using Kodeks.TelegramBot.Business.Interface;
using Kodeks.TelegramBot.Business.ReplyMarkups;
using Kodeks.TelegramBot.Domain.Consts;
using Telegram.Bot;

namespace Kodeks.TelegramBot.Business.Commands
{
    internal class AskContactNumberCommand : Command
    {
        public override async Task Execute(ITelegramBotClient client, long userId)
        {
            await client.SendTextMessageAsync(
                chatId: userId,
                text: Messages.ask_contact_number,
                replyMarkup: ReplyMarkupService.SendContact()
                );
        }
    }
}
