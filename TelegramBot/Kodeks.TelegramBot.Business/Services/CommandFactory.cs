using Kodeks.TelegramBot.Business.Commands;
using Kodeks.TelegramBot.Business.Interface;
using Kodeks.TelegramBot.Domain.Consts;

namespace Kodeks.TelegramBot.Business.Services
{
    public class CommandFactory
    {
        private static Dictionary<string, Command> commands { get; set; }

        private CommandFactory()
        {
            commands = new Dictionary<string, Command>();
            Register();
        }

        public static CommandFactory Instance
        {
            get { return Nested.commandFactory; }
        }

        public Command GetCommand(string key) =>
            commands.ContainsKey(key) ? commands[key] : null;
        
        private void Register()
        {
            commands.Add(CommandWords.start, new StartCommand());
            commands.Add(CommandWords.show_channel, new ShowChannelsCommand());
            commands.Add(CommandWords.ask_contact_number, new AskContactNumberCommand());
            commands.Add(CommandWords.modify_contact_number, new ModifyContactCommand());
            commands.Add(CommandWords.ask_full_name, new AskFullNameCommand());
            commands.Add(CommandWords.modify_full_name, new ModifyFullNameCommand());
            commands.Add(CommandWords.verify_subscribe, new VerifySubscriberCommand());
            commands.Add(CommandWords.show_menu, new ShowMenuButtonCommand());
            commands.Add(CommandWords.show_kodeks, new ShowKodeksCommand());
            commands.Add(CommandWords.kodeks, new ShowBolimCommand());
            commands.Add(CommandWords.bolim, new ShowBobCommand());
            commands.Add(CommandWords.bob, new ShowModdaCommand());
            commands.Add(CommandWords.modda, new ShowSingleModdaCommand());
        }

        private class Nested
        {
            static Nested() { }
            internal static readonly CommandFactory commandFactory = new CommandFactory();
        }
    }
}
