namespace KodeksReaderPostgre.Model
{
    public class Kodeks : BaseEntity
    {
        public string Name { get; set; }
        public string Link { get; set; }
        public virtual ICollection<Bolim> Bolimlar { get; set; } 
        public virtual ICollection<Bob> Boblar { get; set; } 
        public virtual ICollection<Modda> Moddalar { get; set; }

        public Kodeks()
        {
            Bolimlar = new List<Bolim>();
            Boblar = new List<Bob>();
            Moddalar = new List<Modda>();
        }
    }
}
