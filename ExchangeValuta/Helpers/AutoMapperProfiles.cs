using AutoMapper;
using ExchangeValuta.Domain.Models;
using ExchangeValuta.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExchangeValuta.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Korisnik, KorisnikDto>().ReverseMap();
            CreateMap<Korisnik, GetUsersDto>().ReverseMap();

            CreateMap<Korisnik, UpdateLoggedUserDto>().ReverseMap();
            CreateMap<Korisnik, UpdateUserDto>().ReverseMap();


            CreateMap<Valuta, ValutaDto>();

            CreateMap<Sredstva, SredstvaDto>().ForMember(dest => dest.Valuta,
                opt => opt.MapFrom(src => src.Valuta.Naziv)).ReverseMap();
            CreateMap<Sredstva, PostSredstvaDto>().ReverseMap();
            CreateMap<Sredstva, ProtuvrijednostDto>().ForMember(dest => dest.ProtuvrijednostHRK,
                opt => opt.MapFrom(src => src.Iznos)).ReverseMap();

            CreateMap<PostSredstvaDto, SredstvaDto>().ReverseMap();


            // ovdje ne mogu dobiti da pokazuje imena, a gore kod sredstava hoce
            CreateMap<Zahtjev, ZahtjevDto>().ForMember(dest => dest.KupujemValuta,
                opt => opt.MapFrom(src => src.Valuta.Naziv))
                .ForMember(dest => dest.ProdajemValuta,
                opt => opt.MapFrom(src => src.Valuta.Naziv))
               .ReverseMap();
            CreateMap<OdobravanjeZahtjevaDto, ZahtjevDto>().ReverseMap();


            CreateMap<KonverzijaValute, TecajDto>().ReverseMap();
            CreateMap<OpenStreetMap, MapDrzavaDto>().ReverseMap();

            CreateMap<Drzava, HimnaDto>().ReverseMap();




        }
    }
}
