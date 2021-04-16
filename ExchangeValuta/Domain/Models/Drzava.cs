using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExchangeValuta.Domain.Models
{
    public class Drzava
    {

        public int DrzavaId { get; set; }
        public int ValutaId { get; set; }
        public string Naziv { get; set; }
        public string Sirina { get; set; }
        public string Duljina { get; set; }
        public string Slika { get; set; }
        public string Himna { get; set; }
        public Valuta Valuta { get; set; }
    }
}
