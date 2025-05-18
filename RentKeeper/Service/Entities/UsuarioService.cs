using System.Collections.Generic;
using System.Threading.Tasks;
using RentKeeper.Data.Interfaces;
using RentKeeper.Objects.Models;
using RentKeeper.Services.Interfaces;

namespace RentKeeper.Services.Entities
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _repo;

        public UsuarioService(IUsuarioRepository repo)
        {
            _repo = repo;
        }

        public async Task<Usuario> CreateAsync(Usuario usuario)
        {
            await _repo.AddAsync(usuario);
            return usuario;
        }

        public async Task DeleteAsync(int id)
        {
            await _repo.DeleteAsync(id);
        }

        public async Task<IEnumerable<Usuario>> GetAllAsync(int page, int pageSize)
        {
            return await _repo.GetAllAsync(page, pageSize);
        }

        public async Task<Usuario> GetByIdAsync(int id)
        {
            return await _repo.GetByIdAsync(id);
        }

        public async Task<Usuario> UpdateAsync(int id, Usuario usuario)
        {
            usuario.Id = id;
            await _repo.UpdateAsync(usuario);
            return usuario;
        }
    }
}