using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExchangeValuta.Resources
{
    public class EditValutaDto
    {
        public string UserName { get; set; }

        public string Naziv { get; set; }
        public string SlikaValute { get; set; }
        public TimeSpan AktivnoOd { get; set; }
        public TimeSpan AktivnoDo { get; set; }

    }
}
