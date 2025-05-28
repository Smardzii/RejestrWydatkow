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

        public async Task ModyfikujWydatek(int Id, Wydatek wydatek)
        {
            var _wydatek = await _db.Wydatek.Where(w =>  w.Id == Id).ToListAsync();
            if (_wydatek == null) {
                return;
            }

            _wydatek[0].Opis = wydatek.Opis;
            _wydatek[0].Kwota = wydatek.Kwota;
            _wydatek[0].Kategoria = wydatek.Kategoria;
            _wydatek[0].Data = wydatek.Data;

            await _db.SaveChangesAsync();
        }
    }
}
