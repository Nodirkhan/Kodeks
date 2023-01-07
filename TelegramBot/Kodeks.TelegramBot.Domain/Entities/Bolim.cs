namespace Kodeks.TelegramBot.Domain.Entities
{
    public class Bolim : BaseEntity
    {
        public string Title { get; set; }
        public float Number { get; set; }
        public int Count { get; set; }
        public Guid KodeksId { get; set; }
        public Kodeks Kodeks { get; set; }
        public virtual ICollection<Bob> Boblar { get; set; }
        public Bolim()
        {
            Boblar = new List<Bob>();
        }
    }
}
