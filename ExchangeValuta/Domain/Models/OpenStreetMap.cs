using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExchangeValuta.Domain.Models
{
    public class OpenStreetMap
    {
        public string display_name { get; set; }
        public Address address { get; set; }
    }

    public class Address
    {
        public string city { get; set; }
        public string state { get; set; }
        public string country { get; set; }
        public string country_code { get; set; }
    }

}
