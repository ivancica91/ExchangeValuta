using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExchangeValuta.Domain.Models
{
    public class ExchangeDbContext : IdentityDbContext<Korisnik, Role, int,
        IdentityUserClaim<int>, UserRole, IdentityUserLogin<int>, IdentityRoleClaim<int>, IdentityUserToken<int>>
    {
        public ExchangeDbContext(DbContextOptions<ExchangeDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Drzava> Drzave { get; set; }
        public virtual DbSet<Korisnik> Korisnici { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<Sredstva> Sredstva { get; set; }
        public virtual DbSet<Valuta> Valute { get; set; }
        public virtual DbSet<Zahtjev> Zahtjevi { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<UserRole>(userRole =>
            {
                userRole.HasKey(ur => new { ur.UserId, ur.RoleId });

                userRole.HasOne(ur => ur.Role)
                .WithMany(r => r.UserRoles)
                .HasForeignKey(kr => kr.RoleId)
                .IsRequired();

                userRole.HasOne(kr => kr.Korisnik)
                .WithMany(r => r.UserRoles)
                .HasForeignKey(kr => kr.UserId)
                .IsRequired();

            });

            builder.Entity<Role>()
                .HasData(
                new Role
                {
                    Id = 1,
                    Name = "administrator",
                    NormalizedName = "ADMINISTRATOR"
                },
                 new Role
                 {
                     Id = 2,
                     Name = "moderator",
                     NormalizedName = "MODERATOR"

                 },
                  new Role
                  {
                      Id = 3,
                      Name = "korisnik",
                      NormalizedName = "KORISNIK"
                  }
                );
        }
    }
}
