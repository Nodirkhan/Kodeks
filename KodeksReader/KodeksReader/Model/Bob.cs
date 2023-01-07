using MongoDB.Bson.Serialization.Attributes;

namespace KodeksReader.Model
{
    [BsonIgnoreExtraElements]
    public class Bob : BaseEntity
    {
        public int Number { get; set; }
        public string Title { get; set; }
        public int Count { get; set; }
        public Dictionary<string, string> Moddalar { get; set; } = new();

    }
}
