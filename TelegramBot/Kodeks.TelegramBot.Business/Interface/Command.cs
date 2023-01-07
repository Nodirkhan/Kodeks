using Kodeks.TelegramBot.Domain.Model;
using Telegram.Bot;

namespace Kodeks.TelegramBot.Business.Interface
{
    public abstract class Command
    {
        protected ReaquestParametres requestParams { get; set; }
        public abstract Task Execute(ITelegramBotClient client, long userId);
        public virtual Command SetRequestParams(ReaquestParametres requestParams)
        {
            this.requestParams = requestParams;
            return this;
        }
    }
}
