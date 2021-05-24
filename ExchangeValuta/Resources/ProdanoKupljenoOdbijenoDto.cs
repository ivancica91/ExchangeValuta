using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExchangeValuta.Resources
{
    public class ProdanoKupljenoOdbijenoDto
    {
        public int KorisnikId { get; set; }
        public string UserName { get; set; }
        public string ProdajnaValutaOdobreno { get; set; }
        public double IznosProdajnaOdobrenoIznos { get; set; }
        public string KupovnaValutaOdobreno { get; set; }
        public double IznosKupovnaOdobreno { get; set; }
        public string ProdajnaValutaOdbijeno { get; set; }
        public double IznosProdajnaOdbijenoIznos { get; set; }
    }
}
