using Microsoft.EntityFrameworkCore;

namespace RejestrWydatkow.Models
{
    public class WydatkiDbContext : DbContext
    {
        public WydatkiDbContext(DbContextOptions<WydatkiDbContext> options) : base(options) { }

        DbSet<Wydatek> Wydatek { get; set; }
    }
}
