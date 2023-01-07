using Kodeks.TelegramBot.Business.Interface;
using Kodeks.TelegramBot.Business.ReplyMarkups;
using Kodeks.TelegramBot.Business.Services;
using Kodeks.TelegramBot.Domain.Consts;
using Kodeks.TelegramBot.Domain.Entities;
using Kodeks.TelegramBot.Domain.Enum;
using Kodeks.TelegramBot.Domain.Model;
using Kodeks.TelegramBot.Infrastructure.Repository;
using System.Text;
using Telegram.Bot;

namespace Kodeks.TelegramBot.Business.Commands
{
    internal class ShowSingleModdaCommand : Command
    {
        private UserRepositoryAsync userRepository;
        private ModdaRepositoryAsync moddaRepository;

        public override Command SetRequestParams(ReaquestParametres requestParams)
        {
            this.userRepository = new UserRepositoryAsync();
            this.moddaRepository = new ModdaRepositoryAsync();
            return base.SetRequestParams(requestParams);
        }
        public override async Task Execute(ITelegramBotClient client, long userId)
        {
            string kodeksId = requestParams.data[1];

            Guid GuidKodeksId;
            bool isKodeksId = Guid.TryParse(kodeksId, out GuidKodeksId);
            if (!isKodeksId)
            {
                await CommandFactory.Instance
                    .GetCommand(CommandWords.show_menu)
                    .SetRequestParams(requestParams)
                    .Execute(client, userId);
                return;
            }
            var modda = await moddaRepository.GetModdaById(GuidKodeksId);

            StringBuilder content = new StringBuilder();
            content.Append(modda.Title);
            content.Append(modda.Content);

            await client.EditMessageTextAsync(
                chatId: requestParams.CallbackQuery.Message.Chat,
                text: content.ToString(),
                messageId: requestParams.CallbackQuery.Message.MessageId,
                replyMarkup: ReplyMarkupService.SendCurrentKodeks(requestParams.User.KodeksId)
                );
        }
    }
}
