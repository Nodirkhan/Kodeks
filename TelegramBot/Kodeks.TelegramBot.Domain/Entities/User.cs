using Kodeks.TelegramBot.Domain.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kodeks.TelegramBot.Domain.Entities
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long Id { get; set; }

        public string FullName { get; set; }

        public string Username { get; set; }

        public UserPosition Position { get; set; }

        public string KodeksId { get; set; }

        public bool IsSubscriber { get; set; } = false;

        public string ContactNumber { get; set; }
    }
}
