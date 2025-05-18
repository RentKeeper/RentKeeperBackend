using System.Collections.Generic;
using System.Threading.Tasks;
using RentKeeper.Objects.Models;

namespace RentKeeper.Data.Interfaces
{
    public interface IAnuncioRepository
    {
        Task<Anuncio?> GetByIdAsync(int id);
        Task<IEnumerable<Anuncio>> GetAllAsync(int page, int pageSize);
        Task AddAsync(Anuncio anuncio);
        Task UpdateAsync(Anuncio anuncio);
        Task DeleteAsync(int id);
    }
}
