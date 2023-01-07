using Kodeks.TelegramBot.Domain.Entities;
using Kodeks.TelegramBot.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;

namespace Kodeks.TelegramBot.Infrastructure.Repository
{
    public class BobRepositoryAsync
    {
        private readonly ApplicationDbContext context;
        private readonly DbSet<Bob> boblar;

        public BobRepositoryAsync()
        {
            this.context = new ApplicationDbContext();
            this.boblar = context.Chapters;
        }

        public async Task<IEnumerable<Bob>> GetPageListAsync(Guid bolimId,int pageNumber = 0, int pageSize = 10) =>
            await boblar.AsNoTracking().Where(b => b.BolimId == bolimId)
            .Skip(pageNumber).Take(pageSize).OrderBy(k => k.Number).ToListAsync();

    }
}
