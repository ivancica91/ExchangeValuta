using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExchangeValuta.Resources
{
    public class ProdanoKupljenoOdbijenoDto
    {
        public int korisnikId { get; set; }
        public string userName { get; set; }
        public string prodajnaValutaOdobreno { get; set; }
        public double iznosProdajnaOdobrenoIznos { get; set; }
        public string kupovnaValutaOdobreno { get; set; }
        public double iznosKupovnaOdobreno { get; set; }
        public string prodajnaValutaOdbijeno { get; set; }
        public double iznosProdajnaOdbijenoIznos { get; set; }
    }
}
