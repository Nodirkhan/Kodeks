using Kodeks.TelegramBot.Business.Interface;
using Kodeks.TelegramBot.Business.Services;
using Kodeks.TelegramBot.Domain.Consts;
using Kodeks.TelegramBot.Domain.Enum;
using Kodeks.TelegramBot.Domain.Model;
using Kodeks.TelegramBot.Infrastructure.Repository;
using Telegram.Bot;

namespace Kodeks.TelegramBot.Business.Commands
{
    internal class StartCommand : Command
    {
        private UserRepositoryAsync userRepository;
        private Domain.Entities.User user { get; set; }
        public override Command SetRequestParams(ReaquestParametres requestParams)
        {
            this.user = new Domain.Entities.User();
            this.userRepository = new UserRepositoryAsync();
            return base.SetRequestParams(requestParams);
        }
        public override async Task Execute(ITelegramBotClient client, long userId)
        {
            await client.SendTextMessageAsync(
                    chatId: userId,
                    text: Messages.hello
                    );

            user = await userRepository
                .FindByConditionAsync(u => u.Id == userId);

            if (user == null)
            {
                user = new Domain.Entities.User();
                user.Id = userId;
                user.Position = UserPosition.subscribe;
                user.Username = this.requestParams.Message.Chat.Username;
                requestParams.User = user;

                await userRepository.InsertAsync(user);

                // Send list of channels
                await CommandFactory.Instance
                    .GetCommand(CommandWords.show_channel).Execute(client, userId);
            }

        }
    }
}
