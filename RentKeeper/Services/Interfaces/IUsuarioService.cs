using RentKeeper.Models;
using RentKeeper.Objects.Dtos.Entities;

namespace RentKeeper.Services.Interfaces
{
    public interface IUsuarioService
    {
        IEnumerable<Usuario> GetAll();
        Usuario? GetById(int id);
        Usuario Create(UsuarioDto dto);
        Usuario? Update(int id, UsuarioDto dto);
        bool Delete(int id);
    }
}
