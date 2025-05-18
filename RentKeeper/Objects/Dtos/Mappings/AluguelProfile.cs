using AutoMapper;
using RentKeeper.Objects.Models;
using RentKeeper.Objects.Dtos.Entities;

namespace RentKeeper.Objects.Mappings
{
    public class AluguelProfile : Profile
    {
        public AluguelProfile()
        {
            CreateMap<AluguelCreateDto, Aluguel>();
            CreateMap<Aluguel, AluguelReadDto>();
        }
    }
}
