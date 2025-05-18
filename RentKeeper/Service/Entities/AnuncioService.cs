using System.Collections.Generic;
using System.Threading.Tasks;
using RentKeeper.Data.Interfaces;
using RentKeeper.Objects.Models;
using RentKeeper.Services.Interfaces;

namespace RentKeeper.Services.Entities
{
    public class AnuncioService : IAnuncioService
    {
        private readonly IAnuncioRepository _repo;
        public AnuncioService(IAnuncioRepository repo) => _repo = repo;

        public async Task<Anuncio> CreateAsync(Anuncio anuncio)
        {
            await _repo.AddAsync(anuncio);
            return anuncio;
        }

        public async Task DeleteAsync(int id) => await _repo.DeleteAsync(id);

        public async Task<IEnumerable<Anuncio>> GetAllAsync(int page, int pageSize)
            => await _repo.GetAllAsync(page, pageSize);

        public async Task<Anuncio?> GetByIdAsync(int id)
            => await _repo.GetByIdAsync(id);

        public async Task<Anuncio> UpdateAsync(int id, Anuncio anuncio)
        {
            anuncio.IdAnuncio = id;
            await _repo.UpdateAsync(anuncio);
            return anuncio;
        }
    }
}
