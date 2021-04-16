using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExchangeValuta.Resources
{
    public class PostZahtjevDto
    {
        public double Iznos { get; set; } 
        public int ProdajemValutaId { get; set; }
        public int KupujemValutaId { get; set; }

    }
}
