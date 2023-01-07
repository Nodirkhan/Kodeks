
namespace KodeksReaderPostgre.Model
{
    public class Bob : BaseEntity
    {
        public float Number { get; set; }
        public string Title { get; set; }
        public int Count { get; set; }
        public virtual ICollection<Modda> Moddalar { get; set; }
        public Bob()
        {
            Moddalar = new List<Modda>();
        }

    }
}
