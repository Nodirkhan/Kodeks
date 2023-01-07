using Kodeks.TelegramBot.Business.Interface;
using Kodeks.TelegramBot.Domain.Consts;
using Kodeks.TelegramBot.Domain.Model;
using Kodeks.TelegramBot.Infrastructure.Repository;
using Telegram.Bot;

namespace Kodeks.TelegramBot.Business.Commands
{
    internal class AskFullNameCommand : Command
    {
        private UserRepositoryAsync userRepository;
        public override Command SetRequestParams(ReaquestParametres requestParams)
        {
            this.userRepository = new UserRepositoryAsync();
            return base.SetRequestParams(requestParams);
        }
        public override async Task Execute(ITelegramBotClient client, long userId)
        {
            requestParams.User.Position = Domain.Enum.UserPosition.modify_full_name;
            await this.userRepository.UpdateAsync(requestParams.User);

            await client.SendTextMessageAsync(
                chatId: userId,
                text: Messages.fullname
                );
        }
    }
}
