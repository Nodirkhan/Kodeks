using KodeksReader.Data;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Linq.Expressions;

namespace KodeksReader.Repository
{
    public class BaseRepositoryAsync<TEntity> where TEntity : class
    {
        private readonly IApplicationDbContext _context;
        private readonly IMongoCollection<TEntity> _dbCollection;

        public BaseRepositoryAsync()
        {
            _context = new ApplicationDbContext();
            _dbCollection = _context.GetCollection<TEntity>(typeof(TEntity).Name);
        }

        public virtual async Task InserAsync(TEntity entity)
        {
            await _dbCollection.InsertOneAsync(entity);
        }
    }
}
