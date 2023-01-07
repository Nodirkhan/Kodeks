namespace KodeksReaderPostgre.Model
{
    public class Modda : BaseEntity
    {
        public float Number { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Descrition { get; set; }
    }
}
