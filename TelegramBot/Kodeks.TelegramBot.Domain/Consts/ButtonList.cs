namespace Kodeks.TelegramBot.Domain.Consts
{
    public class ButtonList
    {
        public static Dictionary<string, string> MenuList = new();
        public static Dictionary<string, string> GetMenu()
        {
            if (MenuList.Count > 0) 
                return MenuList;
            else
            {
                MenuList.Add(CommandWords.show_kodeks, "Kodekslar");
                MenuList.Add(CommandWords.about_us, "Biz haqimizda");
                return MenuList;
            }
        }
    }
}
