namespace RejestrWydatkow.Models
{
    public class Wydatek
    {
        public int Id { get; set; }
        public string Opis { get; set; }
        public double Kwota { get; set; }
        public string Kategoria { get; set; }
        public DateTime Data { get; set; }
    }
}
