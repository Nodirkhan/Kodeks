using MongoDB.Driver;

namespace KodeksReader.Data
{
    public class ApplicationDbContext : IApplicationDbContext
    {
        private readonly IMongoDatabase database;
        public ApplicationDbContext()
        {
            var client = new MongoClient(ConnectionSetting.CONNECTION);
            database = client.GetDatabase(ConnectionSetting.DATABASE);
        }
        public IMongoCollection<TEntity> GetCollection<TEntity>(string Name)=>
            database.GetCollection<TEntity>(Name);

    }
    public static class ConnectionSetting
    {
        public const string DATABASE = "Kodeks";
        public const string CONNECTION = "mongodb://localhost:27017";
    }
}
