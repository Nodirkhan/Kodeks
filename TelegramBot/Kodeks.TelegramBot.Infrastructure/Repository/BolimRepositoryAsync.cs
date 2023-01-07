using Kodeks.TelegramBot.Domain.Entities;
using Kodeks.TelegramBot.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Kodeks.TelegramBot.Infrastructure.Repository
{
    public class BolimRepositoryAsync
    {
        private readonly ApplicationDbContext context;
        private readonly DbSet<Bolim> bolim;

        public BolimRepositoryAsync()
        {
            this.context = new ApplicationDbContext();
            this.bolim = context.Bolimlar;
        }

        public async Task<IEnumerable<Bolim>> GetPageListAsync(Guid kodeksId, int pageNumber = 0, int pageSize = 10) =>
            await bolim.AsNoTracking().Where(k => k.KodeksId == kodeksId)
            .Skip(pageNumber*pageSize).Take(pageSize).OrderBy(k => k.Number)
            .ToListAsync();
    }
}
