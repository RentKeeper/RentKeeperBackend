using System.Collections.Generic;
using System.Threading.Tasks;
using RentKeeper.Data.Interfaces;
using RentKeeper.Objects.Models;
using RentKeeper.Services.Interfaces;

namespace RentKeeper.Services.Entities
{
    public class AluguelService : IAluguelService
    {
        private readonly IAluguelRepository _repo;
        public AluguelService(IAluguelRepository repo) => _repo = repo;

        public async Task<Aluguel> CreateAsync(Aluguel aluguel)
        {
            await _repo.AddAsync(aluguel);
            return aluguel;
        }

        public async Task DeleteAsync(int id) => await _repo.DeleteAsync(id);

        public async Task<IEnumerable<Aluguel>> GetAllAsync(int page, int pageSize)
            => await _repo.GetAllAsync(page, pageSize);

        public async Task<Aluguel?> GetByIdAsync(int id)
            => await _repo.GetByIdAsync(id);

        public async Task<Aluguel> UpdateAsync(int id, Aluguel aluguel)
        {
            aluguel.IdAluguel = id;
            await _repo.UpdateAsync(aluguel);
            return aluguel;
        }
    }
}
