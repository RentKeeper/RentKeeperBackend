using RentKeeper.Data.Context;
using RentKeeper.Models;
using RentKeeper.Objects.Dtos.Entities;
using RentKeeper.Services.Interfaces;

namespace RentKeeper.Services.Entities
{
    public class UsuarioService : IUsuarioService
    {
        private readonly RentKeeperDbContext _context;

        public UsuarioService(RentKeeperDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Usuario> GetAll()
        {
            return _context.Usuarios.ToList();
        }

        public Usuario? GetById(int id)
        {
            return _context.Usuarios.Find(id);
        }

        public Usuario Create(UsuarioDto dto)
        {
            if (!Enum.IsDefined(typeof(RoleUsuario), dto.Role))
                throw new ArgumentException("Role inválido. Use valores entre 1 e 3.");

            var usuario = new Usuario
            {
                Nome = dto.Nome,
                Email = dto.Email,
                Senha = dto.Senha,
                Role = dto.Role
            };

            _context.Usuarios.Add(usuario);
            _context.SaveChanges();

            return usuario;
        }

        public Usuario? Update(int id, UsuarioDto dto)
        {
            var usuario = _context.Usuarios.Find(id);
            if (usuario == null)
                return null;

            if (!Enum.IsDefined(typeof(RoleUsuario), dto.Role))
                throw new ArgumentException("Role inválido. Use valores entre 1 e 3.");

            usuario.Nome = dto.Nome;
            usuario.Email = dto.Email;
            usuario.Senha = dto.Senha;
            usuario.Role = dto.Role;

            _context.SaveChanges();
            return usuario;
        }

        public bool Delete(int id)
        {
            var usuario = _context.Usuarios.Find(id);
            if (usuario == null)
                return false;

            _context.Usuarios.Remove(usuario);
            _context.SaveChanges();
            return true;
        }
    }
}
