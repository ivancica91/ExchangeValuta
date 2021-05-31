using System;

namespace ExchangeValuta.Domain.Models
{
    public class Zahtjev
    {
        public int ZahtjevId { get; set; }
        public int KorisnikId { get; set; }
        public double Iznos { get; set; } 
        public int ProdajemValutaId { get; set; }
        public int KupujemValutaId { get; set; }
        public DateTime DatumVrijemeKreiranja { get; set; }
        public int Prihvacen { get; set; }
        public Korisnik Korisnik { get; set; }
        public Valuta Valuta { get; set; } // dodao
    }
}