using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace KodeksReader.Model
{
    [BsonIgnoreExtraElements]
    public class Modda : BaseEntity
    {
        public int Number { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Descrition { get; set; }
    }
}
