using System;

namespace ExchangeValuta.Domain.Models
{
    public class Valuta
    {
        public int Valuta_id { get; set; }
        public int Korisnik_id { get; set; }
        public int Drzava_id { get; set; }
        public string Naziv { get; set; }
        public double Tecaj { get; set; }
        public string Slika_valute { get; set; }
        public DateTime Aktivno_od { get; set; } // nisam sig zbog datuma, a treba mi samo sat
        public DateTime Aktivno_do { get; set; }
        public DateTime Datum_azuriranja { get; set; }
        public Korisnik Korisnik { get; set; }
        public Drzava Drzava { get; set; }
    }
}