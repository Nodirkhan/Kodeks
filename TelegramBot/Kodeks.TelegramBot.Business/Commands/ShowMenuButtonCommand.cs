using Kodeks.TelegramBot.Business.Interface;
using Kodeks.TelegramBot.Business.ReplyMarkups;
using Kodeks.TelegramBot.Domain.Consts;
using Kodeks.TelegramBot.Domain.Model;
using Telegram.Bot;

namespace Kodeks.TelegramBot.Business.Commands
{
    internal class ShowMenuButtonCommand : Command
    {
        public override async Task Execute(ITelegramBotClient client, long userId)
        {
            await client.SendTextMessageAsync(
                chatId: userId,
                text: Messages.show_menu,
                replyMarkup: ReplyMarkupService.SendMenu(ButtonList.GetMenu())
                );
        }
    }
}
