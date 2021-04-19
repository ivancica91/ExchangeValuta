using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExchangeValuta.Resources
{
    public class PutValutaDto
    {
        public int ValutaId { get; set; }
        public string Naziv { get; set; }

        public int KorisnikId { get; set; }
        public double Tecaj { get; set; }
        public DateTime DatumAzuriranja { get; set; }

    }
}
