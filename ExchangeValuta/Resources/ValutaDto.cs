using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExchangeValuta.Resources
{
    public class ValutaDto
    {
        public int ValutaId { get; set; }
        public string Naziv { get; set; }
        public double Tecaj { get; set; }
        public string SlikaValute { get; set; }

    }
}
