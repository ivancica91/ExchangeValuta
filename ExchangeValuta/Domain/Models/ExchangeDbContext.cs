using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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

                userRole.HasData(
                    new UserRole
                    {
                        RoleId = 1,
                        UserId = 1
                    },
                new UserRole
                {
                    RoleId = 2,
                    UserId = 1
                },
                new UserRole
                {
                    RoleId = 2,
                    UserId = 2
                },
                new UserRole
                {
                    RoleId = 2,
                    UserId = 3
                },
                new UserRole
                {
                    RoleId = 2,
                    UserId = 4
                },
                new UserRole
                {
                    RoleId = 2,
                    UserId = 10
                },
                new UserRole
                {
                    RoleId = 3,
                    UserId = 5
                },
                new UserRole
                {
                    RoleId = 3,
                    UserId = 6
                },
                new UserRole
                {
                    RoleId = 3,
                    UserId = 7
                },
                new UserRole
                {
                    RoleId = 3,
                    UserId = 8
                },
                new UserRole
                {
                    RoleId = 3,
                    UserId = 9
                },
                new UserRole
                {
                    RoleId = 3,
                    UserId = 11
                },
                new UserRole
                {
                    RoleId = 3,
                    UserId = 12
                },
                new UserRole
                {
                    RoleId = 3,
                    UserId = 13
                },
                new UserRole
                {
                    RoleId = 3,
                    UserId = 14
                },
                new UserRole
                {
                    RoleId = 3,
                    UserId = 15
                },
                new UserRole
                {
                    RoleId = 3,
                    UserId = 16
                },
                new UserRole
                {
                    RoleId = 3,
                    UserId = 17
                },
                new UserRole
                {
                    RoleId = 3,
                    UserId = 18
                },
                new UserRole
                {
                    RoleId = 3,
                    UserId = 19
                },
                new UserRole
                {
                    RoleId = 3,
                    UserId = 20
                },
                new UserRole
                {
                    RoleId = 3,
                    UserId = 21
                },
                new UserRole
                {
                    RoleId = 3,
                    UserId = 22
                },
                new UserRole
                {
                    RoleId = 3,
                    UserId = 23
                },
                new UserRole
                {
                    RoleId = 3,
                    UserId = 24
                },
                new UserRole
                {
                    RoleId = 3,
                    UserId = 25
                },
                new UserRole
                {
                    RoleId = 3,
                    UserId = 26
                },
                new UserRole
                {
                    RoleId = 3,
                    UserId = 27
                },
                new UserRole
                {
                    RoleId = 3,
                    UserId = 28
                },
                new UserRole
                {
                    RoleId = 3,
                    UserId = 29
                }
                    );

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

            var korisnik = new Korisnik();
            var hasher = new PasswordHasher<Korisnik>();

            builder.Entity<Korisnik>()
                .HasData(
                new Korisnik
                {
                    Id = 1,
                    UserName = "admin",
                    Lozinka = "admin",
                    PasswordHash = hasher.HashPassword(korisnik, "admin"),
                    Ime = "Administrator",
                    Prezime = "Administrator",
                    Slika = "korisnici/admin.jpg",
                    SecurityStamp = Guid.NewGuid().ToString(),
                    EmailConfirmed = true,
                    LockoutEnabled = true
                },
                new Korisnik
                {
                    Id = 2,
                    UserName = "voditelj",
                    Lozinka = "123456",
                    PasswordHash = hasher.HashPassword(korisnik, "123456"),
                    Ime = "Voditelj",
                    Prezime = "Voditelj",
                    Slika = "korisnici/admin.jpg",
                    SecurityStamp = Guid.NewGuid().ToString(),
                    EmailConfirmed = true,
                    LockoutEnabled = true
                },
                new Korisnik
                {
                    Id = 18,
                    UserName = "kdunst",
                    Lozinka = "123456",
                    PasswordHash = hasher.HashPassword(korisnik, "123456"),
                    Ime = "Kirsten",
                    Prezime = "Dunst",
                    Email = "kdunst@mail.hr",
                    Slika = "korisnici/kdunst.jpg",
                    EmailConfirmed = true,
                    SecurityStamp = Guid.NewGuid().ToString(),
                    LockoutEnabled = true
                },
                new Korisnik
                {
                    Id = 30,
                    UserName = "thanks",
                    Lozinka = "123456",
                    PasswordHash = hasher.HashPassword(korisnik, "123456"),
                    Ime = "Tom",
                    Prezime = "Hanks",
                    Email = "thanks@mail.hr",
                    Slika = "korisnici/thanks.jpg",
                    EmailConfirmed = true,
                    SecurityStamp = Guid.NewGuid().ToString(),
                    LockoutEnabled = true
                },
                new Korisnik
                {
                    Id = 31,
                    UserName = "jalba",
                    Lozinka = "123456",
                    PasswordHash = hasher.HashPassword(korisnik, "123456"),
                    Ime = "Jessica",
                    Prezime = "Alba",
                    Email = "jalba@mail.hr",
                    Slika = "korisnici/jalba.jpg",
                    EmailConfirmed = true,
                    SecurityStamp = Guid.NewGuid().ToString(),
                    LockoutEnabled = true
                },
                new Korisnik
                {
                    Id = 3,
                    UserName = "pkos",
                    Lozinka = "123456",
                    PasswordHash = hasher.HashPassword(korisnik, "123456"),
                    Ime = "Pero",
                    Prezime = "Kos",
                    Email = "pkos@mail.hr",
                    Slika = "korisnici/pkos.jpg",
                    EmailConfirmed = true,
                    SecurityStamp = Guid.NewGuid().ToString(),
                    LockoutEnabled = true
                },
                new Korisnik
                {
                    Id = 4,
                    UserName = "vzec",
                    Lozinka = "123456",
                    PasswordHash = hasher.HashPassword(korisnik, "123456"),
                    Ime = "Vladimir",
                    Prezime = "Zec",
                    Email = "vzec@mail.hr",
                    Slika = "korisnici/vzec.jpg",
                    EmailConfirmed = true,
                    SecurityStamp = Guid.NewGuid().ToString(),
                    LockoutEnabled = true
                },
                new Korisnik
                {
                    Id = 5,
                    UserName = "qtarantino",
                    Lozinka = "123456",
                    PasswordHash = hasher.HashPassword(korisnik, "123456"),
                    Ime = "Quentin",
                    Prezime = "Tarantino",
                    Email = "qtarantino@mail.hr",
                    Slika = "korisnici/qtarantino.jpg",
                    EmailConfirmed = true,
                    SecurityStamp = Guid.NewGuid().ToString(),
                    LockoutEnabled = true
                },
                new Korisnik
                {
                    Id = 6,
                    UserName = "mbellucci",
                    Lozinka = "123456",
                    PasswordHash = hasher.HashPassword(korisnik, "123456"),
                    Ime = "Monica",
                    Prezime = "Bellucci",
                    Email = "mbellucci@mail.hr",
                    Slika = "korisnici/mbellucci.jpg",
                    EmailConfirmed = true,
                    SecurityStamp = Guid.NewGuid().ToString(),
                    LockoutEnabled = true
                },
                new Korisnik
                {
                    Id = 7,
                    UserName = "vmortensen",
                    Lozinka = "123456",
                    PasswordHash = hasher.HashPassword(korisnik, "123456"),
                    Ime = "Viggo",
                    Prezime = "Mortensen",
                    Email = "vmortensen@mail.hr",
                    Slika = "korisnici/vmortensen.jpg",
                    EmailConfirmed = true,
                    SecurityStamp = Guid.NewGuid().ToString(),
                    LockoutEnabled = true
                },
                new Korisnik
                {
                    Id = 8,
                    UserName = "jgarner",
                    Lozinka = "123456",
                    PasswordHash = hasher.HashPassword(korisnik, "123456"),
                    Ime = "Jennifer",
                    Prezime = "Garner",
                    Email = "jgarner@mail.hr",
                    Slika = "korisnici/jgarner.jpg",
                    EmailConfirmed = true,
                    SecurityStamp = Guid.NewGuid().ToString(),
                    LockoutEnabled = true
                },
                new Korisnik
                {
                    Id = 9,
                    UserName = "nportman",
                    Lozinka = "123456",
                    PasswordHash = hasher.HashPassword(korisnik, "123456"),
                    Ime = "Natalie",
                    Prezime = "Portman",
                    Email = "nportman@mail.hr",
                    Slika = "korisnici/nportman.jpg",
                    EmailConfirmed = true,
                    SecurityStamp = Guid.NewGuid().ToString(),
                    LockoutEnabled = true
                },
                new Korisnik
                {
                    Id = 10,
                    UserName = "dradcliffe",
                    Lozinka = "123456",
                    PasswordHash = hasher.HashPassword(korisnik, "123456"),
                    Ime = "Daniel",
                    Prezime = "Radcliffe",
                    Email = "dradcliffe@mail.hr",
                    Slika = "korisnici/dradcliffe.jpg",
                    EmailConfirmed = true,
                    SecurityStamp = Guid.NewGuid().ToString(),
                    LockoutEnabled = true
                },
                new Korisnik
                {
                    Id = 11,
                    UserName = "hberry",
                    Lozinka = "123456",
                    PasswordHash = hasher.HashPassword(korisnik, "123456"),
                    Ime = "Halle",
                    Prezime = "Berry",
                    Email = "hberry@mail.hr",
                    Slika = "korisnici/hberry.jpg",
                    EmailConfirmed = true,
                    SecurityStamp = Guid.NewGuid().ToString(),
                    LockoutEnabled = true
                },
                new Korisnik
                {
                    Id = 12, 
                    UserName = "vdiesel",
                    Lozinka = "123456",
                    PasswordHash = hasher.HashPassword(korisnik, "123456"),
                    Ime = "Vin",
                    Prezime = "Diesel",
                    Email = "vdiesel@mail.hr",
                    Slika = "korisnici/vdiesel.jpg",
                    EmailConfirmed = true ,
                    SecurityStamp = Guid.NewGuid().ToString(),
                    LockoutEnabled = true
                },
                new Korisnik 
                { 
                    Id = 13, 
                    UserName = "ecuthbert",
                    Lozinka = "123456",
                    PasswordHash = hasher.HashPassword(korisnik, "123456"),
                    Ime = "Elisha",
                    Prezime = "Cuthbert",
                    Email = "ecuthbert@mail.hr", 
                    Slika = "korisnici/ecuthbert.jpg",
                    EmailConfirmed = true,
                    SecurityStamp = Guid.NewGuid().ToString(),
                    LockoutEnabled = true
                },
                new Korisnik
                { Id = 14,
                    UserName = "janiston",
                    Lozinka = "123456",
                    PasswordHash = hasher.HashPassword(korisnik, "123456"),
                    Ime = "Jennifer", 
                    Prezime = "Aniston", 
                    Email = "janiston@mail.hr", 
                    Slika = "korisnici/janiston.jpg", 
                    EmailConfirmed = true,
                    SecurityStamp = Guid.NewGuid().ToString(),
                    LockoutEnabled = true
                },
                new Korisnik 
                { Id = 15,
                    UserName = "ctheron", 
                    Lozinka = "123456",
                    PasswordHash = hasher.HashPassword(korisnik, "123456"),
                    Ime = "Charlize",
                    Prezime = "Theron", 
                    Email = "ctheron@mail.hr", 
                    Slika = "korisnici/ctheron.jpg", 
                    EmailConfirmed = true ,
                    SecurityStamp = Guid.NewGuid().ToString(),
                    LockoutEnabled = true
                },
                new Korisnik 
                { 
                    Id = 16,
                    UserName = "nkidman",
                    Lozinka = "123456",
                    PasswordHash = hasher.HashPassword(korisnik, "123456"),
                    Ime = "Nicole", 
                    Prezime = "Kidman", 
                    Email = "nkidman@mail.hr", 
                    Slika = "korisnici/nkidman.jpg", 
                    EmailConfirmed = true ,
                    SecurityStamp = Guid.NewGuid().ToString(),
                    LockoutEnabled = true
                },
                new Korisnik 
                {
                    Id = 17, 
                    UserName = "ewatson",
                    Lozinka = "123456",
                    PasswordHash = hasher.HashPassword(korisnik, "123456"),
                    Ime = "Emma",
                    Prezime = "Watson",
                    Email = "ewatson@mail.hr",
                    Slika = "korisnici/ewatson.jpg", 
                    EmailConfirmed = true ,
                    SecurityStamp = Guid.NewGuid().ToString(),
                    LockoutEnabled = true
                },
                new Korisnik
                { 
                    Id = 19,
                    UserName = "sjohansson", 
                    Lozinka = "123456",
                    PasswordHash = hasher.HashPassword(korisnik, "123456"),
                    Ime = "Scarlett",
                    Prezime = "Johansson",
                    Email = "sjohansson@mail.hr", 
                    Slika = "korisnici/sjohansson.jpg", 
                    EmailConfirmed = true,
                    SecurityStamp = Guid.NewGuid().ToString(),
                    LockoutEnabled = true
                },
                new Korisnik 
                {
                    Id = 20,
                    UserName = "philton",
                    Lozinka = "123456",
                    PasswordHash = hasher.HashPassword(korisnik, "123456"),
                    Ime = "Paris", 
                    Prezime = "Hilton", 
                    Email = "philton@mail.hr", 
                    Slika = "korisnici/philton.jpg",
                    EmailConfirmed = true,
                    SecurityStamp = Guid.NewGuid().ToString(),
                    LockoutEnabled = true
                },
                new Korisnik 
                { Id = 21,
                    UserName = "kbeckinsale",
                    Lozinka = "123456",
                    PasswordHash = hasher.HashPassword(korisnik, "123456"),
                    Ime = "Kate",
                    Prezime = "Beckinsale",
                    Email = "kbeckinsale@mail.hr", 
                    Slika = "korisnici/kbeckinsale.jpg", 
                    EmailConfirmed = true ,
                    SecurityStamp = Guid.NewGuid().ToString(),
                    LockoutEnabled = true
                },
                new Korisnik 
                {
                    Id = 22, 
                    UserName = "tcruise",
                    Lozinka = "123456",
                    PasswordHash = hasher.HashPassword(korisnik, "123456"),
                    Ime = "Tom",
                    Prezime = "Cruise",
                    Email = "tcruise@mail.hr", 
                    Slika = "korisnici/tcruise.jpg",
                    EmailConfirmed = true ,
                    SecurityStamp = Guid.NewGuid().ToString(),
                    LockoutEnabled = true
                },
                new Korisnik
                {
                    Id = 23, 
                    UserName = "hduff", 
                    Lozinka = "123456",
                    PasswordHash = hasher.HashPassword(korisnik, "123456"),
                    Ime = "Hilary", 
                    Prezime = "Duff",
                    Email = "hduff@mail.hr", 
                    Slika = "korisnici/hduff.jpg", 
                    EmailConfirmed = true,
                    SecurityStamp = Guid.NewGuid().ToString(),
                    LockoutEnabled = true
                },
                new Korisnik
                { 
                    Id = 24, 
                    UserName = "ajolie",
                    Lozinka = "123456",
                    PasswordHash = hasher.HashPassword(korisnik, "123456"),
                    Ime = "Angelina", 
                    Prezime = "Jolie", 
                    Email = "ajolie@mail.hr", 
                    Slika = "korisnici/ajolie.jpg", 
                    EmailConfirmed = true,
                    SecurityStamp = Guid.NewGuid().ToString(),
                    LockoutEnabled = true
                },
                new Korisnik
                {
                    Id = 25, 
                    UserName = "kknightley", 
                    Lozinka = "123456",
                    PasswordHash = hasher.HashPassword(korisnik, "123456"),
                    Ime = "Keira",
                    Prezime = "Knightley", 
                    Email = "kknightley@mail.hr", 
                    Slika = "korisnici/kknightley.jpg", 
                    EmailConfirmed = true,
                    SecurityStamp = Guid.NewGuid().ToString(),
                    LockoutEnabled = true
                },
                new Korisnik
                {
                    Id = 26, 
                    UserName = "obloom",
                    Lozinka = "123456",
                    PasswordHash = hasher.HashPassword(korisnik, "123456"),
                    Ime = "Orlando", 
                    Prezime = "Bloom", 
                    Email = "obloom@mail.hr", 
                    Slika = "korisnici/obloom.jpg", 
                    EmailConfirmed = true,
                    SecurityStamp = Guid.NewGuid().ToString(),
                    LockoutEnabled = true
                },
                new Korisnik
                { 
                    Id = 27, 
                    UserName = "llohan", 
                    Lozinka = "123456",
                    PasswordHash = hasher.HashPassword(korisnik, "123456"),
                    Ime = "Lindsay", 
                    Prezime = "Lohan",
                    Email = "llohan@mail.hr", 
                    Slika = "korisnici/llohan.jpg", 
                    EmailConfirmed = true,
                    SecurityStamp = Guid.NewGuid().ToString(),
                    LockoutEnabled = true
                },
                new Korisnik
                {
                    Id = 28,
                    UserName = "jdepp", 
                    Lozinka = "123456",
                    PasswordHash = hasher.HashPassword(korisnik, "123456"),
                    Ime = "Johnny", 
                    Prezime = "Depp", 
                    Email = "jdepp@mail.hr", 
                    Slika = "korisnici/jdepp.jpg", 
                    EmailConfirmed = true,
                    SecurityStamp = Guid.NewGuid().ToString(),
                    LockoutEnabled = true
                },
                new Korisnik 
                {
                    Id = 29,
                    UserName = "kreeves", 
                    Lozinka = "123456",
                    PasswordHash = hasher.HashPassword(korisnik, "123456"),
                    Ime = "Keanu", 
                    Prezime = "Reeves", 
                    Email = "kreeves@mail.hr", 
                    Slika = "korisnici/kreeves.jpg", 
                    EmailConfirmed = true ,
                    SecurityStamp = Guid.NewGuid().ToString(),
                    LockoutEnabled = true
                }
                );


            builder.Entity<Valuta>()
                .HasData(
                new Valuta
                {
                    ValutaId = 1,
                    KorisnikId = 2,
                    Naziv = "HRK",
                    Tecaj = 1,
                    SlikaValute = "valute/",
                    AktivnoOd = new TimeSpan(0, 10, 0, 0),
                    AktivnoDo = new TimeSpan(0, 12, 0, 0),
                },
                new Valuta
                {
                    ValutaId = 2,
                    KorisnikId = 2,
                    Naziv = "USD",
                    Tecaj = 0.1581,
                    SlikaValute = "valute/dolar.jpg",
                    AktivnoOd = new TimeSpan(0, 10, 0, 0),
                    AktivnoDo = new TimeSpan(0, 12, 0, 0),
                },
                new Valuta
                {
                    ValutaId = 3,
                    KorisnikId = 3,
                    Naziv = "AUD",
                    Tecaj = 0.2066,
                    SlikaValute = "valute/australskidolar.jpg",
                    AktivnoOd = new TimeSpan(0, 10, 0, 0),
                    AktivnoDo = new TimeSpan(0, 12, 0, 0),
                },
                new Valuta
                {
                    ValutaId = 4,
                    KorisnikId = 3,
                    Naziv = "BAM",
                    Tecaj = 0.2596,
                    SlikaValute = "valute/bam.gif",
                    AktivnoOd = new TimeSpan(0, 10, 0, 0),
                    AktivnoDo = new TimeSpan(0, 12, 0, 0),
                },
                new Valuta
                {
                    ValutaId = 5,
                    KorisnikId = 4,
                    Naziv = "CAD",
                    Tecaj = 0.1987,
                    SlikaValute = "valute/cad.jpg",
                    AktivnoOd = new TimeSpan(0, 10, 0, 0),
                    AktivnoDo = new TimeSpan(0, 12, 0, 0),
                },
                new Valuta
                {
                    ValutaId = 6,
                    KorisnikId = 4,
                    Naziv = "CNY",
                    Tecaj = 1.0338,
                    SlikaValute = "valute/cny.jpg",
                    AktivnoOd = new TimeSpan(0, 10, 0, 0),
                    AktivnoDo = new TimeSpan(0, 12, 0, 0),
                },
                new Valuta
                {
                    ValutaId = 7,
                    KorisnikId = 4,
                    Naziv = "DKK",
                    Tecaj = 0.9902,
                    SlikaValute = "valute/dkk.jpg",
                    AktivnoOd = new TimeSpan(0, 10, 0, 0),
                    AktivnoDo = new TimeSpan(0, 12, 0, 0),
                },
                new Valuta
                {
                    ValutaId = 8,
                    KorisnikId = 4,
                    Naziv = "EUR",
                    Tecaj = 0.1327,
                    SlikaValute = "valute/EUR.jpg",
                    AktivnoOd = new TimeSpan(0, 10, 0, 0),
                    AktivnoDo = new TimeSpan(0, 12, 0, 0),
                },
                new Valuta
                {
                    ValutaId = 9,
                    KorisnikId = 2,
                    Naziv = "HUF",
                    Tecaj = 47.7446,
                    SlikaValute = "valute/huf.jpg",
                    AktivnoOd = new TimeSpan(0, 10, 0, 0),
                    AktivnoDo = new TimeSpan(0, 12, 0, 0),
                },
                new Valuta
                {
                    ValutaId = 10,
                    KorisnikId = 3,
                    Naziv = "ISK",
                    Tecaj = 20.0058,
                    SlikaValute = "valute/isk.jpg",
                    AktivnoOd = new TimeSpan(0, 10, 0, 0),
                    AktivnoDo = new TimeSpan(0, 12, 0, 0),
                },
                new Valuta
                {
                    ValutaId = 11,
                    KorisnikId = 2,
                    Naziv = "INR",
                    Tecaj = 11.7586,
                    SlikaValute = "valute/inr.jpg",
                    AktivnoOd = new TimeSpan(0, 10, 0, 0),
                    AktivnoDo = new TimeSpan(0, 12, 0, 0),
                },
                new Valuta
                {
                    ValutaId = 12,
                    KorisnikId = 2,
                    Naziv = "IRR",
                    Tecaj = 6602.1956,
                    SlikaValute = "valute/irr.jpg",
                    AktivnoOd = new TimeSpan(0, 10, 0, 0),
                    AktivnoDo = new TimeSpan(0, 12, 0, 0),
                },
                new Valuta
                {
                    ValutaId = 13,
                    KorisnikId = 3,
                    Naziv = "ILS",
                    Tecaj = 0.5209,
                    SlikaValute = "valute/ils.jpg",
                    AktivnoOd = new TimeSpan(0, 10, 0, 0),
                    AktivnoDo = new TimeSpan(0, 12, 0, 0),
                },
                new Valuta
                {
                    ValutaId = 14,
                    KorisnikId = 3,
                    Naziv = "JPY",
                    Tecaj = 17.2704,
                    SlikaValute = "valute/jpy.jpg",
                    AktivnoOd = new TimeSpan(0, 10, 0, 0),
                    AktivnoDo = new TimeSpan(0, 12, 0, 0),
                },
                new Valuta
                {
                    ValutaId = 15,
                    KorisnikId = 2,
                    Naziv = "MKD",
                    Tecaj = 8.1780,
                    SlikaValute = "valute/mkd.jpg",
                    AktivnoOd = new TimeSpan(0,10,0,0),
                    AktivnoDo = new TimeSpan(0,12, 0, 0),
                },
                new Valuta
                {
                    ValutaId = 16,
                    KorisnikId = 3,
                    Naziv = "MXN",
                    Tecaj = 3.1829,
                    SlikaValute = "valute/mxn.jpg",
                    AktivnoOd = new TimeSpan(0, 10, 0, 0),
                    AktivnoDo = new TimeSpan(0, 12, 0, 0),
                },
                new Valuta
                {
                    ValutaId = 17,
                    KorisnikId = 3,
                    Naziv = "NZD",
                    Tecaj = 0.2241,
                    SlikaValute = "valute/nzd.jpg",
                    AktivnoOd = new TimeSpan(0, 10, 0, 0),
                    AktivnoDo = new TimeSpan(0, 12, 0, 0),
                },
                new Valuta
                {
                    ValutaId = 18,
                    KorisnikId = 3,
                    Naziv = "PHP",
                    Tecaj = 7.6716,
                    SlikaValute = "valute/php.jpg",
                    AktivnoOd = new TimeSpan(0, 10, 0, 0),
                    AktivnoDo = new TimeSpan(0, 12, 0, 0),
                },
                new Valuta
                {
                    ValutaId = 19,
                    KorisnikId = 3,
                    Naziv = "PLN",
                    Tecaj = 0.6049,
                    SlikaValute = "valute/pln.jpg",
                    AktivnoOd = new TimeSpan(0, 10, 0, 0),
                    AktivnoDo = new TimeSpan(0, 12, 0, 0),
                },
                new Valuta
                {
                    ValutaId = 20,
                    KorisnikId = 3,
                    Naziv = "QAR",
                    Tecaj = 0.5755,
                    SlikaValute = "valute/qar.jpg",
                    AktivnoOd = new TimeSpan(0, 10, 0, 0),
                    AktivnoDo = new TimeSpan(0, 12, 0, 0),
                },
                new Valuta
                {
                    ValutaId = 21,
                    KorisnikId = 3,
                    Naziv = "RUB",
                    Tecaj = 12.1433,
                    SlikaValute = "valute/rub.jpg",
                    AktivnoOd = new TimeSpan(0, 10, 0, 0),
                    AktivnoDo = new TimeSpan(0, 12, 0, 0),
                }
                );

            builder.Entity<Drzava>()
               .HasData(
               new Drzava
               {
                   DrzavaId = 1,
                   Naziv = "Hrvatska",
                   ValutaId = 1,
                   Sirina = "45.06463158257005",
                   Duljina = "14.778615263851686",
                   Slika = "zastave/Croatia.gif",
                   Himna = "himne/Croatia.mp3"
               },
               new Drzava
               {
                   DrzavaId = 2,
                   Naziv = "Sjedinjene Američke Države",
                   ValutaId = 2,
                   Sirina = "39.767798747507975",
                   Duljina = "-101.49306883517498",
                   Slika = "zastave/U.S.A.gif",
                   Himna = "himne/U.S.A.mp3"
               },
               new Drzava
               {
                   DrzavaId = 3,
                   Naziv = "Australija",
                   ValutaId = 3,
                   Sirina = "-24.87274212952918",
                   Duljina = "135.96711378068602",
                   Slika = "zastave/Australia.gif",
                   Himna = "himne/Australia.mp3"
               },
               new Drzava
               {
                   DrzavaId = 4,
                   Naziv = "Bosna i Hercegovina",
                   ValutaId = 4,
                   Sirina = "44.68520412736344",
                   Duljina = "17.705870423942812",
                   Slika = "zastave/Bosnia-Herzegovina.gif",
                   Himna = "himne/Bosnia-Herzegovina.mp3"
               },
               new Drzava
               {
                   DrzavaId = 5,
                   Naziv = "Kanada",
                   ValutaId = 5,
                   Sirina = "57.72584859006902",
                   Duljina = "-103.08745109521944",
                   Slika = "zastave/Canada.gif",
                   Himna = "himne/Canada.mp3"
               },
               new Drzava
               {
                   DrzavaId = 6,
                   Naziv = "Kina",
                   ValutaId = 6,
                   Sirina = "34.56402185615146",
                   Duljina = "103.481279254587",
                   Slika = "zastave/China.gif",
                   Himna = "himne/China.mp3"
               },
               new Drzava
               {
                   DrzavaId = 7,
                   Naziv = "Danska",
                   ValutaId = 7,
                   Sirina = "55.618736707420844",
                   Duljina = "10.025547865453749",
                   Slika = "zastave/Denmark.gif",
                   Himna = "himne/Denmark.mp3"
               },
               new Drzava
               {
                   DrzavaId = 8,
                   Naziv = "Finska",
                   ValutaId = 8,
                   Sirina = "62.06224345303571",
                   Duljina = "26.144040963705947",
                   Slika = "zastave/Finland.gif",
                   Himna = "himne/Finland.mp3"
               },
               new Drzava
               {
                   DrzavaId = 9,
                   Naziv = "Francuska",
                   ValutaId = 8,
                   Sirina = "46.57123870171129",
                   Duljina = "2.0912470815043243",
                   Slika = "zastave/France.gif",
                   Himna = "himne/France.mp3"
               },
               new Drzava
               {
                   DrzavaId = 10,
                   Naziv = "Njemačka",
                   ValutaId = 8,
                   Sirina = "51.0761551229671",
                   Duljina = "10.47342096199992",
                   Slika = "zastave/Germany.gif",
                   Himna = "himne/Germany.mp3"

               },
               new Drzava
               {
                   DrzavaId = 11,
                   Naziv = "Mađarska",
                   ValutaId = 9,
                   Sirina = "47.01648894445974",
                   Duljina = "19.619304268136375",
                   Slika = "zastave/Hungary.gif",
                   Himna = "himne/Hungary.mp3"

               },
               new Drzava
               {
                   DrzavaId = 12,
                   Naziv = "Island",
                   ValutaId = 10,
                   Sirina = "64.97394651610523",
                   Duljina = "-18.6527951194541",
                   Slika = "zastave/Iceland.gif",
                   Himna = "himne/Iceland.mp3"

               },
               new Drzava
               {
                   DrzavaId = 13,
                   ValutaId = 11,
                   Naziv = "Indija",
                   Sirina = "23.114709736909592",
                   Duljina = "79.79321444322021",
                   Slika = "zastave/India.gif",
                   Himna = "himne/India.mp3"

               },
               new Drzava
               {
                   DrzavaId = 14,
                   Naziv = "Iran",
                   ValutaId = 12,
                   Sirina = "32.04739977502531",
                   Duljina = "54.26737475215082",
                   Slika = "zastave/Iran.gif",
                   Himna = "himne/Iran.mp3"

               },
               new Drzava
               {
                   DrzavaId = 15,
                   Naziv = "Izrael",
                   ValutaId = 13,
                   Sirina = "30.97374273492748",
                   Duljina = "34.80662706394255",
                   Slika = "zastave/Israel.gif",
                   Himna = "himne/Israel.mp3"

               },
               new Drzava
               {
                   DrzavaId = 16,
                   Naziv = "Italija",
                   ValutaId = 8,
                   Sirina = "43.0128410718408",
                   Duljina = "12.793975984255507",
                   Slika = "zastave/Italy.gif",
                   Himna = "himne/Italy.mp3"

               },
               new Drzava
               {
                   DrzavaId = 17,
                   Naziv = "Japan",
                   ValutaId = 14,
                   Sirina = "36.554300448993104",
                   Duljina = "138.4659546493385",
                   Slika = "zastave/Japan.gif",
                   Himna = "himne/Japan.mp3"

               },
               new Drzava
               {
                   DrzavaId = 18,
                   Naziv = "Makedonija",
                   ValutaId = 15,
                   Sirina = "41.63867650987654",
                   Duljina = "21.70369910426241",
                   Slika = "zastave/Macedonia.gif",
                   Himna = "himne/Macedonia.mp3"

               },
               new Drzava
               {
                   DrzavaId = 19,
                   Naziv = "Meksiko",
                   ValutaId = 16,
                   Sirina = "23.898167246697277",
                   Duljina = "-102.76330017415548",
                   Slika = "zastave/Mexico.gif",
                   Himna = "himne/Mexico.mp3"

               },
               new Drzava
               {
                   DrzavaId = 20,
                   Naziv = "Novi Zeland",
                   ValutaId = 17,
                   Sirina = "-42.45944241636766",
                   Duljina = "172.48203443267067",
                   Slika = "zastave/New Zealand.gif",
                   Himna = "himne/New Zealand.mp3"

               },
               new Drzava
               {
                   DrzavaId = 21,
                   Naziv = "Filipini",
                   ValutaId = 18,
                   Sirina = "12.522248374750388",
                   Duljina = "122.85021786638886",
                   Slika = "zastave/Philippines.gif",
                   Himna = "himne/Philippines.mp3"

               },
               new Drzava
               {
                   DrzavaId = 22,
                   Naziv = "Poljska",
                   ValutaId = 19,
                   Sirina = "52.89071506172981",
                   Duljina = "18.540027025821185",
                   Slika = "zastave/Poland.gif",
                   Himna = "himne/Poland.mp3"

               },
               new Drzava
               {
                   DrzavaId = 23,
                   Naziv = "Katar",
                   ValutaId = 20,
                   Sirina = "25.313258207010662",
                   Duljina = "51.19014508916761",
                   Slika = "zastave/Qatar.gif",
                   Himna = "himne/Qatar.mp3"

               },
               new Drzava
               {
                   DrzavaId = 24,
                   Naziv = "Rusija",
                   ValutaId = 21,
                   Sirina = "62.20846329274161",
                   Duljina = "93.42813450212664",
                   Slika = "zastave/Russia.gif",
                   Himna = "himne/Russia.mp3"

               });

            builder.Entity<Sredstva>()
                .HasData(
                new Sredstva
                {
                    SredstvaId = 1,
                    KorisnikId = 1,
                    ValutaId = 1,
                    Iznos = 100
                },
                new Sredstva
                {
                    SredstvaId = 2,
                    KorisnikId = 1,
                    ValutaId = 5,
                    Iznos = 150
                },
                new Sredstva
                {
                    SredstvaId = 3,
                    KorisnikId = 1,
                    ValutaId = 8,
                    Iznos = 1000
                },
                new Sredstva
                {
                    SredstvaId = 4,
                    KorisnikId = 5,
                    ValutaId = 7,
                    Iznos = 175
                },
                new Sredstva
                {
                    SredstvaId = 5,
                    KorisnikId = 2,
                    ValutaId = 10,
                    Iznos = 10000
                },
                new Sredstva
                {
                    SredstvaId = 6,
                    KorisnikId = 11,
                    ValutaId = 6,
                    Iznos = 1000000
                },
                new Sredstva
                {
                    SredstvaId = 7,
                    KorisnikId = 3,
                    ValutaId = 4,
                    Iznos = 12345678
                },
                new Sredstva
                {
                    SredstvaId = 8,
                    KorisnikId = 13,
                    ValutaId = 8,
                    Iznos = 80000
                },
                new Sredstva
                {
                    SredstvaId = 9,
                    KorisnikId = 19,
                    ValutaId = 2,
                    Iznos = 100000
                },
                new Sredstva
                {
                    SredstvaId = 10,
                    KorisnikId = 11,
                    ValutaId = 7,
                    Iznos = 100
                },
                new Sredstva
                {
                    SredstvaId = 11,
                    KorisnikId = 5,
                    ValutaId = 11,
                    Iznos = 100
                }
                );


            builder.Entity<Zahtjev>()
                .HasData(
                new Zahtjev
                {
                    ZahtjevId = 1,
                    KorisnikId = 6,
                    Iznos = 100,
                    ProdajemValutaId = 8,
                    KupujemValutaId = 1,
                    DatumVrijemeKreiranja = DateTime.Now,
                    Prihvacen = 2
                },
                new Zahtjev
                {
                    ZahtjevId = 2,
                    KorisnikId = 8,
                    Iznos = 4500,
                    ProdajemValutaId = 1,
                    KupujemValutaId = 8,
                    DatumVrijemeKreiranja = DateTime.Now,
                    Prihvacen = 2
                },
                new Zahtjev
                {
                    ZahtjevId = 3,
                    KorisnikId = 7,
                    Iznos = 1500,
                    ProdajemValutaId = 4,
                    KupujemValutaId = 11,
                    DatumVrijemeKreiranja = DateTime.Now,
                    Prihvacen = 2
                },
                new Zahtjev
                {
                    ZahtjevId = 4,
                    KorisnikId = 10,
                    Iznos = 10000,
                    ProdajemValutaId = 2,
                    KupujemValutaId = 7,
                    DatumVrijemeKreiranja = DateTime.Now,
                    Prihvacen = 2
                },
                new Zahtjev
                {
                    ZahtjevId = 5,
                    KorisnikId = 4,
                    Iznos = 1800,
                    ProdajemValutaId = 8,
                    KupujemValutaId = 9,
                    DatumVrijemeKreiranja = DateTime.Now,
                    Prihvacen = 1
                }
                );

        }
    }
}
