using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ExchangeValuta.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    Ime = table.Column<string>(nullable: true),
                    Prezime = table.Column<string>(nullable: true),
                    Lozinka = table.Column<string>(nullable: true),
                    Slika = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RoleId = table.Column<int>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<int>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    RoleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Valute",
                columns: table => new
                {
                    ValutaId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    KorisnikId = table.Column<int>(nullable: false),
                    Naziv = table.Column<string>(nullable: true),
                    Tecaj = table.Column<double>(nullable: false),
                    SlikaValute = table.Column<string>(nullable: true),
                    AktivnoOd = table.Column<TimeSpan>(nullable: false),
                    AktivnoDo = table.Column<TimeSpan>(nullable: false),
                    DatumAzuriranja = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Valute", x => x.ValutaId);
                    table.ForeignKey(
                        name: "FK_Valute_AspNetUsers_KorisnikId",
                        column: x => x.KorisnikId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Drzave",
                columns: table => new
                {
                    DrzavaId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ValutaId = table.Column<int>(nullable: false),
                    Naziv = table.Column<string>(nullable: true),
                    Sirina = table.Column<string>(nullable: true),
                    Duljina = table.Column<string>(nullable: true),
                    Slika = table.Column<string>(nullable: true),
                    Himna = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drzave", x => x.DrzavaId);
                    table.ForeignKey(
                        name: "FK_Drzave_Valute_ValutaId",
                        column: x => x.ValutaId,
                        principalTable: "Valute",
                        principalColumn: "ValutaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sredstva",
                columns: table => new
                {
                    SredstvaId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    KorisnikId = table.Column<int>(nullable: false),
                    ValutaId = table.Column<int>(nullable: false),
                    Iznos = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sredstva", x => x.SredstvaId);
                    table.ForeignKey(
                        name: "FK_Sredstva_AspNetUsers_KorisnikId",
                        column: x => x.KorisnikId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Sredstva_Valute_ValutaId",
                        column: x => x.ValutaId,
                        principalTable: "Valute",
                        principalColumn: "ValutaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Zahtjevi",
                columns: table => new
                {
                    ZahtjevId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    KorisnikId = table.Column<int>(nullable: false),
                    Iznos = table.Column<double>(nullable: false),
                    ProdajemValutaId = table.Column<int>(nullable: false),
                    KupujemValutaId = table.Column<int>(nullable: false),
                    DatumVrijemeKreiranja = table.Column<DateTime>(nullable: false),
                    Prihvacen = table.Column<int>(nullable: false),
                    ValutaId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zahtjevi", x => x.ZahtjevId);
                    table.ForeignKey(
                        name: "FK_Zahtjevi_AspNetUsers_KorisnikId",
                        column: x => x.KorisnikId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Zahtjevi_Valute_ValutaId",
                        column: x => x.ValutaId,
                        principalTable: "Valute",
                        principalColumn: "ValutaId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { 3, "5a176c77-e947-4087-b2ce-092a67e815f2", "korisnik", "KORISNIK" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { 2, "dc9e2d38-cdbf-4cf8-aa75-192f96879d43", "moderator", "MODERATOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { 1, "a6c132a5-7645-4352-bd32-24faf13fdc33", "administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "Ime", "LockoutEnabled", "LockoutEnd", "Lozinka", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Prezime", "SecurityStamp", "Slika", "TwoFactorEnabled", "UserName" },
                values: new object[] { 29, 0, "61088db5-9c78-437b-ad40-53db9bec8de2", "kreeves@mail.hr", true, "Keanu", true, null, "123456", null, null, "AQAAAAEAACcQAAAAEMfjNcIa8VUQ5Qw/MyH0LY8oRNFFz8KXxYrSEnLWo3gtKtRUi6OAZAB7IrbIgojz/A==", null, false, "Reeves", "098042cb-5f7c-48a4-b709-864cf7ae25f0", "korisnici/kreeves.jpg", false, "kreeves" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "Ime", "LockoutEnabled", "LockoutEnd", "Lozinka", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Prezime", "SecurityStamp", "Slika", "TwoFactorEnabled", "UserName" },
                values: new object[] { 28, 0, "4686153b-1bd2-48f5-a93e-1b6d7d040aac", "jdepp@mail.hr", true, "Johnny", true, null, "123456", null, null, "AQAAAAEAACcQAAAAEGdt8uZ1I5AVEWE2MSqEaZB2AikSObhapEZT/B5HLQZ3UT6+iFbxBsx/tthNoa8+UA==", null, false, "Depp", "cf823e5e-8bbc-42ef-bd64-76c29e47f9bd", "korisnici/jdepp.jpg", false, "jdepp" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "Ime", "LockoutEnabled", "LockoutEnd", "Lozinka", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Prezime", "SecurityStamp", "Slika", "TwoFactorEnabled", "UserName" },
                values: new object[] { 27, 0, "4f6c5940-3b2c-4afb-a0d3-9a5d00b29c3c", "llohan@mail.hr", true, "Lindsay", true, null, "123456", null, null, "AQAAAAEAACcQAAAAEOs0u31YaUPqA80OosY6UKkHdtiXPZsU64NoPTeHbd93s6rAH6d1bW3RoNSiFZn+iQ==", null, false, "Lohan", "91a51d19-1119-4523-b717-9ca3422a90f4", "korisnici/llohan.jpg", false, "llohan" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "Ime", "LockoutEnabled", "LockoutEnd", "Lozinka", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Prezime", "SecurityStamp", "Slika", "TwoFactorEnabled", "UserName" },
                values: new object[] { 26, 0, "ea252c01-9986-4f23-86ab-15ae72b6bf6e", "obloom@mail.hr", true, "Orlando", true, null, "123456", null, null, "AQAAAAEAACcQAAAAENcqYGNlGHxOVepOSLBpojBpH0RALC6gfkfNXZGCW0gDigTcoEQYTb6iols92zCIKA==", null, false, "Bloom", "d42bb2e1-dbdd-404a-bd8e-76bb9c78353d", "korisnici/obloom.jpg", false, "obloom" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "Ime", "LockoutEnabled", "LockoutEnd", "Lozinka", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Prezime", "SecurityStamp", "Slika", "TwoFactorEnabled", "UserName" },
                values: new object[] { 25, 0, "2d38af05-aed8-4ceb-b13a-0e489e9242df", "kknightley@mail.hr", true, "Keira", true, null, "123456", null, null, "AQAAAAEAACcQAAAAEOA+2PEKspeqNM5kHhwj0Hujui5TBsTD1yr9fUhG8BYpWJI6jNwFayIuyzQxUaAxXA==", null, false, "Knightley", "b6169ed2-48a8-492f-870f-9f4535815669", "korisnici/kknightley.jpg", false, "kknightley" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "Ime", "LockoutEnabled", "LockoutEnd", "Lozinka", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Prezime", "SecurityStamp", "Slika", "TwoFactorEnabled", "UserName" },
                values: new object[] { 24, 0, "c99facb6-5b15-47ff-a3aa-50f4fc9536b6", "ajolie@mail.hr", true, "Angelina", true, null, "123456", null, null, "AQAAAAEAACcQAAAAEBPJWMJG6CG9EM98zO9t8OsA7skikaEqcnMxSGJdrfiLD2EdCW46LVtwDyTzvl35Kw==", null, false, "Jolie", "42d33393-e9ff-4b6c-99da-ab37c81d10ea", "korisnici/ajolie.jpg", false, "ajolie" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "Ime", "LockoutEnabled", "LockoutEnd", "Lozinka", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Prezime", "SecurityStamp", "Slika", "TwoFactorEnabled", "UserName" },
                values: new object[] { 15, 0, "43565ea1-7f76-4909-a2bb-87c13f9d2b11", "ctheron@mail.hr", true, "Charlize", true, null, "123456", null, null, "AQAAAAEAACcQAAAAEI8nrei+CHZmcg1BkPGMvw7H76vvs0gbHBSAoU5LKxeFdl/CL/dbOUGK7bdevXVRaw==", null, false, "Theron", "90a5c33b-302d-491f-8a90-e2f8a5727f24", "korisnici/ctheron.jpg", false, "ctheron" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "Ime", "LockoutEnabled", "LockoutEnd", "Lozinka", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Prezime", "SecurityStamp", "Slika", "TwoFactorEnabled", "UserName" },
                values: new object[] { 22, 0, "54ec89f7-7f3a-4fff-a4f8-43a502d308a5", "tcruise@mail.hr", true, "Tom", true, null, "123456", null, null, "AQAAAAEAACcQAAAAEH4j4wAMMT07A3W1mvaJQR3Xn8yXm4w9KOeFy77o6utHZ63of/HAGHjHlQRBdgOVzw==", null, false, "Cruise", "fecd3432-0961-40d6-b7b6-909e56fa99c3", "korisnici/tcruise.jpg", false, "tcruise" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "Ime", "LockoutEnabled", "LockoutEnd", "Lozinka", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Prezime", "SecurityStamp", "Slika", "TwoFactorEnabled", "UserName" },
                values: new object[] { 21, 0, "90f84ef1-1049-43d2-a966-b591ade672f0", "kbeckinsale@mail.hr", true, "Kate", true, null, "123456", null, null, "AQAAAAEAACcQAAAAED3mKZACqzV9uNkfNxIh/AB165J3vIT4wWgElR3nM7V8ptSNQ8XwbU5BAheGcljnyw==", null, false, "Beckinsale", "a8b822c5-42a3-449a-a670-e7bcf252031a", "korisnici/kbeckinsale.jpg", false, "kbeckinsale" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "Ime", "LockoutEnabled", "LockoutEnd", "Lozinka", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Prezime", "SecurityStamp", "Slika", "TwoFactorEnabled", "UserName" },
                values: new object[] { 20, 0, "c38370c2-5807-4fc8-bf73-92d91248aea9", "philton@mail.hr", true, "Paris", true, null, "123456", null, null, "AQAAAAEAACcQAAAAEJ/qEiwwvV/xuZqEXMU+kUrXM9Zk2hdyXky4TdhkZi6ayWfuA4bkVNvM5X6ZL39ryg==", null, false, "Hilton", "164a6947-1f04-4751-b780-cc0badf3f72a", "korisnici/philton.jpg", false, "philton" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "Ime", "LockoutEnabled", "LockoutEnd", "Lozinka", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Prezime", "SecurityStamp", "Slika", "TwoFactorEnabled", "UserName" },
                values: new object[] { 19, 0, "7b5bdf09-30d8-4044-bbd6-eea62f291d83", "sjohansson@mail.hr", true, "Scarlett", true, null, "123456", null, null, "AQAAAAEAACcQAAAAEDiUbghOlv/BymgRJFJirAxsidbn3h9MWTTKEVtvNSdWIM4rQfhcRjKJsc82J9JaLA==", null, false, "Johansson", "e9ec699a-df58-471d-ba72-350e3b92a4fa", "korisnici/sjohansson.jpg", false, "sjohansson" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "Ime", "LockoutEnabled", "LockoutEnd", "Lozinka", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Prezime", "SecurityStamp", "Slika", "TwoFactorEnabled", "UserName" },
                values: new object[] { 17, 0, "f471d1bd-223e-4d19-bb77-e2d7085fb25a", "ewatson@mail.hr", true, "Emma", true, null, "123456", null, null, "AQAAAAEAACcQAAAAEDvhlFR9CY/Fo+Xgl94Gxfaxc6Pnsvs38bxoMKZ+fGWSRPx1iHV6AjWKUZD5WGnVDg==", null, false, "Watson", "29f08bc2-16ef-4987-b10b-fe9dff0f4eb9", "korisnici/ewatson.jpg", false, "ewatson" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "Ime", "LockoutEnabled", "LockoutEnd", "Lozinka", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Prezime", "SecurityStamp", "Slika", "TwoFactorEnabled", "UserName" },
                values: new object[] { 16, 0, "2e014083-fe86-457e-99f2-4d5312ddb284", "nkidman@mail.hr", true, "Nicole", true, null, "123456", null, null, "AQAAAAEAACcQAAAAEAixKjwaW9Fy0EObGrWsDIs3xgxaId4ZtHdudsLJsKNsZqbkuKnuw2hMa3sHvajSxQ==", null, false, "Kidman", "6e08f369-eba0-4eb6-8421-ab889f26ffa6", "korisnici/nkidman.jpg", false, "nkidman" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "Ime", "LockoutEnabled", "LockoutEnd", "Lozinka", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Prezime", "SecurityStamp", "Slika", "TwoFactorEnabled", "UserName" },
                values: new object[] { 23, 0, "c1c743bd-79c6-4756-9c21-9b87ee3064cf", "hduff@mail.hr", true, "Hilary", true, null, "123456", null, null, "AQAAAAEAACcQAAAAENygVIBhiHidej9TrJJ7yhlwzUeGDDyv2Twqaqxwv/oSgMbtlQ8Qna9cQ/oO7H8MkA==", null, false, "Duff", "dc8683b8-b67c-440d-86b8-54bea497e560", "korisnici/hduff.jpg", false, "hduff" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "Ime", "LockoutEnabled", "LockoutEnd", "Lozinka", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Prezime", "SecurityStamp", "Slika", "TwoFactorEnabled", "UserName" },
                values: new object[] { 14, 0, "aa53e7a7-ee49-487c-aca2-4fe2bf4dc563", "janiston@mail.hr", true, "Jennifer", true, null, "123456", null, null, "AQAAAAEAACcQAAAAEHcaHaxPuGA9CIq98pPTnMNWbRIUm2cwMFR8iueR0tovz5rhwipYoo+1QHbmUkzcFQ==", null, false, "Aniston", "9af0be00-4730-4033-b951-1e2025b70d9c", "korisnici/janiston.jpg", false, "janiston" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "Ime", "LockoutEnabled", "LockoutEnd", "Lozinka", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Prezime", "SecurityStamp", "Slika", "TwoFactorEnabled", "UserName" },
                values: new object[] { 12, 0, "deacc1fe-f86a-4228-9018-8e0cb544728b", "vdiesel@mail.hr", true, "Vin", true, null, "123456", null, null, "AQAAAAEAACcQAAAAEETwMFlomY0mHIcnHQBswylv/BZoECOsCGPLHeepLa2h8txT2YYQcfs/aBIA6W7XpQ==", null, false, "Diesel", "ec889ef5-73c8-49fe-984e-52e9da2ef8e9", "korisnici/vdiesel.jpg", false, "vdiesel" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "Ime", "LockoutEnabled", "LockoutEnd", "Lozinka", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Prezime", "SecurityStamp", "Slika", "TwoFactorEnabled", "UserName" },
                values: new object[] { 11, 0, "2de878da-819b-4c57-ad0a-d0dc02bbd7e9", "hberry@mail.hr", true, "Halle", true, null, "123456", null, null, "AQAAAAEAACcQAAAAEIwY2kFuUXsi0oZpawo35DrBajrHezuYhiH0CSVeUAp4rDRmONZSdcf4H/d1CX8BIg==", null, false, "Berry", "3b401eb5-33f4-41d5-91cd-64a6c44ebdc9", "korisnici/hberry.jpg", false, "hberry" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "Ime", "LockoutEnabled", "LockoutEnd", "Lozinka", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Prezime", "SecurityStamp", "Slika", "TwoFactorEnabled", "UserName" },
                values: new object[] { 10, 0, "d8d73c81-366c-46c5-bdbe-01531b511b4b", "dradcliffe@mail.hr", true, "Daniel", true, null, "123456", null, null, "AQAAAAEAACcQAAAAECKhWui0T4TsX5u1JOiWUUJDKoX/eratRmtWQG+co33Y4Kh9MhCYsJhGSCMTCNb3NQ==", null, false, "Radcliffe", "0e8c7a7e-484b-45aa-aba8-f7e6e152db90", "korisnici/dradcliffe.jpg", false, "dradcliffe" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "Ime", "LockoutEnabled", "LockoutEnd", "Lozinka", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Prezime", "SecurityStamp", "Slika", "TwoFactorEnabled", "UserName" },
                values: new object[] { 9, 0, "c88b4ecc-16a9-4488-80aa-7ec18f5f1b0a", "nportman@mail.hr", true, "Natalie", true, null, "123456", null, null, "AQAAAAEAACcQAAAAEPbkzMn1cP/3jVaHrTr5jX3Ax9j66bHTA8qi3fVzDmBjy+yNk/mhdZ6RUaNI+OGTAA==", null, false, "Portman", "4334326c-9ebb-4bd2-83ba-dcb7d51d7f1d", "korisnici/nportman.jpg", false, "nportman" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "Ime", "LockoutEnabled", "LockoutEnd", "Lozinka", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Prezime", "SecurityStamp", "Slika", "TwoFactorEnabled", "UserName" },
                values: new object[] { 8, 0, "175f682a-0790-460c-8419-a86326336f9e", "jgarner@mail.hr", true, "Jennifer", true, null, "123456", null, null, "AQAAAAEAACcQAAAAELCTtIWjNHAZxK2AMOMN/YoHt+E5mBZUiIv2nof/BFWDYk7dhJXjIlwRFQfLlFRymQ==", null, false, "Garner", "98865952-2844-491a-b25b-ae83f0696c4b", "korisnici/jgarner.jpg", false, "jgarner" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "Ime", "LockoutEnabled", "LockoutEnd", "Lozinka", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Prezime", "SecurityStamp", "Slika", "TwoFactorEnabled", "UserName" },
                values: new object[] { 7, 0, "34505f9b-7f20-48d6-8510-a2809822b9b7", "vmortensen@mail.hr", true, "Viggo", true, null, "123456", null, null, "AQAAAAEAACcQAAAAEHzALX70mWtG3YvJ+I/XF1sm4NpWR9ajvBMYHYK9ZB1lzfoqZsob5AkmredECx/efw==", null, false, "Mortensen", "6cf9d37b-4323-49bc-a297-4cf92d59ff27", "korisnici/vmortensen.jpg", false, "vmortensen" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "Ime", "LockoutEnabled", "LockoutEnd", "Lozinka", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Prezime", "SecurityStamp", "Slika", "TwoFactorEnabled", "UserName" },
                values: new object[] { 6, 0, "fb3ae024-aa4c-48aa-a535-45de7dacdbd8", "mbellucci@mail.hr", true, "Monica", true, null, "123456", null, null, "AQAAAAEAACcQAAAAEIgnQHeqzmJ78Le7WruGYCAsTcTzbLyIqs1tV6KBUTb1/XBMTJrvw5Go7KIbiNKINg==", null, false, "Bellucci", "3501249a-ab7d-48a3-bcc3-d107b3d21b6f", "korisnici/mbellucci.jpg", false, "mbellucci" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "Ime", "LockoutEnabled", "LockoutEnd", "Lozinka", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Prezime", "SecurityStamp", "Slika", "TwoFactorEnabled", "UserName" },
                values: new object[] { 5, 0, "5ba8c15b-f1f9-40f6-aee9-cb2f9941e4ee", "qtarantino@mail.hr", true, "Quentin", true, null, "123456", null, null, "AQAAAAEAACcQAAAAEGPBnnqFxEAQqWBCFfb4rX/sbp6wVkHYh8s9264atSBYvUPvNz4ihxYcRSGmmEf1gw==", null, false, "Tarantino", "677697ee-c398-479a-9a0a-84db4585ded1", "korisnici/qtarantino.jpg", false, "qtarantino" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "Ime", "LockoutEnabled", "LockoutEnd", "Lozinka", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Prezime", "SecurityStamp", "Slika", "TwoFactorEnabled", "UserName" },
                values: new object[] { 4, 0, "8cc8ff5c-4a35-40d0-a093-ff1e35184fdd", "vzec@mail.hr", true, "Vladimir", true, null, "123456", null, null, "AQAAAAEAACcQAAAAELgribsdb8UbDzuQvrdblYSyuHCg3QRkqWC22ggDer5lm7/4fDhrX1jvD0veuPbh0Q==", null, false, "Zec", "91a8f871-9545-44a9-a853-c23e2555fe35", "korisnici/vzec.jpg", false, "vzec" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "Ime", "LockoutEnabled", "LockoutEnd", "Lozinka", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Prezime", "SecurityStamp", "Slika", "TwoFactorEnabled", "UserName" },
                values: new object[] { 3, 0, "54f1a475-1bce-426f-b5d6-9453fd94ccb9", "pkos@mail.hr", true, "Pero", true, null, "123456", null, null, "AQAAAAEAACcQAAAAEL7YP5VYh/rcH9Al8twnPhazzjV8DP7Ct18RaXg2QgkISNvGCbUoRsbVCuXOME4JvQ==", null, false, "Kos", "6122a61d-3ccf-42dc-928c-1ef33b6e2090", "korisnici/pkos.jpg", false, "pkos" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "Ime", "LockoutEnabled", "LockoutEnd", "Lozinka", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Prezime", "SecurityStamp", "Slika", "TwoFactorEnabled", "UserName" },
                values: new object[] { 31, 0, "495c5f74-019a-48f4-a58f-05a89d1f9807", "jalba@mail.hr", true, "Jessica", true, null, "123456", null, null, "AQAAAAEAACcQAAAAEAZT8N9+8AwUm08+qs2hwV5BSDgL1q+h3iOgiiosA/5sCh8ILxnSFM3XMYpJja2tYQ==", null, false, "Alba", "6c70f979-5042-441d-b39f-cd38cc14954d", "korisnici/jalba.jpg", false, "jalba" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "Ime", "LockoutEnabled", "LockoutEnd", "Lozinka", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Prezime", "SecurityStamp", "Slika", "TwoFactorEnabled", "UserName" },
                values: new object[] { 30, 0, "3b9d3117-73c4-4e06-959d-0fcc421e34aa", "thanks@mail.hr", true, "Tom", true, null, "123456", null, null, "AQAAAAEAACcQAAAAEPOIbg6fqI0HMQP8PFyqqBPFBp74BpdTsCJBZzkLLbcBXSUglpiAED3VTLJGFxkE7g==", null, false, "Hanks", "58baaf84-9d4f-4fad-bad6-651455e40ff8", "korisnici/thanks.jpg", false, "thanks" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "Ime", "LockoutEnabled", "LockoutEnd", "Lozinka", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Prezime", "SecurityStamp", "Slika", "TwoFactorEnabled", "UserName" },
                values: new object[] { 18, 0, "02a4764a-d4a4-489e-b326-08526ee94bd6", "kdunst@mail.hr", true, "Kirsten", true, null, "123456", null, null, "AQAAAAEAACcQAAAAECCv/+4HSfOLnyYm3AeRnJ/SBK+Oh7I3ugMhq6UJbOnJT7Uhv7f2ztfpGwCYWdKenA==", null, false, "Dunst", "86d6a0a4-c0ca-4f1c-a97d-ecfd43840733", "korisnici/kdunst.jpg", false, "kdunst" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "Ime", "LockoutEnabled", "LockoutEnd", "Lozinka", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Prezime", "SecurityStamp", "Slika", "TwoFactorEnabled", "UserName" },
                values: new object[] { 2, 0, "9ea66269-b105-40d0-9433-fbaee51993b5", null, true, "Voditelj", true, null, "123456", null, null, "AQAAAAEAACcQAAAAEG75YHlIV23UIn6X9/GH0zgK9v/4zVwE/JaTVYM6EFQ9eEZaBjhaCxJIYu/7gMRdRA==", null, false, "Voditelj", "dbcaf770-1625-4eaa-a541-d7e71673c777", "korisnici/admin.jpg", false, "voditelj" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "Ime", "LockoutEnabled", "LockoutEnd", "Lozinka", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Prezime", "SecurityStamp", "Slika", "TwoFactorEnabled", "UserName" },
                values: new object[] { 13, 0, "aaa8805f-58b5-4031-b34f-1e630b4c741f", "ecuthbert@mail.hr", true, "Elisha", true, null, "123456", null, null, "AQAAAAEAACcQAAAAED2cUCVUMkT7+ro+SL3r07h/UHwqmvwkRlGxQfQ8Y/TjWpx/lYdIoDjUwAOc2ETtWw==", null, false, "Cuthbert", "725f193a-14b5-497b-b925-0f4aa34b6496", "korisnici/ecuthbert.jpg", false, "ecuthbert" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "Ime", "LockoutEnabled", "LockoutEnd", "Lozinka", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Prezime", "SecurityStamp", "Slika", "TwoFactorEnabled", "UserName" },
                values: new object[] { 1, 0, "87e653bb-19d5-4ca8-a20c-c2e546e176b7", null, true, "Administrator", true, null, "admin", null, null, "AQAAAAEAACcQAAAAEFYqoZmO5NbtcQUY/cPmKyt4bZdcBfe6H5bv+Uw72FwjH13Fe/gZr8ZT8es7Y1dLCg==", null, false, "Administrator", "0ce5eb77-f317-4e88-9321-641f2a28ab87", "korisnici/admin.jpg", false, "admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { 1, 2 });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { 4, 2 });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { 10, 2 });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { 5, 3 });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { 6, 3 });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { 7, 3 });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { 8, 3 });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { 9, 3 });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { 11, 3 });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { 12, 3 });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { 13, 3 });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { 14, 3 });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { 3, 2 });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { 15, 3 });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { 17, 3 });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { 18, 3 });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { 19, 3 });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { 20, 3 });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { 21, 3 });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { 22, 3 });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { 23, 3 });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { 24, 3 });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { 25, 3 });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { 26, 3 });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { 27, 3 });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { 16, 3 });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { 2, 2 });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { 29, 3 });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { 1, 1 });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { 28, 3 });

            migrationBuilder.InsertData(
                table: "Valute",
                columns: new[] { "ValutaId", "AktivnoDo", "AktivnoOd", "DatumAzuriranja", "KorisnikId", "Naziv", "SlikaValute", "Tecaj" },
                values: new object[] { 2, new TimeSpan(0, 12, 0, 0, 0), new TimeSpan(0, 10, 0, 0, 0), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "USD", "valute/dolar.jpg", 0.15809999999999999 });

            migrationBuilder.InsertData(
                table: "Valute",
                columns: new[] { "ValutaId", "AktivnoDo", "AktivnoOd", "DatumAzuriranja", "KorisnikId", "Naziv", "SlikaValute", "Tecaj" },
                values: new object[] { 9, new TimeSpan(0, 12, 0, 0, 0), new TimeSpan(0, 10, 0, 0, 0), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "HUF", "valute/huf.jpg", 47.744599999999998 });

            migrationBuilder.InsertData(
                table: "Valute",
                columns: new[] { "ValutaId", "AktivnoDo", "AktivnoOd", "DatumAzuriranja", "KorisnikId", "Naziv", "SlikaValute", "Tecaj" },
                values: new object[] { 11, new TimeSpan(0, 12, 0, 0, 0), new TimeSpan(0, 10, 0, 0, 0), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "INR", "valute/inr.jpg", 11.758599999999999 });

            migrationBuilder.InsertData(
                table: "Valute",
                columns: new[] { "ValutaId", "AktivnoDo", "AktivnoOd", "DatumAzuriranja", "KorisnikId", "Naziv", "SlikaValute", "Tecaj" },
                values: new object[] { 12, new TimeSpan(0, 12, 0, 0, 0), new TimeSpan(0, 10, 0, 0, 0), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "IRR", "valute/irr.jpg", 6602.1956 });

            migrationBuilder.InsertData(
                table: "Valute",
                columns: new[] { "ValutaId", "AktivnoDo", "AktivnoOd", "DatumAzuriranja", "KorisnikId", "Naziv", "SlikaValute", "Tecaj" },
                values: new object[] { 15, new TimeSpan(0, 12, 0, 0, 0), new TimeSpan(0, 10, 0, 0, 0), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "MKD", "valute/mkd.jpg", 8.1780000000000008 });

            migrationBuilder.InsertData(
                table: "Valute",
                columns: new[] { "ValutaId", "AktivnoDo", "AktivnoOd", "DatumAzuriranja", "KorisnikId", "Naziv", "SlikaValute", "Tecaj" },
                values: new object[] { 3, new TimeSpan(0, 12, 0, 0, 0), new TimeSpan(0, 10, 0, 0, 0), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "AUD", "valute/australskidolar.jpg", 0.20660000000000001 });

            migrationBuilder.InsertData(
                table: "Valute",
                columns: new[] { "ValutaId", "AktivnoDo", "AktivnoOd", "DatumAzuriranja", "KorisnikId", "Naziv", "SlikaValute", "Tecaj" },
                values: new object[] { 4, new TimeSpan(0, 12, 0, 0, 0), new TimeSpan(0, 10, 0, 0, 0), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "BAM", "valute/bam.gif", 0.2596 });

            migrationBuilder.InsertData(
                table: "Valute",
                columns: new[] { "ValutaId", "AktivnoDo", "AktivnoOd", "DatumAzuriranja", "KorisnikId", "Naziv", "SlikaValute", "Tecaj" },
                values: new object[] { 10, new TimeSpan(0, 12, 0, 0, 0), new TimeSpan(0, 10, 0, 0, 0), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "ISK", "valute/isk.jpg", 20.005800000000001 });

            migrationBuilder.InsertData(
                table: "Valute",
                columns: new[] { "ValutaId", "AktivnoDo", "AktivnoOd", "DatumAzuriranja", "KorisnikId", "Naziv", "SlikaValute", "Tecaj" },
                values: new object[] { 13, new TimeSpan(0, 12, 0, 0, 0), new TimeSpan(0, 10, 0, 0, 0), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "ILS", "valute/ils.jpg", 0.52090000000000003 });

            migrationBuilder.InsertData(
                table: "Valute",
                columns: new[] { "ValutaId", "AktivnoDo", "AktivnoOd", "DatumAzuriranja", "KorisnikId", "Naziv", "SlikaValute", "Tecaj" },
                values: new object[] { 14, new TimeSpan(0, 12, 0, 0, 0), new TimeSpan(0, 10, 0, 0, 0), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "JPY", "valute/jpy.jpg", 17.270399999999999 });

            migrationBuilder.InsertData(
                table: "Valute",
                columns: new[] { "ValutaId", "AktivnoDo", "AktivnoOd", "DatumAzuriranja", "KorisnikId", "Naziv", "SlikaValute", "Tecaj" },
                values: new object[] { 16, new TimeSpan(0, 12, 0, 0, 0), new TimeSpan(0, 10, 0, 0, 0), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "MXN", "valute/mxn.jpg", 3.1829000000000001 });

            migrationBuilder.InsertData(
                table: "Valute",
                columns: new[] { "ValutaId", "AktivnoDo", "AktivnoOd", "DatumAzuriranja", "KorisnikId", "Naziv", "SlikaValute", "Tecaj" },
                values: new object[] { 17, new TimeSpan(0, 12, 0, 0, 0), new TimeSpan(0, 10, 0, 0, 0), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "NZD", "valute/nzd.jpg", 0.22409999999999999 });

            migrationBuilder.InsertData(
                table: "Valute",
                columns: new[] { "ValutaId", "AktivnoDo", "AktivnoOd", "DatumAzuriranja", "KorisnikId", "Naziv", "SlikaValute", "Tecaj" },
                values: new object[] { 18, new TimeSpan(0, 12, 0, 0, 0), new TimeSpan(0, 10, 0, 0, 0), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "PHP", "valute/php.jpg", 7.6715999999999998 });

            migrationBuilder.InsertData(
                table: "Valute",
                columns: new[] { "ValutaId", "AktivnoDo", "AktivnoOd", "DatumAzuriranja", "KorisnikId", "Naziv", "SlikaValute", "Tecaj" },
                values: new object[] { 20, new TimeSpan(0, 12, 0, 0, 0), new TimeSpan(0, 10, 0, 0, 0), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "QAR", "valute/qar.jpg", 0.57550000000000001 });

            migrationBuilder.InsertData(
                table: "Valute",
                columns: new[] { "ValutaId", "AktivnoDo", "AktivnoOd", "DatumAzuriranja", "KorisnikId", "Naziv", "SlikaValute", "Tecaj" },
                values: new object[] { 21, new TimeSpan(0, 12, 0, 0, 0), new TimeSpan(0, 10, 0, 0, 0), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "RUB", "valute/rub.jpg", 12.1433 });

            migrationBuilder.InsertData(
                table: "Valute",
                columns: new[] { "ValutaId", "AktivnoDo", "AktivnoOd", "DatumAzuriranja", "KorisnikId", "Naziv", "SlikaValute", "Tecaj" },
                values: new object[] { 5, new TimeSpan(0, 12, 0, 0, 0), new TimeSpan(0, 10, 0, 0, 0), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "CAD", "valute/cad.jpg", 0.19869999999999999 });

            migrationBuilder.InsertData(
                table: "Valute",
                columns: new[] { "ValutaId", "AktivnoDo", "AktivnoOd", "DatumAzuriranja", "KorisnikId", "Naziv", "SlikaValute", "Tecaj" },
                values: new object[] { 6, new TimeSpan(0, 12, 0, 0, 0), new TimeSpan(0, 10, 0, 0, 0), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "CNY", "valute/cny.jpg", 1.0338000000000001 });

            migrationBuilder.InsertData(
                table: "Valute",
                columns: new[] { "ValutaId", "AktivnoDo", "AktivnoOd", "DatumAzuriranja", "KorisnikId", "Naziv", "SlikaValute", "Tecaj" },
                values: new object[] { 7, new TimeSpan(0, 12, 0, 0, 0), new TimeSpan(0, 10, 0, 0, 0), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "DKK", "valute/dkk.jpg", 0.99019999999999997 });

            migrationBuilder.InsertData(
                table: "Valute",
                columns: new[] { "ValutaId", "AktivnoDo", "AktivnoOd", "DatumAzuriranja", "KorisnikId", "Naziv", "SlikaValute", "Tecaj" },
                values: new object[] { 8, new TimeSpan(0, 12, 0, 0, 0), new TimeSpan(0, 10, 0, 0, 0), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "EUR", "valute/EUR.jpg", 0.13270000000000001 });

            migrationBuilder.InsertData(
                table: "Valute",
                columns: new[] { "ValutaId", "AktivnoDo", "AktivnoOd", "DatumAzuriranja", "KorisnikId", "Naziv", "SlikaValute", "Tecaj" },
                values: new object[] { 19, new TimeSpan(0, 12, 0, 0, 0), new TimeSpan(0, 10, 0, 0, 0), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "PLN", "valute/pln.jpg", 0.60489999999999999 });

            migrationBuilder.InsertData(
                table: "Valute",
                columns: new[] { "ValutaId", "AktivnoDo", "AktivnoOd", "DatumAzuriranja", "KorisnikId", "Naziv", "SlikaValute", "Tecaj" },
                values: new object[] { 1, new TimeSpan(0, 12, 0, 0, 0), new TimeSpan(0, 10, 0, 0, 0), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "HRK", "valute/", 1.0 });

            migrationBuilder.InsertData(
                table: "Zahtjevi",
                columns: new[] { "ZahtjevId", "DatumVrijemeKreiranja", "Iznos", "KorisnikId", "KupujemValutaId", "Prihvacen", "ProdajemValutaId", "ValutaId" },
                values: new object[] { 5, new DateTime(2021, 4, 16, 13, 19, 1, 666, DateTimeKind.Local).AddTicks(6492), 1800.0, 4, 9, 1, 8, null });

            migrationBuilder.InsertData(
                table: "Zahtjevi",
                columns: new[] { "ZahtjevId", "DatumVrijemeKreiranja", "Iznos", "KorisnikId", "KupujemValutaId", "Prihvacen", "ProdajemValutaId", "ValutaId" },
                values: new object[] { 1, new DateTime(2021, 4, 16, 13, 19, 1, 661, DateTimeKind.Local).AddTicks(6839), 100.0, 6, 1, 2, 8, null });

            migrationBuilder.InsertData(
                table: "Zahtjevi",
                columns: new[] { "ZahtjevId", "DatumVrijemeKreiranja", "Iznos", "KorisnikId", "KupujemValutaId", "Prihvacen", "ProdajemValutaId", "ValutaId" },
                values: new object[] { 3, new DateTime(2021, 4, 16, 13, 19, 1, 666, DateTimeKind.Local).AddTicks(6481), 1500.0, 7, 11, 2, 4, null });

            migrationBuilder.InsertData(
                table: "Zahtjevi",
                columns: new[] { "ZahtjevId", "DatumVrijemeKreiranja", "Iznos", "KorisnikId", "KupujemValutaId", "Prihvacen", "ProdajemValutaId", "ValutaId" },
                values: new object[] { 2, new DateTime(2021, 4, 16, 13, 19, 1, 666, DateTimeKind.Local).AddTicks(6416), 4500.0, 8, 8, 2, 1, null });

            migrationBuilder.InsertData(
                table: "Zahtjevi",
                columns: new[] { "ZahtjevId", "DatumVrijemeKreiranja", "Iznos", "KorisnikId", "KupujemValutaId", "Prihvacen", "ProdajemValutaId", "ValutaId" },
                values: new object[] { 4, new DateTime(2021, 4, 16, 13, 19, 1, 666, DateTimeKind.Local).AddTicks(6487), 10000.0, 10, 7, 2, 2, null });

            migrationBuilder.InsertData(
                table: "Drzave",
                columns: new[] { "DrzavaId", "Duljina", "Himna", "Naziv", "Sirina", "Slika", "ValutaId" },
                values: new object[] { 1, "14.778615263851686", "himne/Croatia.mp3", "Hrvatska", "45.06463158257005", "zastave/Croatia.gif", 1 });

            migrationBuilder.InsertData(
                table: "Drzave",
                columns: new[] { "DrzavaId", "Duljina", "Himna", "Naziv", "Sirina", "Slika", "ValutaId" },
                values: new object[] { 16, "12.793975984255507", "himne/Italy.mp3", "Italija", "43.0128410718408", "zastave/Italy.gif", 8 });

            migrationBuilder.InsertData(
                table: "Drzave",
                columns: new[] { "DrzavaId", "Duljina", "Himna", "Naziv", "Sirina", "Slika", "ValutaId" },
                values: new object[] { 10, "10.47342096199992", "himne/Germany.mp3", "Njemačka", "51.0761551229671", "zastave/Germany.gif", 8 });

            migrationBuilder.InsertData(
                table: "Drzave",
                columns: new[] { "DrzavaId", "Duljina", "Himna", "Naziv", "Sirina", "Slika", "ValutaId" },
                values: new object[] { 9, "2.0912470815043243", "himne/France.mp3", "Francuska", "46.57123870171129", "zastave/France.gif", 8 });

            migrationBuilder.InsertData(
                table: "Drzave",
                columns: new[] { "DrzavaId", "Duljina", "Himna", "Naziv", "Sirina", "Slika", "ValutaId" },
                values: new object[] { 8, "26.144040963705947", "himne/Finland.mp3", "Finska", "62.06224345303571", "zastave/Finland.gif", 8 });

            migrationBuilder.InsertData(
                table: "Drzave",
                columns: new[] { "DrzavaId", "Duljina", "Himna", "Naziv", "Sirina", "Slika", "ValutaId" },
                values: new object[] { 7, "10.025547865453749", "himne/Denmark.mp3", "Danska", "55.618736707420844", "zastave/Denmark.gif", 7 });

            migrationBuilder.InsertData(
                table: "Drzave",
                columns: new[] { "DrzavaId", "Duljina", "Himna", "Naziv", "Sirina", "Slika", "ValutaId" },
                values: new object[] { 6, "103.481279254587", "himne/China.mp3", "Kina", "34.56402185615146", "zastave/China.gif", 6 });

            migrationBuilder.InsertData(
                table: "Drzave",
                columns: new[] { "DrzavaId", "Duljina", "Himna", "Naziv", "Sirina", "Slika", "ValutaId" },
                values: new object[] { 5, "-103.08745109521944", "himne/Canada.mp3", "Kanada", "57.72584859006902", "zastave/Canada.gif", 5 });

            migrationBuilder.InsertData(
                table: "Drzave",
                columns: new[] { "DrzavaId", "Duljina", "Himna", "Naziv", "Sirina", "Slika", "ValutaId" },
                values: new object[] { 24, "93.42813450212664", "himne/Russia.mp3", "Rusija", "62.20846329274161", "zastave/Russia.gif", 21 });

            migrationBuilder.InsertData(
                table: "Drzave",
                columns: new[] { "DrzavaId", "Duljina", "Himna", "Naziv", "Sirina", "Slika", "ValutaId" },
                values: new object[] { 23, "51.19014508916761", "himne/Qatar.mp3", "Katar", "25.313258207010662", "zastave/Qatar.gif", 20 });

            migrationBuilder.InsertData(
                table: "Drzave",
                columns: new[] { "DrzavaId", "Duljina", "Himna", "Naziv", "Sirina", "Slika", "ValutaId" },
                values: new object[] { 22, "18.540027025821185", "himne/Poland.mp3", "Poljska", "52.89071506172981", "zastave/Poland.gif", 19 });

            migrationBuilder.InsertData(
                table: "Drzave",
                columns: new[] { "DrzavaId", "Duljina", "Himna", "Naziv", "Sirina", "Slika", "ValutaId" },
                values: new object[] { 21, "122.85021786638886", "himne/Philippines.mp3", "Filipini", "12.522248374750388", "zastave/Philippines.gif", 18 });

            migrationBuilder.InsertData(
                table: "Drzave",
                columns: new[] { "DrzavaId", "Duljina", "Himna", "Naziv", "Sirina", "Slika", "ValutaId" },
                values: new object[] { 19, "-102.76330017415548", "himne/Mexico.mp3", "Meksiko", "23.898167246697277", "zastave/Mexico.gif", 16 });

            migrationBuilder.InsertData(
                table: "Drzave",
                columns: new[] { "DrzavaId", "Duljina", "Himna", "Naziv", "Sirina", "Slika", "ValutaId" },
                values: new object[] { 17, "138.4659546493385", "himne/Japan.mp3", "Japan", "36.554300448993104", "zastave/Japan.gif", 14 });

            migrationBuilder.InsertData(
                table: "Drzave",
                columns: new[] { "DrzavaId", "Duljina", "Himna", "Naziv", "Sirina", "Slika", "ValutaId" },
                values: new object[] { 20, "172.48203443267067", "himne/New Zealand.mp3", "Novi Zeland", "-42.45944241636766", "zastave/New Zealand.gif", 17 });

            migrationBuilder.InsertData(
                table: "Drzave",
                columns: new[] { "DrzavaId", "Duljina", "Himna", "Naziv", "Sirina", "Slika", "ValutaId" },
                values: new object[] { 12, "-18.6527951194541", "himne/Iceland.mp3", "Island", "64.97394651610523", "zastave/Iceland.gif", 10 });

            migrationBuilder.InsertData(
                table: "Drzave",
                columns: new[] { "DrzavaId", "Duljina", "Himna", "Naziv", "Sirina", "Slika", "ValutaId" },
                values: new object[] { 2, "-101.49306883517498", "himne/U.S.A.mp3", "Sjedinjene Američke Države", "39.767798747507975", "zastave/U.S.A.gif", 2 });

            migrationBuilder.InsertData(
                table: "Drzave",
                columns: new[] { "DrzavaId", "Duljina", "Himna", "Naziv", "Sirina", "Slika", "ValutaId" },
                values: new object[] { 4, "17.705870423942812", "himne/Bosnia-Herzegovina.mp3", "Bosna i Hercegovina", "44.68520412736344", "zastave/Bosnia-Herzegovina.gif", 4 });

            migrationBuilder.InsertData(
                table: "Drzave",
                columns: new[] { "DrzavaId", "Duljina", "Himna", "Naziv", "Sirina", "Slika", "ValutaId" },
                values: new object[] { 3, "135.96711378068602", "himne/Australia.mp3", "Australija", "-24.87274212952918", "zastave/Australia.gif", 3 });

            migrationBuilder.InsertData(
                table: "Drzave",
                columns: new[] { "DrzavaId", "Duljina", "Himna", "Naziv", "Sirina", "Slika", "ValutaId" },
                values: new object[] { 18, "21.70369910426241", "himne/Macedonia.mp3", "Makedonija", "41.63867650987654", "zastave/Macedonia.gif", 15 });

            migrationBuilder.InsertData(
                table: "Drzave",
                columns: new[] { "DrzavaId", "Duljina", "Himna", "Naziv", "Sirina", "Slika", "ValutaId" },
                values: new object[] { 14, "54.26737475215082", "himne/Iran.mp3", "Iran", "32.04739977502531", "zastave/Iran.gif", 12 });

            migrationBuilder.InsertData(
                table: "Drzave",
                columns: new[] { "DrzavaId", "Duljina", "Himna", "Naziv", "Sirina", "Slika", "ValutaId" },
                values: new object[] { 15, "34.80662706394255", "himne/Israel.mp3", "Izrael", "30.97374273492748", "zastave/Israel.gif", 13 });

            migrationBuilder.InsertData(
                table: "Drzave",
                columns: new[] { "DrzavaId", "Duljina", "Himna", "Naziv", "Sirina", "Slika", "ValutaId" },
                values: new object[] { 11, "19.619304268136375", "himne/Hungary.mp3", "Mađarska", "47.01648894445974", "zastave/Hungary.gif", 9 });

            migrationBuilder.InsertData(
                table: "Drzave",
                columns: new[] { "DrzavaId", "Duljina", "Himna", "Naziv", "Sirina", "Slika", "ValutaId" },
                values: new object[] { 13, "79.79321444322021", "himne/India.mp3", "Indija", "23.114709736909592", "zastave/India.gif", 11 });

            migrationBuilder.InsertData(
                table: "Sredstva",
                columns: new[] { "SredstvaId", "Iznos", "KorisnikId", "ValutaId" },
                values: new object[] { 5, 10000.0, 2, 10 });

            migrationBuilder.InsertData(
                table: "Sredstva",
                columns: new[] { "SredstvaId", "Iznos", "KorisnikId", "ValutaId" },
                values: new object[] { 1, 100.0, 1, 1 });

            migrationBuilder.InsertData(
                table: "Sredstva",
                columns: new[] { "SredstvaId", "Iznos", "KorisnikId", "ValutaId" },
                values: new object[] { 9, 100000.0, 19, 2 });

            migrationBuilder.InsertData(
                table: "Sredstva",
                columns: new[] { "SredstvaId", "Iznos", "KorisnikId", "ValutaId" },
                values: new object[] { 10, 100.0, 11, 7 });

            migrationBuilder.InsertData(
                table: "Sredstva",
                columns: new[] { "SredstvaId", "Iznos", "KorisnikId", "ValutaId" },
                values: new object[] { 11, 100.0, 5, 11 });

            migrationBuilder.InsertData(
                table: "Sredstva",
                columns: new[] { "SredstvaId", "Iznos", "KorisnikId", "ValutaId" },
                values: new object[] { 6, 1000000.0, 11, 6 });

            migrationBuilder.InsertData(
                table: "Sredstva",
                columns: new[] { "SredstvaId", "Iznos", "KorisnikId", "ValutaId" },
                values: new object[] { 2, 150.0, 1, 5 });

            migrationBuilder.InsertData(
                table: "Sredstva",
                columns: new[] { "SredstvaId", "Iznos", "KorisnikId", "ValutaId" },
                values: new object[] { 7, 12345678.0, 3, 4 });

            migrationBuilder.InsertData(
                table: "Sredstva",
                columns: new[] { "SredstvaId", "Iznos", "KorisnikId", "ValutaId" },
                values: new object[] { 3, 1000.0, 1, 8 });

            migrationBuilder.InsertData(
                table: "Sredstva",
                columns: new[] { "SredstvaId", "Iznos", "KorisnikId", "ValutaId" },
                values: new object[] { 4, 175.0, 5, 7 });

            migrationBuilder.InsertData(
                table: "Sredstva",
                columns: new[] { "SredstvaId", "Iznos", "KorisnikId", "ValutaId" },
                values: new object[] { 8, 80000.0, 13, 8 });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Drzave_ValutaId",
                table: "Drzave",
                column: "ValutaId");

            migrationBuilder.CreateIndex(
                name: "IX_Sredstva_KorisnikId",
                table: "Sredstva",
                column: "KorisnikId");

            migrationBuilder.CreateIndex(
                name: "IX_Sredstva_ValutaId",
                table: "Sredstva",
                column: "ValutaId");

            migrationBuilder.CreateIndex(
                name: "IX_Valute_KorisnikId",
                table: "Valute",
                column: "KorisnikId");

            migrationBuilder.CreateIndex(
                name: "IX_Zahtjevi_KorisnikId",
                table: "Zahtjevi",
                column: "KorisnikId");

            migrationBuilder.CreateIndex(
                name: "IX_Zahtjevi_ValutaId",
                table: "Zahtjevi",
                column: "ValutaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Drzave");

            migrationBuilder.DropTable(
                name: "Sredstva");

            migrationBuilder.DropTable(
                name: "Zahtjevi");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Valute");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
