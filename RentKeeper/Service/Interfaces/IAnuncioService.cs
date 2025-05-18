using System.Collections.Generic;
using System.Threading.Tasks;
using RentKeeper.Objects.Models;

namespace RentKeeper.Services.Interfaces
{
    public interface IAnuncioService
    {
        Task<Anuncio?> GetByIdAsync(int id);
        Task<IEnumerable<Anuncio>> GetAllAsync(int page, int pageSize);
        Task<Anuncio> CreateAsync(Anuncio anuncio);
        Task<Anuncio> UpdateAsync(int id, Anuncio anuncio);
        Task DeleteAsync(int id);
    }
}
