using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExchangeValuta.Resources
{
    public class ValutaDetailsDto
    {
        public int KorisnikId { get; set; }
        public string UserName   { get; set; }
        public int ValutaId { get; set; }
        public string Naziv { get; set; }
        public double Tecaj { get; set; }
        public string SlikaValute { get; set; }
        public TimeSpan AktivnoOd { get; set; }
        public TimeSpan AktivnoDo { get; set; }


    }
}
