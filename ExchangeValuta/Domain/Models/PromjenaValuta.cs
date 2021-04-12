using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExchangeValuta.Domain.Models
{
    public class PromjenaValuta
    {
        public string Base_code { get; set; }
        public string Target_code { get; set; }
        public float Conversion_rate { get; set; }
        public float Conversion_result { get; set; }
    }

}
