using System;
using Telegram.Bot.Types;

namespace Kodeks.TelegramBot.Domain.Model
{
    public class ReaquestParametres
    {
        public Entities.User User { get; set; }
        public CallbackQuery CallbackQuery { get; set; }
        public Message Message { get; set; }
        public string[] data { get; set; }
    }
}
