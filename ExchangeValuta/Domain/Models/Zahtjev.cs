using System;

namespace ExchangeValuta.Domain.Models
{
    public class Zahtjev
    {
        public int Zahtjev_id { get; set; }
        public int Korisnik_id { get; set; }
        public decimal Iznos { get; set; } // zasto ovdje decimal, a u Valuta je tecaj double i u Sredstva je iznos double? greska?
        public int Prodajem_valuta_id { get; set; }
        public int Kupujem_valuta_id { get; set; }
        public DateTime Datum_vrijeme_kreiranja { get; set; }
        public int Prihvacen { get; set; }
        public Korisnik Korisnik { get; set; }
    }
}