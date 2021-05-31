using Microsoft.AspNetCore.Identity;

namespace ExchangeValuta.Domain.Models
{
    public class UserRole : IdentityUserRole<int>
    {
        public Korisnik Korisnik { get; set; }
        public Role Role { get; set; }
    }
}