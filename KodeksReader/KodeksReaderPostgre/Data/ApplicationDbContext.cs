
using KodeksReaderPostgre.Model;
using Microsoft.EntityFrameworkCore;

namespace KodeksReaderPostgre.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Kodeks> Codexes { get; set; }
        public DbSet<Bob> Chapters { get; set; }
        public DbSet<Modda> Moddalar { get; set; }
        public DbSet<Bolim> Bolimlar { get; set; }
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
    public static class ConnectionSetting
    {
        public const string CONNECTION = "Server=localhost;Port=5432;Database=KodeksBot;Username=postgres;Password=20020623;";
    }
}
