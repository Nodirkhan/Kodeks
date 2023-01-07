﻿using Kodeks.TelegramBot.Business.Interface;
using Kodeks.TelegramBot.Business.ReplyMarkups;
using Kodeks.TelegramBot.Business.Services;
using Kodeks.TelegramBot.Domain.Consts;
using Kodeks.TelegramBot.Domain.Enum;
using Kodeks.TelegramBot.Domain.Model;
using Kodeks.TelegramBot.Infrastructure.Repository;
using System.Text;
using Telegram.Bot;

namespace Kodeks.TelegramBot.Business.Commands
{
    internal class ShowModdaCommand : Command
    {
        private UserRepositoryAsync userRepository;
        private ModdaRepositoryAsync moddaRepository;

        public override Command SetRequestParams(ReaquestParametres requestParams)
        {
            this.userRepository = new UserRepositoryAsync();
            this.moddaRepository = new ModdaRepositoryAsync();
            return base.SetRequestParams(requestParams);
        }
        public override async Task Execute(ITelegramBotClient client, long userId)
        {
            if (!SetPaginationParams(out int prevPage, out int nextPage, out Guid GuidKodeksId))
            {
                await CommandFactory.Instance
                        .GetCommand(CommandWords.show_menu)
                        .SetRequestParams(requestParams)
                        .Execute(client, userId);

                return;
            }

            var moddalar = await moddaRepository.GetPageListAsync(GuidKodeksId);

            StringBuilder content = new StringBuilder();
            content.Append(Messages.show_menu);
            int i = 1;
            foreach (var modda in moddalar)
            {
                content.Append($"\n{i}. {modda.Title}");
                i++;
            }
            nextPage = i > 10 ? nextPage : 0;
            prevPage = nextPage == 0 ? 0 : prevPage;
            string prev = CommandWords.bob + "," + prevPage + "," + GuidKodeksId;
            string next = CommandWords.bob + "," + nextPage + "," + GuidKodeksId;

            await client.EditMessageTextAsync(
                chatId: requestParams.CallbackQuery.Message.Chat,
                text: content.ToString(),
                messageId: requestParams.CallbackQuery.Message.MessageId,
                replyMarkup: ReplyMarkupService.SendBaseEntity(moddalar,prev,next,CommandWords.modda)
                );
        }
        private bool SetPaginationParams(out int prevPage, out int nextPage, out Guid GuidKodeksId)
        {

            ///Kodeks Id ga ornatamiz currentId ni
            bool isKodeksId = Guid.TryParse(requestParams.data[1], out GuidKodeksId);
            if (!isKodeksId)
            {
                int number;

                if (int.TryParse(requestParams.data[1], out number))
                {
                    prevPage = number;
                    nextPage = prevPage + 1;
                    GuidKodeksId = Guid.Parse(requestParams.data[2]);
                    return true;
                }
                else
                {

                    prevPage = 0;
                    nextPage = 1;
                    return false;
                }
            }
            prevPage = 0;
            nextPage = 1;
            return true;
        }
    }
}
