using RejestrWydatkow.Services.Interfaces;
using RejestrWydatkow.Models;
using Microsoft.EntityFrameworkCore;

namespace RejestrWydatkow.Services
{
    public class WydatekService : IWydatekService
    {
        private readonly WydatkiDbContext _db;
        public WydatekService(WydatkiDbContext db) 
        {
            _db = db;
        }

        public async Task DodajWydatek(Wydatek wydatek)
        {
            await _db.AddAsync(wydatek);
            await _db.SaveChangesAsync();
        }

        public async Task<List<Wydatek>> ListaWydatkow()
        {
            return await _db.Wydatek.ToListAsync();
        }

        public async Task ModyfikujWydatek(int id, Wydatek wydatek)
        {
            var _wydatek = await _db.Wydatek.FirstAsync(w => w.Id == id);
            if (_wydatek == null) {
                return;
            }

            _wydatek.Opis = wydatek.Opis;
            _wydatek.Kwota = wydatek.Kwota;
            _wydatek.Kategoria = wydatek.Kategoria;
            _wydatek.Data = wydatek.Data;

            await _db.SaveChangesAsync();
        }

        public async Task UsunWydatek(int id)
        {
            var wydatek = await _db.Wydatek.FirstAsync(w => w.Id == id);
            _db.Wydatek.Remove(wydatek);

            await _db.SaveChangesAsync();
        }
    }
}
