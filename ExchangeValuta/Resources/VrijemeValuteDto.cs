using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExchangeValuta.Resources
{
    public class VrijemeValuteDto
    {
        public int ValutaId { get; set; }
        public TimeSpan AktivnoOd { get; set; }
        public TimeSpan AktivnoDo { get; set; }

    }
}
