using System.Collections;
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

        public async Task ModyfikujWydatek(Wydatek wydatek)
        {
            var _wydatek = await _db.Wydatek.FirstAsync(w => w.Id == wydatek.Id);
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

        public async Task<Wydatek> ZnajdzWydatek(int id)
        {
            return await _db.Wydatek.FirstAsync(w => w.Id == id);
        }

        public async Task<Hashtable> Podsumowanie()
        {
            var wydatki = await _db.Wydatek.ToListAsync();
            Hashtable kategorie = new Hashtable();

            foreach (var wydatek in wydatki)
            {
                double kwota = wydatek.Kwota;
                if (kategorie.Contains(wydatek.Kategoria))
                    kwota += (double) kategorie[wydatek.Kategoria];
                kategorie[wydatek.Kategoria] = wydatek.Kwota;
            }

            return kategorie;
        }

        public async Task<KeyValuePair<double, List<Wydatek>>> Podsumowanie(string kategoria)
        {
            double kwota = 0;
            var wydatki = await ListaWydatkow();
            wydatki = wydatki.Where(w => w.Kategoria == kategoria).ToList();
            
            foreach (var wydatek in wydatki)
                kwota += wydatek.Kwota;
            
            return KeyValuePair.Create(kwota, wydatki);
        }
    }
}
