using AutoMapper;
using RentKeeper.Models;
using RentKeeper.Objects.Dtos.Entities;

namespace RentKeeper.Objects.Dtos.Mappings
{
    public class UsuarioProfile : Profile
    {
        public UsuarioProfile()
        {
            CreateMap<Usuario, UsuarioDto>().ReverseMap();
        }
    }
}
