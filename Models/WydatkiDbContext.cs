using Microsoft.EntityFrameworkCore;

namespace RejestrWydatkow.Models
{
    public class WydatkiDbContext : DbContext
    {
        public WydatkiDbContext(DbContextOptions<WydatkiDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Wydatek>().HasData();
        }

        public DbSet<Wydatek> Wydatek { get; set; }
    }
}
