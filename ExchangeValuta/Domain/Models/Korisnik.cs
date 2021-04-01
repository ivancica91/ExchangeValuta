using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExchangeValuta.Domain.Models
{
    public class Korisnik : IdentityUser<int>
    {
        public Korisnik()
        {
            UserRoles = new HashSet<UserRole>();
            Zahtjevi = new HashSet<Zahtjev>();
            Sredstva = new HashSet<Sredstva>();
            Valute = new HashSet<Valuta>();
        }

        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Lozinka { get; set; }
        public string Slika { get; set; }
        public ICollection<UserRole> UserRoles { get; set; }
        public ICollection<Zahtjev> Zahtjevi { get; set; }
        public ICollection<Sredstva> Sredstva { get; set; }
        public ICollection<Valuta> Valute { get; set; }
    }
}
