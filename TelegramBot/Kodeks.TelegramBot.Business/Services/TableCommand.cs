using Kodeks.TelegramBot.Business.Interface;
using Kodeks.TelegramBot.Domain.Consts;
using Kodeks.TelegramBot.Domain.Model;
using Kodeks.TelegramBot.Infrastructure.Repository;
using Telegram.Bot.Types;

namespace Kodeks.TelegramBot.Business.Services
{
    internal class TableCommand
    {
        private ReaquestParametres requestParametres;
        private UserRepositoryAsync userRepository;
        public TableCommand()
        {
            this.requestParametres = new ReaquestParametres();
            this.userRepository = new UserRepositoryAsync();
        }
        public async Task<Command> GetCommandForTextMessage(Message message)
        {
            requestParametres.Message = message;
            var userId = message.Chat.Id;
            var text = message.Text;
            this.requestParametres.User = await userRepository
                .FindByConditionAsync(u => u.Id == userId);

            if(requestParametres.User == null || text == CommandWords.start)
            {
                return CommandFactory.Instance
                    .GetCommand(CommandWords.start).SetRequestParams(requestParametres);
            }
            else if(requestParametres.User.Position > Domain.Enum.UserPosition.show_menu)
            {
                return null;
            }

            var command = CommandFactory.Instance
                .GetCommand(requestParametres.User.Position.ToString())
                .SetRequestParams(requestParametres);

            return command;
        }
        public async Task<Command> GetCommandForCallBackQuery(CallbackQuery callbackQuery)
        {
            this.requestParametres.CallbackQuery = callbackQuery;
            this.requestParametres.User = await userRepository
                .FindByConditionAsync(u => u.Id == callbackQuery.From.Id);

            if (requestParametres.User is null)
                return null;

            var command = CommandFactory.Instance
                .GetCommand(callbackQuery.Data)?
                .SetRequestParams(requestParametres);

            if(command == null)
            {
                var data = callbackQuery.Data.Split(",");
                requestParametres.data = data;
                command = CommandFactory.Instance
                .GetCommand(data[0])?
                .SetRequestParams(requestParametres);
            }

            return command;
        }
    }
}
