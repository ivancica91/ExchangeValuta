using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExchangeValuta.Domain.Models
{
    public class Drzava
    {
        public Drzava()
        {
            Valute = new HashSet<Valuta>();
        }

        public int DrzavaId { get; set; }
        public string Naziv { get; set; }
        public string Sirina { get; set; }
        public string Duljina { get; set; }
        public string Slika { get; set; }
        public string Himna { get; set; }
        public ICollection<Valuta> Valute { get; set; }
    }
}
