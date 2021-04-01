namespace ExchangeValuta.Domain.Models
{
    public class Sredstva
    {
        public int SredstvaId { get; set; }
        public int KorisnikId { get; set; }
        public int ValutaId { get; set; }
        public double Iznos { get; set; }
        public Korisnik Korisnik { get; set; }
        public Valuta Valuta { get; set; }
    }
}