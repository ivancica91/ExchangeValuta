using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExchangeValuta.Resources
{
    public class SredstvaDto
    {
        // Da vrati sredstva logiranog usera, treba prikazivati samo SredstvaId, Naziv valute koji sma mapirao i iznos
        public int SredstvaId { get; set; }
        public string Valuta { get; set; }
        public double Iznos { get; set; }
        public int ValutaId { get; set; }
        //public KorisnikDto Korisnik { get; set; }
        //public ValutaDto Valuta { get; set; }

    }
}
