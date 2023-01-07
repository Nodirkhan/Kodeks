using Kodeks.TelegramBot.Business.Interface;
using Kodeks.TelegramBot.Business.Services;
using Kodeks.TelegramBot.Domain.Consts;
using Kodeks.TelegramBot.Domain.Model;
using Kodeks.TelegramBot.Infrastructure.Repository;
using Telegram.Bot;

namespace Kodeks.TelegramBot.Business.Commands
{
    internal class ModifyFullNameCommand : Command
    {
        private UserRepositoryAsync userRepository;

        public override Command SetRequestParams(ReaquestParametres requestParams)
        {
            this.userRepository = new UserRepositoryAsync();
            return base.SetRequestParams(requestParams);
        }
        public override async Task Execute(ITelegramBotClient client, long userId)
        {
            requestParams.User.FullName = requestParams.Message.Text;
            requestParams.User.Position = Domain.Enum.UserPosition.modify_contact_number;
            await userRepository.UpdateAsync(requestParams.User);

            await CommandFactory.Instance
                .GetCommand(CommandWords.ask_contact_number)
                .SetRequestParams(requestParams)
                .Execute(client,userId);
        }
    }
}
