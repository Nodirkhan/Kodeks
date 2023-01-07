using Kodeks.TelegramBot.Domain.Consts;
using Kodeks.TelegramBot.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Codex = Kodeks.TelegramBot.Domain.Entities;

namespace Kodeks.TelegramBot.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Codex.Kodeks> Codexes { get; set; }
        public DbSet<Bob> Chapters { get; set; }
        public DbSet<Modda> Moddalar { get; set; }
        public DbSet<Bolim> Bolimlar { get; set; }
        public DbSet<User> Users { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(ConnectionSetting.CONNECTION);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Modda>()
                .HasIndex(m => m.Number)
                .IsUnique()
                .HasFilter(null);

            base.OnModelCreating(modelBuilder);
        }
    }
}
