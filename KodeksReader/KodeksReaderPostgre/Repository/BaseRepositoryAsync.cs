using KodeksReaderPostgre.Data;
using KodeksReaderPostgre.Model;
using Microsoft.EntityFrameworkCore;

namespace KodeksReaderPostgre.Repository
{
    internal class BaseRepositoryAsync<TEntity> where TEntity : BaseEntity
    {
        private readonly ApplicationDbContext context;
        private readonly DbSet<TEntity> dbSet;

        public BaseRepositoryAsync()
        {
            this.context = new ApplicationDbContext();
            this.dbSet = context.Set<TEntity>();
        }
        public virtual async Task InsertAsync(TEntity entity)
        {
            await this.dbSet.AddAsync(entity);
            await context.SaveChangesAsync();
        }
    }
}
