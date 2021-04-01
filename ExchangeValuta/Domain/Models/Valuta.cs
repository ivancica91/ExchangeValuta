using System;

namespace ExchangeValuta.Domain.Models
{
    public class Valuta
    {
        public int ValutaId { get; set; }
        public int KorisnikId { get; set; }
        public int DrzavaId { get; set; }
        public string Naziv { get; set; }
        public double Tecaj { get; set; }
        public string SlikaValute { get; set; }
        public DateTime AktivnoOd { get; set; } // nisam sig zbog datuma, a treba mi samo sat
        public DateTime AktivnoDo { get; set; }
        public DateTime DatumAzuriranja { get; set; }
        public Korisnik Korisnik { get; set; }
        public Drzava Drzava { get; set; }
    }
}