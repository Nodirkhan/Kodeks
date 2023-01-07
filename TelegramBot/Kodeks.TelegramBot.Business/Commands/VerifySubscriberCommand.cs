using Kodeks.TelegramBot.Business.Interface;
using Kodeks.TelegramBot.Business.Services;
using Kodeks.TelegramBot.Domain.Consts;
using Kodeks.TelegramBot.Domain.Enum;
using Kodeks.TelegramBot.Domain.Model;
using Kodeks.TelegramBot.Infrastructure.Repository;
using Telegram.Bot;

namespace Kodeks.TelegramBot.Business.Commands
{
    internal class VerifySubscriberCommand : Command
    {
        private UserRepositoryAsync userRepository;

        public override Command SetRequestParams(ReaquestParametres requestParams)
        {
            this.userRepository = new UserRepositoryAsync();
            return base.SetRequestParams(requestParams);
        }
        public override async Task Execute(ITelegramBotClient client, long userId)
        {
            if(requestParams.CallbackQuery is null )
            {
                await CommandFactory
                        .Instance.GetCommand(CommandWords.show_channel)
                        .Execute(client, userId);
                return;
            }
            foreach (var channel in ChannelLists.Channels)
            {
                var subscriber = await client
                    .GetChatMemberAsync("@" + channel.Link, userId);

                if (subscriber.Status.ToString() == "Left")
                {
                    requestParams.User.IsSubscriber = false;
                    await userRepository.UpdateAsync(requestParams.User);
                    await CommandFactory
                        .Instance.GetCommand(CommandWords.show_channel)
                        .Execute(client, userId);

                    return;
                }
            }
            requestParams.User.IsSubscriber = true;
            requestParams.User.Position = string
                .IsNullOrEmpty(requestParams.User.FullName) == true ? 
                UserPosition.full_name : 
                UserPosition.show_menu;

            await userRepository.UpdateAsync(requestParams.User);

            await client.EditMessageTextAsync(
                    chatId: userId,
                    messageId: requestParams.CallbackQuery.Message.MessageId,
                    text: Messages.successful
                    );

            await CommandFactory.Instance
                .GetCommand(requestParams.User.Position.ToString())
                .SetRequestParams(requestParams)
                .Execute(client, userId);
                

        }
    }
}