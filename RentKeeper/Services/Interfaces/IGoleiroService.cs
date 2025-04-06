using RentKeeper.Models;
using RentKeeper.Objects.Dtos.Entities;

namespace RentKeeper.Services.Interfaces
{
    public interface IGoleiroService
    {
        IEnumerable<Goleiro> GetAll();
        Goleiro GetById(int id);
        Goleiro Create(GoleiroDto dto);
        Goleiro Update(int id, GoleiroDto dto);
        bool Delete(int id);
    }
}
