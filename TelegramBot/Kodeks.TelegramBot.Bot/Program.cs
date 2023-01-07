using Kodeks.TelegramBot.Bot;
using Kodeks.TelegramBot.Domain.Consts;
using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types.Enums;

var bot = new TelegramBotClient(TelegramBotSettings.TOKEN);

var me = await bot.GetMeAsync();
Console.Title = me.Username ?? "My awesome Bot";

using var cts = new CancellationTokenSource();

var receiverOptions = new ReceiverOptions()
{
    AllowedUpdates = Array.Empty<UpdateType>(),
    ThrowPendingUpdates = false,
    
};

bot.StartReceiving(updateHandler: UpdateHandlers.HandleUpdateAsync,
                   pollingErrorHandler: UpdateHandlers.PollingErrorHandler,
                   receiverOptions: receiverOptions,
                   cancellationToken: cts.Token);

Console.WriteLine($"Start listening for @{me.Username}");
Console.ReadLine();

cts.Cancel();