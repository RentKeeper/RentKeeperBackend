using AutoMapper;
using System.Diagnostics.Contracts;
using System.Linq;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using System.Security.Cryptography.Xml;
using RentKeeper.Objects.Models;

namespace RentKeeper.Objects.Dtos.Entities;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
       
        CreateMap<AnuncioDto, Anuncio>().ReverseMap();
        CreateMap<AluguelDto, Aluguel>().ReverseMap();
        CreateMap<PagamentoDto, Pagamento>().ReverseMap();
        CreateMap<TimeDto, Time>().ReverseMap();
        CreateMap<UsuarioDto, Usuario>().ReverseMap();
    }
}
