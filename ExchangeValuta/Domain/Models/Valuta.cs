using System;
using System.Collections.Generic;

namespace ExchangeValuta.Domain.Models
{
    public class Valuta
    {
        public Valuta()
        {
            Drzave = new HashSet<Drzava>();
            Zahtjevi = new HashSet<Zahtjev>(); // dodao
            Sredstva = new HashSet<Sredstva>(); // dodao
        }

        public int ValutaId { get; set; }
        public int KorisnikId { get; set; }
        public string Naziv { get; set; }
        public double Tecaj { get; set; }
        public string SlikaValute { get; set; }
        public TimeSpan AktivnoOd { get; set; } 
        public TimeSpan AktivnoDo { get; set; }
        public DateTime DatumAzuriranja { get; set; }
        public Korisnik Korisnik { get; set; }
        public ICollection<Drzava> Drzave { get; set; }
        public ICollection<Zahtjev> Zahtjevi { get; set; } // dodao
        public ICollection<Sredstva> Sredstva { get; set; } // dodao



    }
}