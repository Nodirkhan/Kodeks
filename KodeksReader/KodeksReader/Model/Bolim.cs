using MongoDB.Bson.Serialization.Attributes;
using System.Security.Permissions;

namespace KodeksReader.Model
{
    [BsonIgnoreExtraElements]
    public class Bolim : BaseEntity
    {
        public string Title { get; set; }
        public int Number { get; set; }
        public int Count { get; set; }
        public Dictionary<string, string> Boblar { get; set; } = new();
    }
}
