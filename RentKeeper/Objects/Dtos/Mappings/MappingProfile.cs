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
       
        CreateMap<Anuncio, AnuncioDto>()
            .ForMember(dest => dest.MediaAvaliacao, opt => opt.MapFrom(src =>
                src.Alugueis != null && src.Alugueis.Any(al => al.AvaliacaoJogador.HasValue)
                    ? src.Alugueis
                        .Where(al => al.AvaliacaoJogador.HasValue)
                        .Average(al => (double)al.AvaliacaoJogador!.Value)
                    : (double?)null))
            .ForMember(dest => dest.TotalAvaliacoes, opt => opt.MapFrom(src =>
                src.Alugueis != null
                    ? src.Alugueis.Count(al => al.AvaliacaoJogador.HasValue)
                    : 0));

        CreateMap<AnuncioDto, Anuncio>()
            .ForMember(dest => dest.Alugueis, opt => opt.Ignore());
        CreateMap<AluguelDto, Aluguel>().ReverseMap();
        CreateMap<PagamentoDto, Pagamento>().ReverseMap();
        CreateMap<TimeDto, Time>().ReverseMap();
        CreateMap<UsuarioDto, Usuario>().ReverseMap();
        CreateMap<Jogo, JogoDto>()
            .ForMember(dest => dest.TimeMandanteNome, opt => opt.MapFrom(src => src.TimeMandante != null ? src.TimeMandante.NomeTime : null))
            .ForMember(dest => dest.TimeVisitanteNome, opt => opt.MapFrom(src => src.TimeVisitante != null ? src.TimeVisitante.NomeTime : null));
        CreateMap<JogoDto, Jogo>()
            .ForMember(dest => dest.TimeMandante, opt => opt.Ignore())
            .ForMember(dest => dest.TimeVisitante, opt => opt.Ignore());
    }
}
