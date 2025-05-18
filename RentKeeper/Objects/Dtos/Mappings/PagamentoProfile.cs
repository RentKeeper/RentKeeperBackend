using AutoMapper;
using RentKeeper.Objects.Models;
using RentKeeper.Objects.Dtos.Entities;

namespace RentKeeper.Objects.Mappings
{
    public class PagamentoProfile : Profile
    {
        public PagamentoProfile()
        {
            CreateMap<PagamentoCreateDto, Pagamento>();
            CreateMap<Pagamento, PagamentoReadDto>();
        }
    }
}
