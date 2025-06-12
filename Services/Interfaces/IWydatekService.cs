using System.Collections;
using RejestrWydatkow.Models;

namespace RejestrWydatkow.Services.Interfaces
{
    public interface IWydatekService
    {
        Task<List<Wydatek>> ListaWydatkow();

        Task DodajWydatek(Wydatek wydatek);
        Task ModyfikujWydatek(Wydatek wydatek);

        Task UsunWydatek(int id);

        Task<Wydatek> ZnajdzWydatek(int id);

        Task<Hashtable> Podsumowanie();

        Task<KeyValuePair<double, List<Wydatek>>> Podsumowanie(string kategoria);

    }
}
