using System.Threading.Channels;

namespace Kodeks.TelegramBot.Domain.Consts
{

    public class ChannelLists
    {
        public class Channel
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Link { get; set; }

        }
        public static List<Channel> Channels { get; set; } = new List<Channel>()
        {
            new Channel
            {
                Id = 10,
                Name = "Channel: e-gov.uz 🔑",
                Link = "testVoterChannel "
            }
        };
    }
}
