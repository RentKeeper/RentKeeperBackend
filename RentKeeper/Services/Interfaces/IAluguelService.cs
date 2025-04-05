using RentKeeper.Models;
using RentKeeper.Objects.Dtos.Entities;

namespace RentKeeper.Services.Interfaces
{
    public interface IAluguelService
    {
        IEnumerable<Aluguel> GetAll();
        Aluguel? GetById(int id);
        Aluguel Create(AluguelDto dto);
        Aluguel? Update(int id, AluguelDto dto);
        bool Delete(int id);
    }
}
