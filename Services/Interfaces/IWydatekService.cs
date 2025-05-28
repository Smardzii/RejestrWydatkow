using RejestrWydatkow.Models;

namespace RejestrWydatkow.Services.Interfaces
{
    public interface IWydatekService
    {
        Task<List<Wydatek>> ListaWydatkow();

        Task DodajWydatek(Wydatek wydatek);
        Task ModyfikujWydatek(int Id, Wydatek wydatek);

    }
}
