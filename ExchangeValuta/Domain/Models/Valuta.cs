using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace ExchangeValuta.Domain.Models
{
    [Serializable]

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
        [XmlIgnore]
        public Korisnik Korisnik { get; set; }
        [XmlIgnore]

        public ICollection<Drzava> Drzave { get; set; }
        [XmlIgnore]

        public ICollection<Zahtjev> Zahtjevi { get; set; } // dodao
        [XmlIgnore]

        public ICollection<Sredstva> Sredstva { get; set; } // dodao



    }
}