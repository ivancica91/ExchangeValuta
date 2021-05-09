﻿using AutoMapper;
using AutoMapper.QueryableExtensions;
using ExchangeValuta.Domain.Models;
using ExchangeValuta.Domain.Services;
using ExchangeValuta.Resources;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace ExchangeValuta.Services
{
    public class ValuteService : IValuteService
    {
        private readonly ExchangeDbContext _context;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;

        private readonly IHttpClientFactory _httpClientFactory;
        private readonly UserManager<Korisnik> _userManager;

        public ValuteService(ExchangeDbContext context, IMapper mapper, IHttpContextAccessor httpContextAccessor, IHttpClientFactory httpClientFactory, UserManager<Korisnik> userManager)
        {
            _context = context;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            _httpClientFactory = httpClientFactory;
            _userManager = userManager;
        }

        public async Task<List<ValutaDto>> GetValute()
        {
            return await _context.Valute
                .ProjectTo<ValutaDto>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }

        public async Task<ValutaDetailsDto> GetValuta(int id)
        {
            return await _context.Valute
                .Where(v => v.ValutaId == id)
                .ProjectTo<ValutaDetailsDto>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync();
        }

        public async Task<ValutaDto> AddValuta(PostValutaDto postValutaDto)
        {
            var httpClient = _httpClientFactory.CreateClient("valute");
            var url = $"09a14a921f6de3a3c311a083/pair/HRK/{postValutaDto.Naziv}";
            var response = await httpClient.GetAsync(url);
            var responseStream = await response.Content.ReadAsStreamAsync();
            var responseObject = await JsonSerializer.DeserializeAsync<KonverzijaValute>(responseStream);

            var valuta = new Valuta()
            {
                Naziv = postValutaDto.Naziv,
                AktivnoOd = postValutaDto.AktivnoOd,
                AktivnoDo = postValutaDto.AktivnoDo,
                Tecaj = responseObject.conversion_rate,
                SlikaValute = postValutaDto.SlikaValute,
                KorisnikId = postValutaDto.KorisnikId
            };

            var korisnik =await _userManager.FindByIdAsync(postValutaDto.KorisnikId.ToString());
            var role = _context.UserRoles
                .Where(u => u.UserId == korisnik.Id)
                .FirstOrDefault();

            if (role.RoleId != 2)
            {
                throw new Exception("Izabrani korisnik nije u funkciji moderatora i ne može biti zadužen za valutu.");
            }

            _context.Add(valuta);
            await _context.SaveChangesAsync();
            return  _mapper.Map<ValutaDto>(valuta);

                

        }

        public async Task<ValutaDto> PutTecajValute([FromRoute] int id /*PutTecajValuteDto putValuta*/)
        {
            var userName = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var userId = _context.Korisnici.Where(k => k.UserName == userName)
                .FirstOrDefault().Id;

            var valute = await _context.Valute
                .Where(k => k.KorisnikId == userId)
                .ToListAsync();

            var valuta = valute
                //.Where(v => v.ValutaId == putValuta.ValutaId)
                .Where(v => v.ValutaId == id)
                .FirstOrDefault();
                

            if (valuta == null)
            {
                throw new Exception("Tražena valuta ne postoji ili nemate pristup traženoj valuti.");
            }

            var zadnjeAzuriranje = valuta.DatumAzuriranja.Date;

            if (zadnjeAzuriranje == DateTime.Now.Date)
            {
                throw new Exception("Tečaj valute je već ažuriran na današnji dan, molimo pokušajte sutra.");
            }

            var httpClient = _httpClientFactory.CreateClient("valute");
            var url = $"09a14a921f6de3a3c311a083/pair/HRK/{valuta.Naziv}";
            var response = await httpClient.GetAsync(url);
            var responseStream = await response.Content.ReadAsStreamAsync();
            var responseObject = await JsonSerializer.DeserializeAsync<KonverzijaValute>(responseStream);


            //valuta.ValutaId = putValuta.ValutaId;
            //valuta.Naziv = valuta.Naziv;
            valuta.Tecaj = responseObject.conversion_rate;
            valuta.DatumAzuriranja = DateTime.Now;
        
            Update(valuta);

            await _context.SaveChangesAsync();

            return _mapper.Map<ValutaDto>(valuta);
        }

        public async Task<ValutaDto> PutValutaById(int id, PutValutaDto putValuta)
        {
            var valuta = await _context.Valute
                .Where(v => v.ValutaId == id)
                .FirstOrDefaultAsync();

            if (valuta == null)
            {
                throw new Exception("Tražena valuta nije pronađena, molimo pokušajte ponovno.");
            }

            var korisnik = await _userManager.FindByIdAsync(putValuta.KorisnikId.ToString());
            var role = _context.UserRoles
                .Where(u => u.UserId == korisnik.Id)
                .FirstOrDefault();

            // tu treba napraviti da samo admin može, a ne i moderator
            if (role.RoleId == 3)
            {
                throw new Exception("Izabrani korisnik nije u funkciji admina i ne može biti ažurirati valutu.");
            }


            var httpClient = _httpClientFactory.CreateClient("valute");
            var url = $"09a14a921f6de3a3c311a083/pair/HRK/{putValuta.Naziv}";
            var response = await httpClient.GetAsync(url);
            var responseStream = await response.Content.ReadAsStreamAsync();
            var responseObject = await JsonSerializer.DeserializeAsync<KonverzijaValute>(responseStream);

            valuta.Naziv = putValuta.Naziv;
            valuta.Tecaj = responseObject.conversion_rate;
            valuta.KorisnikId = putValuta.KorisnikId;
            valuta.AktivnoOd = putValuta.AktivnoOd;
            valuta.AktivnoDo = putValuta.AktivnoDo;
            valuta.DatumAzuriranja = DateTime.Now.Date;

            Update(valuta);

            await _context.SaveChangesAsync();

            return _mapper.Map<ValutaDto>(valuta);
        }




        public void GetValuteToXml()
        {
            List<Valuta> valute = _context.Valute.ToList();

            XmlSerializer serializer = new XmlSerializer(typeof(List<Valuta>));
            using (TextWriter tw = new StreamWriter(@"C:/Users/Antonio/Desktop/valute.xml"))
            {
                serializer.Serialize(tw, valute);
            }
        }

        // kako da doda nove ako nema?
        public void GetValuteFromXml()
        {

            //// NIJE DOBRO
            //XmlSerializer deserializer = new XmlSerializer(typeof(List<Valuta>));

            //TextReader reader = new StreamReader(@"C:/Users/Antonio/Desktop/valute.xml");
            //object obj = deserializer.Deserialize(reader);

            //List<Valuta> vanjskeValute = new List<Valuta>();
            //var valute = (List <Valuta>) obj;

            //foreach (var item in vanjskeValute)
            //{
            //    // U slučajnu da ne postoji
            //    if (!valute.Any(s => s.ValutaId == item.ValutaId))
            //    {
            //        valute.Add(null);
            //        _context.SaveChangesAsync();
            //    }
            //}


            //foreach (var valuta in valute)
            //{
            //    _context.Update(valuta);
            //    //_context.SaveChanges();

            //}


            //reader.Close();


            // ovo prema milanovom tutorialu
            //List<Valuta> vanjskeValute = new List<Valuta>();
            //XmlReader reader =  XmlReader.Create(@"C:/Users/Antonio/Desktop/valute.xml");
            //Valuta item = new Valuta();
            //reader.MoveToContent();
            //while (reader.Read())
            //{
            //    if (reader.NodeType == XmlNodeType.Element && reader.Name == "ValutaId")
            //    {
            //        item.ValutaId = Int32.Parse(reader.ReadElementContentAsString());
            //    }

            //    if (reader.NodeType == XmlNodeType.Element && reader.Name == "KorisnikId")
            //    {
            //        item.KorisnikId = Int32.Parse(reader.ReadElementContentAsString());
            //    }

            //    if (reader.NodeType == XmlNodeType.Element && reader.Name == "Naziv")
            //    {
            //        item.Naziv = reader.ReadElementContentAsString();
            //    }

            //    if (reader.NodeType == XmlNodeType.Element && reader.Name == "Tecaj")
            //    {
            //        item.Tecaj = Double.Parse(reader.ReadElementContentAsString());
            //    }

            //    if (reader.NodeType == XmlNodeType.Element && reader.Name == "SlikaValute")
            //    {
            //        item.SlikaValute = reader.ReadElementContentAsString();
            //    }

            //    if (reader.NodeType == XmlNodeType.Element && reader.Name == "AktivnoOd")
            //    {
            //        item.AktivnoOd = TimeSpan.Parse(reader.ReadElementContentAsString());
            //    }

            //    if (reader.NodeType == XmlNodeType.Element && reader.Name == "AktivnoDo")
            //    {
            //        item.AktivnoDo = TimeSpan.Parse(reader.ReadElementContentAsString());
            //    }

            //    if (reader.NodeType == XmlNodeType.Element && reader.Name == "DatumAzuriranja")
            //    {
            //        item.DatumAzuriranja = DateTime.Parse(reader.ReadElementContentAsString());
            //    }

            //    if(!string.IsNullOrEmpty(item.ValutaId.ToString()) && !string.IsNullOrEmpty(item.KorisnikId.ToString()) &&
            //        !string.IsNullOrEmpty(item.Naziv) && !string.IsNullOrEmpty(item.Tecaj.ToString()) && 
            //        !string.IsNullOrEmpty(item.SlikaValute) && !string.IsNullOrEmpty(item.AktivnoOd.ToString()) && !string.IsNullOrEmpty(item.AktivnoDo.ToString()) && !string.IsNullOrEmpty(item.DatumAzuriranja.ToString()))
            //    {
            //        vanjskeValute.Add(item);
            //        item = new Valuta();
            //        _context.SaveChanges();
            //    }

            //    //foreach(var val in vanjskeValute)
            //    //{
            //    //    _context.Update(val);
            //    //    _context.SaveChanges();
            //    //}
            //    _context.SaveChanges();

            //    reader.Close();





            //const string FILENAME = @"C:/Users/Antonio/Desktop/valute.xml";
            //XmlReader reader = XmlReader.Create(FILENAME);
            //XmlSerializer serializer = new XmlSerializer(typeof(Valuta));
            //Valuta valuta = (Valuta)serializer.Deserialize(reader);


            XmlSerializer deserializer = new XmlSerializer(typeof(List<Valuta>));
            TextReader reader = new StreamReader(@"C:/Users/Antonio/Desktop/valute.xml");
            object obj = deserializer.Deserialize(reader);
            var valute = (List<Valuta>)obj;
            foreach (var valuta in valute)
            {
                Valuta ids = _context.Valute.Find(valuta.ValutaId);

                // hoce sada dodati novu valutu, ali pukne kod updatea jer kaze  another instance with the same key value for {'ValutaId'} is already being tracked.
                if (ids == null)
                {
                    _context.Add(valuta);
                    //_context.SaveChanges();
                }
                //else
                //{

                //   // Update(valuta);
                //    //_context.SaveChanges();
                //}
                //_context.Update(valuta);
                _context.SaveChanges();

            }
            reader.Close();


        }


        public void Update(Valuta valuta)
        {
            var entry = _context.Entry(valuta).State = EntityState.Modified;
        }




    }
}
