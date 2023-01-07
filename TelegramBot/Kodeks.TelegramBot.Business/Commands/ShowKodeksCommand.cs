using Kodeks.TelegramBot.Business.Interface;
using Kodeks.TelegramBot.Business.ReplyMarkups;
using Kodeks.TelegramBot.Business.Services;
using Kodeks.TelegramBot.Domain.Consts;
using Kodeks.TelegramBot.Domain.Enum;
using Kodeks.TelegramBot.Domain.Model;
using Kodeks.TelegramBot.Infrastructure.Repository;
using System.Text;
using Telegram.Bot;

namespace Kodeks.TelegramBot.Business.Commands
{
    internal class ShowKodeksCommand : Command
    {
        private UserRepositoryAsync userRepository;

        public override Command SetRequestParams(ReaquestParametres requestParams)
        {
            this.userRepository = new UserRepositoryAsync();
            return base.SetRequestParams(requestParams);
        }
        public override async Task Execute(ITelegramBotClient client, long userId)
        {
            var kodekses = KodeksFactory.Instance.GetKodeks();
            StringBuilder content = new StringBuilder();
            content.Append(Messages.show_menu);
            int i = 1;
            foreach(var kodeks in kodekses)
            {
                content.Append($"\n{i}. {kodeks.Value}");
            }
            await client.EditMessageTextAsync(
                chatId: requestParams.CallbackQuery.Message.Chat,
                text: content.ToString(),
                messageId: requestParams.CallbackQuery.Message.MessageId,
                replyMarkup: ReplyMarkupService.SendKodeks(kodekses)
                );
        }
    }
}
