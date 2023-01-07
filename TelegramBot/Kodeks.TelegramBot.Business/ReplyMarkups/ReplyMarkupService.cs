using Kodeks.TelegramBot.Domain.Consts;
using Kodeks.TelegramBot.Domain.Entities;
using Telegram.Bot.Types.ReplyMarkups;

namespace Kodeks.TelegramBot.Business.ReplyMarkups
{
    internal class ReplyMarkupService
    {
        public static IReplyMarkup OptionsOfChannel(string checkerbutton)
        {
            var rows = new List<InlineKeyboardButton[]>();

            foreach (var channel in ChannelLists.Channels)
            {
                rows.Add(new InlineKeyboardButton[]
                {
                    InlineKeyboardButton.WithUrl(channel.Name, "https://t.me//" + channel.Link)
                });
            }

            rows.Add(new InlineKeyboardButton[]
            {
                InlineKeyboardButton.WithCallbackData(checkerbutton, CommandWords.verify_subscribe)
            });

            return new InlineKeyboardMarkup(rows);
        }

        public static IReplyMarkup SendContact()
        {
            return new ReplyKeyboardMarkup(new KeyboardButton[]
            {
                KeyboardButton.WithRequestContact("Contact")
            });
        }
        public static IReplyMarkup SendMenu(Dictionary<string, string> buttonList)
        {
            var rows = new List<InlineKeyboardButton[]>();
            var cols = new List<InlineKeyboardButton>();
            foreach (var button in buttonList)
            {
                if (cols.Count == 2)
                {
                    rows.Add(cols.ToArray());
                    cols.Clear();
                    cols.Add(InlineKeyboardButton
                        .WithCallbackData(text: button.Value, callbackData: button.Key));
                }
                else
                {
                    cols.Add(InlineKeyboardButton
                        .WithCallbackData(text: button.Value, callbackData: button.Key));
                }
            }
            if (cols.Count > 0)
            {
                rows.Add(cols.ToArray());
            }
            return new InlineKeyboardMarkup(rows);
        }

        public static InlineKeyboardMarkup SendKodeks(Dictionary<string, string> buttonList)
        {
            var rows = new List<InlineKeyboardButton[]>();
            var cols = new List<InlineKeyboardButton>();
            int i = 1;
            foreach (var button in buttonList)
            {
                if (cols.Count == 5)
                {
                    rows.Add(cols.ToArray());
                    cols.Clear();
                    cols.Add(InlineKeyboardButton
                        .WithCallbackData(text: i.ToString(),
                        callbackData: CommandWords.kodeks + "," + button.Key));
                    i++;
                }
                else
                {
                    cols.Add(InlineKeyboardButton
                        .WithCallbackData(text: i.ToString(),
                         callbackData: CommandWords.kodeks + "," + button.Key));
                    i++;
                }
            }
            if (cols.Count > 0)
            {
                rows.Add(cols.ToArray());
            }
            return new InlineKeyboardMarkup(rows);
        }
        public static InlineKeyboardMarkup SendBaseEntity(IEnumerable<BaseEntity> enitities,
            string prevPage, string nextPage, string datatype)
        {
            var rows = new List<InlineKeyboardButton[]>();
            var cols = new List<InlineKeyboardButton>();
            int i = 1;
            foreach (var entity in enitities)
            {
                if (cols.Count == 5)
                {
                    rows.Add(cols.ToArray());
                    cols.Clear();
                    cols.Add(InlineKeyboardButton
                        .WithCallbackData(text: i.ToString(),
                        callbackData: datatype + "," + entity.Id.ToString()));
                    i++;
                }
                else
                {
                    cols.Add(InlineKeyboardButton
                        .WithCallbackData(text: i.ToString(),
                        callbackData: datatype + "," + entity.Id.ToString()));
                    i++;
                }
            }
            if (cols.Count > 0)
            {
                rows.Add(cols.ToArray());
            }
            cols.Clear();
            cols.Add(InlineKeyboardButton.WithCallbackData(text: "⬅️", callbackData: prevPage));
            cols.Add(InlineKeyboardButton.WithCallbackData(text: "📖", callbackData: CommandWords.show_menu+","+Guid.NewGuid().ToString()));
            cols.Add(InlineKeyboardButton.WithCallbackData(text: "➡️", callbackData: nextPage));
            rows.Add(cols.ToArray());
            return new InlineKeyboardMarkup(rows);
        }

        public static InlineKeyboardMarkup SendCurrentKodeks(string kodeksId)
        {
            return new InlineKeyboardMarkup(new InlineKeyboardButton[]
           {
                InlineKeyboardButton.WithCallbackData("📖", callbackData: CommandWords.show_menu),
                InlineKeyboardButton.WithCallbackData("🏛", callbackData: CommandWords.kodeks + "," +kodeksId ),
           });
        }
    }
}
