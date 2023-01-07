using Kodeks.TelegramBot.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Codex = Kodeks.TelegramBot.Domain.Entities;
namespace Kodeks.TelegramBot.Infrastructure.Repository
{
    public class KodeksRepositoryAsync
    {
        private readonly ApplicationDbContext context;
        private readonly DbSet<Domain.Entities.Kodeks> codexes;

        public KodeksRepositoryAsync()
        {
            this.context = new ApplicationDbContext();
            this.codexes = context.Codexes;
        }

        public IQueryable<Codex.Kodeks> GetAllKodeks() =>
                codexes.AsNoTracking();
    }
}
