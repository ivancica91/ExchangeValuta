namespace ExchangeValuta.Domain.Models
{
    public class Sredstva
    {
        public int Sredstva_id { get; set; }
        public int Korisnik_id { get; set; }
        public int Valuta_id { get; set; }
        public double Iznos { get; set; }
        public Korisnik Korisnik { get; set; }
        public Valuta Valuta { get; set; }
    }
}