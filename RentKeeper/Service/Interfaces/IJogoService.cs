using System.Collections.Generic;
using System.Threading.Tasks;
using RentKeeper.Objects.Models;

namespace RentKeeper.Services.Interfaces
{
    public interface IJogoService
    {
        Task<Jogo?> GetByIdAsync(int id);
        Task<IEnumerable<Jogo>> GetAllAsync(int page, int pageSize);
        Task<Jogo> CreateAsync(Jogo jogo);
        Task<Jogo> UpdateAsync(int id, Jogo jogo);
        Task DeleteAsync(int id);
    }
}
