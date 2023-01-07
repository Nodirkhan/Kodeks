using Kodeks.TelegramBot.Business.Interface;
using Kodeks.TelegramBot.Business.Services;
using Kodeks.TelegramBot.Domain.Consts;
using Kodeks.TelegramBot.Domain.Model;
using Kodeks.TelegramBot.Infrastructure.Repository;
using Telegram.Bot;
using Telegram.Bot.Types.ReplyMarkups;

namespace Kodeks.TelegramBot.Business.Commands
{
    internal class ModifyContactCommand : Command
    {
        private UserRepositoryAsync userRepository;
        private long userId;
        private ITelegramBotClient client;

        public override Command SetRequestParams(ReaquestParametres requestParams)
        {
            this.requestParams = requestParams;
            this.userRepository = new UserRepositoryAsync();
            return base.SetRequestParams(requestParams);
        }
        public override async Task Execute(ITelegramBotClient client, long userId)
        {
            this.userId = userId;
            this.client = client;
            string contact = requestParams.Message.Contact?.PhoneNumber;
            if(contact is not null)
            {
                await ModifyUserContact(contact);
            }
            else
            {
                contact =  requestParams.Message.Text;
                if (contact.Contains("+") && contact.Length == 13)
                {
                    await ModifyUserContact(contact);
                    return;
                }
                else if (!contact.Contains("+") && contact.Length == 12)
                {
                    long number;
                    bool isPhoneNumber = long.TryParse(contact, out number);

                    if (isPhoneNumber)
                    {
                        await ModifyUserContact("+" + contact);
                        return;
                    }
                }
                else if(!contact.Contains("+") && contact.Length == 9)
                {
                    await ModifyUserContact("+998" + contact);
                    return;
                }
                else
                {
                    await CommandFactory.Instance
                            .GetCommand(CommandWords.ask_contact_number)
                            .SetRequestParams(requestParams)
                            .Execute(client, userId);

                    return;
                }
            }
        }

        private async Task ModifyUserContact(string contact)
        {
            requestParams.User.Position = Domain.Enum.UserPosition.show_menu;
            requestParams.User.ContactNumber = contact;
            await userRepository.UpdateAsync(requestParams.User);

            await client.SendTextMessageAsync(
                chatId: userId,
                text: Messages.successful,
                replyMarkup:new ReplyKeyboardRemove()
                ); ;

            await CommandFactory.Instance
                .GetCommand(CommandWords.show_menu)
                .SetRequestParams(requestParams)
                .Execute(client, userId);
        }
    }
}
