using Kodeks.TelegramBot.Domain.Entities;
using Kodeks.TelegramBot.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Kodeks.TelegramBot.Infrastructure.Repository
{
    public class ModdaRepositoryAsync
    {
        private readonly ApplicationDbContext context;
        private readonly DbSet<Modda> moddalar;

        public ModdaRepositoryAsync()
        {
            this.context = new ApplicationDbContext();
            this.moddalar = context.Moddalar; 
        }

        public async Task<Modda> GetModdaById(Guid moddaId) =>
                await moddalar.AsNoTracking().FirstOrDefaultAsync(m => m.Id == moddaId);

        public async Task<IEnumerable<Modda>> GetPageListAsync(Guid bobId, int pageNumber = 0, int pageSize = 10)=>
            await moddalar.AsNoTracking().Where(m => m.BobId == bobId)
            .Skip(pageNumber).Take(pageSize).OrderBy(k => k.Number).ToListAsync();

        public async Task<Modda> GetModdaByNumberAsync(int number) =>
            await moddalar.AsNoTracking().FirstOrDefaultAsync(m => m.Number == number);

    }
}
