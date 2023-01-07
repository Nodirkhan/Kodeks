namespace Kodeks.TelegramBot.Domain.Entities
{
    public class Bob : BaseEntity
    {
        public float Number { get; set; }
        public string Title { get; set; }
        public int Count { get; set; }

        public Guid BolimId { get; set; }
        public Bolim Bolim { get; set; }

        public Guid KodeksId { get; set; }
        public Kodeks Kodeks { get; set; }
        public virtual ICollection<Modda> Moddalar { get; set; }
        public Bob()
        {
            Moddalar = new List<Modda>();
        }
    }
}
