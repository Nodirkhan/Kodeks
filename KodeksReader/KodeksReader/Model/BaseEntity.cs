using MongoDB.Bson.Serialization.Attributes;

namespace KodeksReader.Model
{
    public class BaseEntity
    {
        [BsonId]
        public string Id { get; set; }

        [BsonElement]
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
    }
}
