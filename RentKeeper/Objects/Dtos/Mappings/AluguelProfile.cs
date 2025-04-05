using AutoMapper;
using RentKeeper.Models;
using RentKeeper.Objects.Dtos.Entities;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace RentKeeper.Objects.Dtos.Mappings
{
    public class AluguelProfile : Profile
    {
        public AluguelProfile()
        {
            CreateMap<Aluguel, AluguelDto>().ReverseMap();
        }
    }
}
