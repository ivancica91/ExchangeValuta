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
                values: new object[] { 3, "df018059-5b02-46f4-a756-585e82ac01e4", "korisnik", "KORISNIK" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { 2, "f71b2253-bc8e-408a-b031-84875becb9dc", "moderator", "MODERATOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { 1, "e38ab0c8-4a10-4ed5-9554-c4027216b654", "administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "Ime", "LockoutEnabled", "LockoutEnd", "Lozinka", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Prezime", "SecurityStamp", "Slika", "TwoFactorEnabled", "UserName" },
                values: new object[] { 29, 0, "967c02f9-81f2-4dcf-9be9-e581b2f45bc1", "kreeves@mail.hr", true, "Keanu", true, null, "123456", null, "KREVEES", "AQAAAAEAACcQAAAAEOLkQbIN0WOuuoOA2Z2ZNAj4Ncx9XCmqED/AErnmjvGwdmInlOOpI3oUbgYw+sTFdQ==", null, false, "Reeves", "ce4e4f9c-71d7-419a-b51c-c9e0559c32ad", "korisnici/kreeves.jpg", false, "kreeves" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "Ime", "LockoutEnabled", "LockoutEnd", "Lozinka", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Prezime", "SecurityStamp", "Slika", "TwoFactorEnabled", "UserName" },
                values: new object[] { 28, 0, "657c1740-5b86-4da6-b357-3c733a98f211", "jdepp@mail.hr", true, "Johnny", true, null, "123456", null, "JDEPP", "AQAAAAEAACcQAAAAEFpReo9mHR+nxCPKBPgEVyQwgucGgTWXJKvgzuHz/Q0l/qj+cR4Msf8422rJN8SYOg==", null, false, "Depp", "5a4d8261-318a-43bb-b4ea-064b44ef106a", "korisnici/jdepp.jpg", false, "jdepp" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "Ime", "LockoutEnabled", "LockoutEnd", "Lozinka", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Prezime", "SecurityStamp", "Slika", "TwoFactorEnabled", "UserName" },
                values: new object[] { 27, 0, "f4337d6c-37e1-4b4e-881f-939913fc44ae", "llohan@mail.hr", true, "Lindsay", true, null, "123456", null, "LLOHAN", "AQAAAAEAACcQAAAAEFZBdI4+ovpD5B0zPH+DIp2uJuY3O92tp1FYZTncklRtkvP5PO6SCKg/EWB9voTmLg==", null, false, "Lohan", "27c6b724-686b-409f-a625-bc91fcacaea1", "korisnici/llohan.jpg", false, "llohan" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "Ime", "LockoutEnabled", "LockoutEnd", "Lozinka", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Prezime", "SecurityStamp", "Slika", "TwoFactorEnabled", "UserName" },
                values: new object[] { 26, 0, "27842b2f-3181-4d8f-8394-8c7a458384f1", "obloom@mail.hr", true, "Orlando", true, null, "123456", null, "OBLOOM", "AQAAAAEAACcQAAAAEOggEzbquvMVOrSdNMxEwstJwDlSFLjd8BWYdypCA+wLwKBQV0Pp5FfeBlYCQGby7w==", null, false, "Bloom", "a922b59a-fdcf-45bd-b083-31075811d371", "korisnici/obloom.jpg", false, "obloom" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "Ime", "LockoutEnabled", "LockoutEnd", "Lozinka", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Prezime", "SecurityStamp", "Slika", "TwoFactorEnabled", "UserName" },
                values: new object[] { 25, 0, "91cd700e-388b-4ec3-96d5-71ce79ce8760", "kknightley@mail.hr", true, "Keira", true, null, "123456", null, "KKNIGHTLEY", "AQAAAAEAACcQAAAAEP2q8GdghUIMfZRLIgeRo26r+HJSAyNXFMJmieNQKwQR2c+83mgA10MCIybVkjODOg==", null, false, "Knightley", "bfb6b7a8-5514-485a-9e77-18c70fad2859", "korisnici/kknightley.jpg", false, "kknightley" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "Ime", "LockoutEnabled", "LockoutEnd", "Lozinka", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Prezime", "SecurityStamp", "Slika", "TwoFactorEnabled", "UserName" },
                values: new object[] { 24, 0, "48d33784-6519-4928-ac38-90a55c691dd6", "ajolie@mail.hr", true, "Angelina", true, null, "123456", null, "AJOLIE", "AQAAAAEAACcQAAAAEByjwVD/DR2grCY00CXmjxhlZUMyqXXhbOfr3biBGF1/EAI3UPw8SstnqLxTGI7dPQ==", null, false, "Jolie", "2523f3cf-b1f1-4ea7-9da4-d1a2d36e1276", "korisnici/ajolie.jpg", false, "ajolie" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "Ime", "LockoutEnabled", "LockoutEnd", "Lozinka", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Prezime", "SecurityStamp", "Slika", "TwoFactorEnabled", "UserName" },
                values: new object[] { 15, 0, "76b3a4bc-cb1b-4b62-af89-7a0b7eacae25", "ctheron@mail.hr", true, "Charlize", true, null, "123456", null, "CTHERON", "AQAAAAEAACcQAAAAEOApeLR3dthV2yH7HQwwzdrIJWFGTneB22onQTluk3MO/jTqCAtmhkYRWJbjYnBvtA==", null, false, "Theron", "dc5c05ff-04bc-41e1-9cf8-dd8a1bd753ca", "korisnici/ctheron.jpg", false, "ctheron" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "Ime", "LockoutEnabled", "LockoutEnd", "Lozinka", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Prezime", "SecurityStamp", "Slika", "TwoFactorEnabled", "UserName" },
                values: new object[] { 22, 0, "e956fcda-1784-4168-9810-e0bcdb4a6d23", "tcruise@mail.hr", true, "Tom", true, null, "123456", null, "TCRUISE", "AQAAAAEAACcQAAAAEOo7WXQkS8GB+mzCdoJFaQOEFnH3GWpnsBtqkzbhfMDWQIA/JVKf7tPLS779bQif/Q==", null, false, "Cruise", "67ca3872-9dd0-444b-bba4-7677f2d6ae3b", "korisnici/tcruise.jpg", false, "tcruise" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "Ime", "LockoutEnabled", "LockoutEnd", "Lozinka", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Prezime", "SecurityStamp", "Slika", "TwoFactorEnabled", "UserName" },
                values: new object[] { 21, 0, "3bb44daa-ce7a-41c8-a2d3-72018237180c", "kbeckinsale@mail.hr", true, "Kate", true, null, "123456", null, "KBECKINSALE", "AQAAAAEAACcQAAAAEPQNyRZefVD5XkBI6W+fiI/MBHPqNi8xlfNXzWeF41ESiEAN3ZGkGGaiWgRgN//GLQ==", null, false, "Beckinsale", "9646025e-f3fe-4c1c-9ceb-f5411bedfdb9", "korisnici/kbeckinsale.jpg", false, "kbeckinsale" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "Ime", "LockoutEnabled", "LockoutEnd", "Lozinka", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Prezime", "SecurityStamp", "Slika", "TwoFactorEnabled", "UserName" },
                values: new object[] { 20, 0, "2d6c2aaf-ee8c-4995-8952-926028fa15d4", "philton@mail.hr", true, "Paris", true, null, "123456", null, "PHILTON", "AQAAAAEAACcQAAAAEGHk8YDLTV4YnC0Zd7XCgfJKrZ82176GGcKFeaRDyGfXsd6630Hbd4Zdae1klUlmgw==", null, false, "Hilton", "cf4c63f5-cea0-46c3-b7ab-11e23efa6e51", "korisnici/philton.jpg", false, "philton" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "Ime", "LockoutEnabled", "LockoutEnd", "Lozinka", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Prezime", "SecurityStamp", "Slika", "TwoFactorEnabled", "UserName" },
                values: new object[] { 19, 0, "37737885-6222-46c7-9d32-6ed41757f2d2", "sjohansson@mail.hr", true, "Scarlett", true, null, "123456", null, "SJOHANSSON", "AQAAAAEAACcQAAAAEIyqwQ/pu0Cp7+ZSM5IqstK8c22Jvsqs0/qk+XEdvKoicge0Jago3WRa567/PZGDDQ==", null, false, "Johansson", "466accf5-1824-482f-8e3c-758472e2d5f6", "korisnici/sjohansson.jpg", false, "sjohansson" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "Ime", "LockoutEnabled", "LockoutEnd", "Lozinka", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Prezime", "SecurityStamp", "Slika", "TwoFactorEnabled", "UserName" },
                values: new object[] { 17, 0, "ad89698f-f701-41a1-8678-46c466f31b3e", "ewatson@mail.hr", true, "Emma", true, null, "123456", null, "EWATSON", "AQAAAAEAACcQAAAAELNYewtWjE91JubBP+WAx6BW/8/QeNWJ95P+cSdBbhydk1GtT/SNsnbehhYNZqDHjA==", null, false, "Watson", "d30556b3-4997-416b-85d3-8f8b406289de", "korisnici/ewatson.jpg", false, "ewatson" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "Ime", "LockoutEnabled", "LockoutEnd", "Lozinka", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Prezime", "SecurityStamp", "Slika", "TwoFactorEnabled", "UserName" },
                values: new object[] { 16, 0, "d2b27c09-b279-45c9-a322-4e37e6798b94", "nkidman@mail.hr", true, "Nicole", true, null, "123456", null, "NKIDMAN", "AQAAAAEAACcQAAAAENuw3D6UVHVu4nBn+TxVas8S/x/lmmAR1vVM7jXi1YI8KkWlyIN5m6KILmFkLk2lPw==", null, false, "Kidman", "fe0430e0-3313-4b0e-ab09-48e7b30c76e2", "korisnici/nkidman.jpg", false, "nkidman" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "Ime", "LockoutEnabled", "LockoutEnd", "Lozinka", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Prezime", "SecurityStamp", "Slika", "TwoFactorEnabled", "UserName" },
                values: new object[] { 23, 0, "8cfba6ff-c5b2-4a03-8f42-c106cbc81ad7", "hduff@mail.hr", true, "Hilary", true, null, "123456", null, "HDUFF", "AQAAAAEAACcQAAAAECyVC4jWEEmrjvFPH8BD5iKV/anneYT8WRosPPh849gDRkQ/k1jY7VqNYiFpAWbRow==", null, false, "Duff", "01ff58af-5afd-4c4e-8c79-432d32b98554", "korisnici/hduff.jpg", false, "hduff" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "Ime", "LockoutEnabled", "LockoutEnd", "Lozinka", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Prezime", "SecurityStamp", "Slika", "TwoFactorEnabled", "UserName" },
                values: new object[] { 14, 0, "04aa22ce-c806-4e11-a02d-236c514803c5", "janiston@mail.hr", true, "Jennifer", true, null, "123456", null, "JANISTON", "AQAAAAEAACcQAAAAELepcdOzOJ1lroAWDNNvCKLvoC2X4NwIZzCbESiPjyjQml1hR58afzSmvnmpiD53OQ==", null, false, "Aniston", "70090f97-6437-4c88-9654-825443076936", "korisnici/janiston.jpg", false, "janiston" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "Ime", "LockoutEnabled", "LockoutEnd", "Lozinka", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Prezime", "SecurityStamp", "Slika", "TwoFactorEnabled", "UserName" },
                values: new object[] { 12, 0, "9fd531d2-796f-45d4-8f6a-f816f19fa54b", "vdiesel@mail.hr", true, "Vin", true, null, "123456", null, "VDIESEL", "AQAAAAEAACcQAAAAEMfccAAGSYMRQTSaz88ovFvN+vhqGv7XZ8aHXR2p2E6v8QbsghO2ZzGcRFiv0sBMRA==", null, false, "Diesel", "f4d60dff-e50d-46e9-8e67-aadb929bfc2f", "korisnici/vdiesel.jpg", false, "vdiesel" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "Ime", "LockoutEnabled", "LockoutEnd", "Lozinka", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Prezime", "SecurityStamp", "Slika", "TwoFactorEnabled", "UserName" },
                values: new object[] { 11, 0, "c278818f-0535-47f9-8562-c9c072251bc1", "hberry@mail.hr", true, "Halle", true, null, "123456", null, "HBERRY", "AQAAAAEAACcQAAAAEDGaBAhU7HoN6I1OUX472t4oqaTSuf3JL7SEVUbYZ0hRVfwGJDJsQLUOVaBmk1gO5A==", null, false, "Berry", "cd756ac6-a91c-485c-abd2-fcd687b50158", "korisnici/hberry.jpg", false, "hberry" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "Ime", "LockoutEnabled", "LockoutEnd", "Lozinka", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Prezime", "SecurityStamp", "Slika", "TwoFactorEnabled", "UserName" },
                values: new object[] { 10, 0, "a4c536b0-25b0-4407-903b-7becf9f36347", "dradcliffe@mail.hr", true, "Daniel", true, null, "123456", null, "DRADCLIFFE", "AQAAAAEAACcQAAAAEH+0ZTFJMKCxLOvpyXGq3GoZSbL8OBcydpKqL5h+0JNyG3ppBYjWYCUutTn+IcX0Fg==", null, false, "Radcliffe", "c720238e-5952-41fe-bfc6-a3308a378773", "korisnici/dradcliffe.jpg", false, "dradcliffe" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "Ime", "LockoutEnabled", "LockoutEnd", "Lozinka", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Prezime", "SecurityStamp", "Slika", "TwoFactorEnabled", "UserName" },
                values: new object[] { 9, 0, "b1105b77-d4b2-46e7-ad57-6884c2ca9371", "nportman@mail.hr", true, "Natalie", true, null, "123456", null, "NPORTMAN", "AQAAAAEAACcQAAAAEPWLziSkdCogQk3MR3SmUPEwP2+z+s5+RvLXZo4XZxJrrnLxMXTdiX8nhSYAcJN4qQ==", null, false, "Portman", "56da47b5-0002-4a72-994d-b477e2c3478d", "korisnici/nportman.jpg", false, "nportman" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "Ime", "LockoutEnabled", "LockoutEnd", "Lozinka", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Prezime", "SecurityStamp", "Slika", "TwoFactorEnabled", "UserName" },
                values: new object[] { 8, 0, "02278a44-7823-4f6a-bdfa-96046e7c71ea", "jgarner@mail.hr", true, "Jennifer", true, null, "123456", null, "JGARNER", "AQAAAAEAACcQAAAAEErBSwj3WBiuEotvsjNnlNJBUZJ+JbX1zM7MizIzn47lIFb/Pp7uTa1jAjBjS84Jaw==", null, false, "Garner", "77fb6faf-7e6a-4695-9c30-9739033ccde9", "korisnici/jgarner.jpg", false, "jgarner" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "Ime", "LockoutEnabled", "LockoutEnd", "Lozinka", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Prezime", "SecurityStamp", "Slika", "TwoFactorEnabled", "UserName" },
                values: new object[] { 7, 0, "66e6020c-ee15-44b2-9a14-37a7521724ba", "vmortensen@mail.hr", true, "Viggo", true, null, "123456", null, "VMORTENSEN", "AQAAAAEAACcQAAAAEGeIb6NtFEf8D5tsNukTZtBXtqTqit9HvIAQ52w6VKE82Vulf8hNXinP1t02TT/4mQ==", null, false, "Mortensen", "9ff3f0b5-b113-4269-9eb6-d5d9b51f7de7", "korisnici/vmortensen.jpg", false, "vmortensen" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "Ime", "LockoutEnabled", "LockoutEnd", "Lozinka", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Prezime", "SecurityStamp", "Slika", "TwoFactorEnabled", "UserName" },
                values: new object[] { 6, 0, "5c584607-332d-445b-b499-bcb94bad71d1", "mbellucci@mail.hr", true, "Monica", true, null, "123456", null, "MBELLUCCI", "AQAAAAEAACcQAAAAEFCHec/Z+J5cR/upmR9rmy23e5QCYfV7lMOGdATxSDPIh1olejv84mzir+dDmxycjw==", null, false, "Bellucci", "e7dbda5c-328b-459c-85c1-a4254f67b113", "korisnici/mbellucci.jpg", false, "mbellucci" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "Ime", "LockoutEnabled", "LockoutEnd", "Lozinka", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Prezime", "SecurityStamp", "Slika", "TwoFactorEnabled", "UserName" },
                values: new object[] { 5, 0, "af9434ea-4540-428a-b279-03b896ce7887", "qtarantino@mail.hr", true, "Quentin", true, null, "123456", null, "QTARANTINO", "AQAAAAEAACcQAAAAEPRZtnfSTID6UyY4w4Uk8Q2fpgBRygbl2BgZKGIEq35tbtoHHoQVBZpldn7PB5hq1Q==", null, false, "Tarantino", "4e4470f9-3791-434f-b9d8-01b91ef03878", "korisnici/qtarantino.jpg", false, "qtarantino" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "Ime", "LockoutEnabled", "LockoutEnd", "Lozinka", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Prezime", "SecurityStamp", "Slika", "TwoFactorEnabled", "UserName" },
                values: new object[] { 4, 0, "6a7d5cd2-cebb-4411-95c9-a142ba9c2e9e", "vzec@mail.hr", true, "Vladimir", true, null, "123456", null, "VZEC", "AQAAAAEAACcQAAAAEEpA3qvi4LYkpoyZE+4afrAB64hKefqzM/rAxatJc59iwLYvip80B/i0JpAaS87XGQ==", null, false, "Zec", "0cf8d538-89f8-46ad-a272-48b2a5ec4bf1", "korisnici/vzec.jpg", false, "vzec" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "Ime", "LockoutEnabled", "LockoutEnd", "Lozinka", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Prezime", "SecurityStamp", "Slika", "TwoFactorEnabled", "UserName" },
                values: new object[] { 3, 0, "53d7ef95-ad38-4680-ba4d-dcad9ab1ca50", "pkos@mail.hr", true, "Pero", true, null, "123456", null, "PKOS", "AQAAAAEAACcQAAAAEIUtAsCvZiqMK9VLj5RRFEFllNiXw1WumiNeQQ8Ukcr/yMRTUu/iwkQ5yrWhB04h3A==", null, false, "Kos", "990aa5fd-e212-43c7-a2bd-33a35984b0ab", "korisnici/pkos.jpg", false, "pkos" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "Ime", "LockoutEnabled", "LockoutEnd", "Lozinka", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Prezime", "SecurityStamp", "Slika", "TwoFactorEnabled", "UserName" },
                values: new object[] { 31, 0, "6fb84e55-e954-4e73-b832-2692f0af10b7", "jalba@mail.hr", true, "Jessica", true, null, "123456", null, "JALBA", "AQAAAAEAACcQAAAAEP3i2kJHR+elBFUDhWzPE9QOOt+g2zCWbtGAJlD43OMlgQd4EupkELyv9QLL/4LZjQ==", null, false, "Alba", "1d7ac187-00ba-4d80-b2c0-d7cc0a81c210", "korisnici/jalba.jpg", false, "jalba" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "Ime", "LockoutEnabled", "LockoutEnd", "Lozinka", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Prezime", "SecurityStamp", "Slika", "TwoFactorEnabled", "UserName" },
                values: new object[] { 30, 0, "f21cc1cc-f7a2-4fc9-8be9-404c9a1569aa", "thanks@mail.hr", true, "Tom", true, null, "123456", null, "THANKS", "AQAAAAEAACcQAAAAEJlyGUjtBZqYKSRNoDiBUazKBUZFPthNsDiXTzZTKrbZ52bs8Hr99AcabJkl23l8fg==", null, false, "Hanks", "5d643794-58b0-4b3c-84f2-384278a6b80d", "korisnici/thanks.jpg", false, "thanks" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "Ime", "LockoutEnabled", "LockoutEnd", "Lozinka", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Prezime", "SecurityStamp", "Slika", "TwoFactorEnabled", "UserName" },
                values: new object[] { 18, 0, "c15d4ad1-2f9d-4812-9a69-27afeb81a95a", "kdunst@mail.hr", true, "Kirsten", true, null, "123456", null, "KDUNST", "AQAAAAEAACcQAAAAEO+Iu0jBBV0NqnN1PvorOJXnlCdw2uOtZx9FV//QCyzJDWb5t/JhNnDJqJojb9DqSA==", null, false, "Dunst", "6993854a-ad12-481d-9e87-258dd05df93e", "korisnici/kdunst.jpg", false, "kdunst" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "Ime", "LockoutEnabled", "LockoutEnd", "Lozinka", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Prezime", "SecurityStamp", "Slika", "TwoFactorEnabled", "UserName" },
                values: new object[] { 2, 0, "4fac43c6-871a-4888-b899-2bcbf96b650f", null, true, "Voditelj", true, null, "123456", null, "VODITELJ", "AQAAAAEAACcQAAAAEAaz/cCaQbqgdfJg9S5Ij00qvISSudVOck5LSO0qeVXyliM9r27vwKSxtlUPGK6q6A==", null, false, "Voditelj", "a3c193f5-6d8a-4f68-bac9-bff8505a654f", "korisnici/admin.jpg", false, "voditelj" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "Ime", "LockoutEnabled", "LockoutEnd", "Lozinka", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Prezime", "SecurityStamp", "Slika", "TwoFactorEnabled", "UserName" },
                values: new object[] { 13, 0, "1f1304b3-4b0c-4617-899d-7325d67b7342", "ecuthbert@mail.hr", true, "Elisha", true, null, "123456", null, "ECUTHBERT", "AQAAAAEAACcQAAAAEH9ZUrN6z2RLJ4ycKHj2nrXHQfFSmAAZOsFJCJVzNRSn1ckIXko12eAKMe2anE2+2Q==", null, false, "Cuthbert", "860dd5ef-4d80-4dd7-8f4f-9f56f0eb1458", "korisnici/ecuthbert.jpg", false, "ecuthbert" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "Ime", "LockoutEnabled", "LockoutEnd", "Lozinka", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Prezime", "SecurityStamp", "Slika", "TwoFactorEnabled", "UserName" },
                values: new object[] { 1, 0, "4cdcabce-6d9c-4ab9-9984-57bc74bbdfcd", null, true, "Administrator", true, null, "admin", null, "ADMIN", "AQAAAAEAACcQAAAAEH2F8W9+jFK/o+JHWLT9S9A+Q8T8GsuG3GFf5LOlJ7+dRL+bNak5Edqn6vLsUkcSjw==", null, false, "Administrator", "c00391d5-683d-423a-8028-bd99482f37fe", "korisnici/admin.jpg", false, "admin" });

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
                values: new object[] { 5, new DateTime(2021, 4, 20, 9, 27, 8, 273, DateTimeKind.Local).AddTicks(4425), 1800.0, 4, 9, 1, 8, null });

            migrationBuilder.InsertData(
                table: "Zahtjevi",
                columns: new[] { "ZahtjevId", "DatumVrijemeKreiranja", "Iznos", "KorisnikId", "KupujemValutaId", "Prihvacen", "ProdajemValutaId", "ValutaId" },
                values: new object[] { 1, new DateTime(2021, 4, 20, 9, 27, 8, 269, DateTimeKind.Local).AddTicks(8672), 100.0, 6, 1, 2, 8, null });

            migrationBuilder.InsertData(
                table: "Zahtjevi",
                columns: new[] { "ZahtjevId", "DatumVrijemeKreiranja", "Iznos", "KorisnikId", "KupujemValutaId", "Prihvacen", "ProdajemValutaId", "ValutaId" },
                values: new object[] { 3, new DateTime(2021, 4, 20, 9, 27, 8, 273, DateTimeKind.Local).AddTicks(4415), 1500.0, 7, 11, 2, 4, null });

            migrationBuilder.InsertData(
                table: "Zahtjevi",
                columns: new[] { "ZahtjevId", "DatumVrijemeKreiranja", "Iznos", "KorisnikId", "KupujemValutaId", "Prihvacen", "ProdajemValutaId", "ValutaId" },
                values: new object[] { 2, new DateTime(2021, 4, 20, 9, 27, 8, 273, DateTimeKind.Local).AddTicks(4357), 4500.0, 8, 8, 2, 1, null });

            migrationBuilder.InsertData(
                table: "Zahtjevi",
                columns: new[] { "ZahtjevId", "DatumVrijemeKreiranja", "Iznos", "KorisnikId", "KupujemValutaId", "Prihvacen", "ProdajemValutaId", "ValutaId" },
                values: new object[] { 4, new DateTime(2021, 4, 20, 9, 27, 8, 273, DateTimeKind.Local).AddTicks(4421), 10000.0, 10, 7, 2, 2, null });

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
