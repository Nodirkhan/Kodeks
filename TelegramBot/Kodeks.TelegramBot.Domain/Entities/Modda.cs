namespace Kodeks.TelegramBot.Domain.Entities
{
    public class Modda : BaseEntity
    {
        public float Number { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Descrition { get; set; }

        public Guid BobId { get; set; }
        public Bob Bob { get; set; }
        public Guid KodeksId { get; set; }
        public Kodeks Kodeks { get; set; }
    }
}
