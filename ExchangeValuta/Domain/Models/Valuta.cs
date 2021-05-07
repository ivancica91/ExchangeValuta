using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace ExchangeValuta.Domain.Models
{
    [Serializable]
    [XmlRoot("Root")]
    public class Valuta
    {
        public Valuta()
        {
            Drzave = new HashSet<Drzava>();
            Zahtjevi = new HashSet<Zahtjev>(); // dodao
            Sredstva = new HashSet<Sredstva>(); // dodao
        }

        [XmlElement("VALUTAID")]
        public int ValutaId { get; set; }
        [XmlElement("KORISNIKID")]
        public int KorisnikId { get; set; }
        [XmlElement("NAZIV")]
        public string Naziv { get; set; }
        [XmlElement("TECAJ")]
        public double Tecaj { get; set; }
        [XmlElement("SLIKAVALUTE")]
        public string SlikaValute { get; set; }
        [XmlElement("AKTIVNOOD")]
        public TimeSpan AktivnoOd { get; set; }
        [XmlElement("AKKTIVNODO")]
        public TimeSpan AktivnoDo { get; set; }
        [XmlElement("DATUMAZURIRANJA")]
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