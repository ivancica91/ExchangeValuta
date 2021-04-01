using System;

namespace ExchangeValuta.Domain.Models
{
    public class Zahtjev
    {
        public int ZahtjevId { get; set; }
        public int KorisnikId { get; set; }
        public decimal Iznos { get; set; } // zasto ovdje decimal, a u Valuta je tecaj double i u Sredstva je iznos double? greska?
        public int ProdajemValutaId { get; set; }
        public int KupujemValutaId { get; set; }
        public DateTime DatumVrijemeKreiranja { get; set; }
        public int Prihvacen { get; set; }
        public Korisnik Korisnik { get; set; }
    }
}