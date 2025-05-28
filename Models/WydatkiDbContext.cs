using Microsoft.EntityFrameworkCore;

namespace RejestrWydatkow.Models
{
    public class WydatkiDbContext : DbContext
    {
        public WydatkiDbContext(DbContextOptions<WydatkiDbContext> options) : base(options) { }

        public DbSet<Wydatek> Wydatek { get; set; }
    }
}
