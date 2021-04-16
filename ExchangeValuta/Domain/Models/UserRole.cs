using Microsoft.AspNetCore.Identity;

namespace ExchangeValuta.Domain.Models
{
    public class UserRole : IdentityUserRole<int>
    {
        //public int RoleId { get; set; }
        //public int UserId { get; set; }
        public Korisnik Korisnik { get; set; }
        public Role Role { get; set; }
    }
}