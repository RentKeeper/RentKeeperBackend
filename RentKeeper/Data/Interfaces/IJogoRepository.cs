using System.Collections.Generic;
using System.Threading.Tasks;
using RentKeeper.Objects.Models;

namespace RentKeeper.Data.Interfaces
{
    public interface IJogoRepository
    {
        Task<Jogo?> GetByIdAsync(int id);
        Task<IEnumerable<Jogo>> GetAllAsync(int page, int pageSize);
        Task AddAsync(Jogo jogo);
        Task UpdateAsync(Jogo jogo);
        Task DeleteAsync(int id);
    }
}
