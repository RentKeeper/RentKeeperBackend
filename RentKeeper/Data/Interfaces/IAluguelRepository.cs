using System.Collections.Generic;
using System.Threading.Tasks;
using RentKeeper.Objects.Models;

namespace RentKeeper.Data.Interfaces
{
    public interface IAluguelRepository
    {
        Task<Aluguel?> GetByIdAsync(int id);
        Task<IEnumerable<Aluguel>> GetAllAsync(int page, int pageSize);
        Task AddAsync(Aluguel aluguel);
        Task UpdateAsync(Aluguel aluguel);
        Task DeleteAsync(int id);
    }
}
