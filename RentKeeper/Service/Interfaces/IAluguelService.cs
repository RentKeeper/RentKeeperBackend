using System.Collections.Generic;
using System.Threading.Tasks;
using RentKeeper.Objects.Models;

namespace RentKeeper.Services.Interfaces
{
    public interface IAluguelService
    {
        Task<Aluguel?> GetByIdAsync(int id);
        Task<IEnumerable<Aluguel>> GetAllAsync(int page, int pageSize);
        Task<Aluguel> CreateAsync(Aluguel aluguel);
        Task<Aluguel> UpdateAsync(int id, Aluguel aluguel);
        Task DeleteAsync(int id);
    }
}
