using Kodeks.TelegramBot.Business.Services;
using System.ComponentModel.Design;
using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace Kodeks.TelegramBot.Bot
{
    public static class UpdateHandlers
    {
        public static async Task PollingErrorHandler(
           ITelegramBotClient botClient,
           Exception exception,
           CancellationToken cancellationToken)
        {
            var errorMessage = exception switch
            {
                ApiRequestException apiRequestException => $"Telegram Api Error:\n" +
                $"[{apiRequestException.ErrorCode}]" +
                $"{apiRequestException.Message}",
                _ => exception.ToString()
            };
            Console.WriteLine(errorMessage);
            await Task.CompletedTask;
        }
        public static async Task HandleUpdateAsync(ITelegramBotClient botClient,
            Update update,
            CancellationToken cancellationToken)
        {
            var handler = update.Type switch
            {
                UpdateType.Message => BotOnMessageReceived(botClient, update.Message!),
                UpdateType.CallbackQuery => BotOnCallBackQueryReceived(botClient, update.CallbackQuery!),
                _ => null
            };

            if (handler is null)
                return;

            await handler;
         }
        private static async Task BotOnMessageReceived(ITelegramBotClient botClient, Message message)
        {
            await new ManageCommand(botClient)
               .ReplyMessageAsync(message);
        }
        private static async Task BotOnCallBackQueryReceived(ITelegramBotClient botclient, CallbackQuery callbackQuery)
        {
            await new ManageCommand(botclient)
                .ReplyCallbackQueryAsync(callbackQuery);
        }

    }
}