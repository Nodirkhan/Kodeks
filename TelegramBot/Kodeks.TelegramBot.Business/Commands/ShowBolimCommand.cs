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
    public class ShowBolimCommand : Command
    {
        private UserRepositoryAsync userRepository;

        public BolimRepositoryAsync bolimRepository { get; private set; }

        public override Command SetRequestParams(ReaquestParametres requestParams)
        {
            this.userRepository = new UserRepositoryAsync();
            this.bolimRepository = new BolimRepositoryAsync();
            return base.SetRequestParams(requestParams);
        }
        public override async Task Execute(ITelegramBotClient client, long userId)
        {
            int prevPage;
            int nextPage;

            if (!SetPaginationParams(out prevPage, out nextPage, out Guid GuidKodeksId))
            {
                await CommandFactory.Instance
                        .GetCommand(CommandWords.show_menu)
                        .SetRequestParams(requestParams)
                        .Execute(client, userId);

                return;
            }
            if(requestParams.User.KodeksId != GuidKodeksId.ToString())
            {
                requestParams.User.KodeksId = GuidKodeksId.ToString();
                await userRepository.UpdateAsync(requestParams.User);
            }
            
            var bolimlar = await bolimRepository
                .GetPageListAsync(GuidKodeksId, pageNumber: prevPage);

            StringBuilder content = new StringBuilder();
            content.Append(Messages.show_menu);
            int i = 1;
            foreach (var bolim in bolimlar)
            {
                content.Append($"\n{i}. {bolim.Title}");
                i++;
            }
            nextPage = i > 10 ? nextPage : 0;
            prevPage = nextPage == 0 ? 0 : prevPage;
            string prev = CommandWords.kodeks + "," + prevPage + "," + GuidKodeksId;
            string next = CommandWords.kodeks + "," + nextPage + "," + GuidKodeksId;

            await client.EditMessageTextAsync(
                chatId: requestParams.CallbackQuery.Message.Chat,
                text: content.ToString(),
                messageId: requestParams.CallbackQuery.Message.MessageId,
                replyMarkup: ReplyMarkupService.SendBaseEntity(bolimlar, prev, next, CommandWords.bolim)
                );
        }

        private bool SetPaginationParams(out int prevPage, out int nextPage, out Guid GuidKodeksId)
        {
            bool isKodeksId = Guid.TryParse(requestParams.data[1], out GuidKodeksId);
            if (!isKodeksId)
            {
                int number;

                if (int.TryParse(requestParams.data[1], out number))
                {
                    prevPage = number;
                    nextPage = prevPage + 1;
                    GuidKodeksId = Guid.Parse(requestParams.data[2]);
                    return true;
                }
                else
                {

                    prevPage = 0;
                    nextPage = 1;
                    return false;
                }
            }
            prevPage = 0;
            nextPage = 1;
            return true;
        }
    }
}
