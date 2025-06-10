using Microsoft.EntityFrameworkCore;

namespace RejestrWydatkow.Models
{
    public class WydatkiDbContext : DbContext
    {
        public WydatkiDbContext(DbContextOptions<WydatkiDbContext> options) : base(options) { }

        public DbSet<Wydatek> Wydatek { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Wydatek>().HasData(
                 new Wydatek
                 {
                     Id = 1,
                     Opis = "Zakupy spożywcze",
                     Kwota = 150.75,
                     Kategoria = "Jedzenie",
                     Data = new DateTime(2024, 1, 15)
                 },
        new Wydatek
        {
            Id = 2,
            Opis = "Paliwo",
            Kwota = 220.00,
            Kategoria = "Transport",
            Data = new DateTime(2024, 1, 18)
        },
        new Wydatek
        {
            Id = 3,
            Opis = "Kino",
            Kwota = 45.00,
            Kategoria = "Rozrywka",
            Data = new DateTime(2024, 2, 3)
        },
        new Wydatek
        {
            Id = 4,
            Opis = "Abonament Netflix",
            Kwota = 55.00,
            Kategoria = "Subskrypcje",
            Data = new DateTime(2024, 2, 1)
        },
        new Wydatek
        {
            Id = 5,
            Opis = "Rachunek za prąd",
            Kwota = 300.00,
            Kategoria = "Media",
            Data = new DateTime(2024, 1, 25)
        }
                );
        }
    }
}
