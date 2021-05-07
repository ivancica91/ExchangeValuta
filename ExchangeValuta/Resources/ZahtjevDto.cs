using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExchangeValuta.Resources
{
    public class ZahtjevDto
    {
        public int ZahtjevId { get; set; }
        public int KorisnikId { get; set; }
        public double Iznos { get; set; } 
        public int ProdajemValutaId { get; set; }
        public string ProdajemValuta { get; set; }
        //public string ValutaP { get; set; }
        public int KupujemValutaId { get; set; }
        public string KupujemValuta { get; set; }
        //public string ValutaK { get; set; }

        public DateTime DatumVrijemeKreiranja { get; set; }
        public int Prihvacen { get; set; }

    }
}
