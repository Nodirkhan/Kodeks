using MongoDB.Bson.Serialization.Attributes;

namespace KodeksReader.Model
{
    [BsonIgnoreExtraElements]
    public class Kodeks : BaseEntity
    {
        public string Name { get; set; }
        public string Link { get; set; }
        public List<Bolim> Bolimlar { get; set; } = new();
        public List<Bob> Boblar { get; set; } = new();
        public List<Modda> Moddalar { get; set; } = new();

    }
}
