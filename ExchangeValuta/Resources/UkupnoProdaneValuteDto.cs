using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExchangeValuta.Resources
{
    public class UkupnoProdaneValuteDto
    {
        public int ValutaId { get; set; }
        public DateTime DatumVrijemeKreiranja { get; set; }
        public string Naziv { get; set; }  //htio bi da i naziv pokaz, ali ne znam kako mapirati to?
        public double Iznos { get; set; }



    }
}
