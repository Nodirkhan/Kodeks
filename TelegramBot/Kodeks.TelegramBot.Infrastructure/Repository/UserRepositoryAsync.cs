using Kodeks.TelegramBot.Domain.Entities;
using Kodeks.TelegramBot.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Kodeks.TelegramBot.Infrastructure.Repository
{
    public class UserRepositoryAsync
    {
        private readonly ApplicationDbContext context;

        public UserRepositoryAsync()
        {
            this.context = new ApplicationDbContext();
        }
        public async Task InsertAsync(User user)
        {
            await context.Users.AddAsync(user);
            int a = await context.SaveChangesAsync();
        }
        
        public async Task UpdateAsync(User user)
        {
            context.Entry(user).State = EntityState.Modified;
            await context.SaveChangesAsync();   
        }

        public async Task<User> FindByConditionAsync(Expression<Func<User, bool>> filter) =>
            await context.Users.AsNoTracking().FirstOrDefaultAsync(filter);
    }
}
