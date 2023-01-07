using MongoDB.Driver;

namespace KodeksReader.Data
{
    public interface IApplicationDbContext
    {
        IMongoCollection<TEntity> GetCollection<TEntity>(string Name);
    }
}
