using System.Collections.Generic;
using System.Threading.Tasks;
using RentKeeper.Objects.Models;

namespace RentKeeper.Services.Interfaces
{
    public interface IUsuarioService
    {
        Task<Usuario> GetByIdAsync(int id);
        Task<IEnumerable<Usuario>> GetAllAsync(int page, int pageSize);
        Task<Usuario> CreateAsync(Usuario usuario);
        Task<Usuario> UpdateAsync(int id, Usuario usuario);
        Task DeleteAsync(int id);
    }
}