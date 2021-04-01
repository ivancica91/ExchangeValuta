using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExchangeValuta.Domain.Models
{
    public class Role : IdentityRole<int>
    {
        public Role()
        {
            UserRoles = new HashSet<UserRole>();
        }

        public ICollection<UserRole> UserRoles { get; set; }
    }
}
