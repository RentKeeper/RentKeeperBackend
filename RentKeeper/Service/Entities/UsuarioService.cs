using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RentKeeper.Data.Interfaces;
using RentKeeper.Objects.Dtos.Entities;
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

        public async Task<Usuario> UpdateAsync(int id, UsuarioUpdateDto usuario)
        {
            if (usuario == null)
            {
                throw new ArgumentNullException(nameof(usuario));
            }

            var existing = await _repo.GetByIdAsync(id);
            if (existing == null)
            {
                return null;
            }

            var trimmedName = usuario.Nome?.Trim();
            if (!string.IsNullOrWhiteSpace(trimmedName))
            {
                existing.Nome = trimmedName;
            }

            var trimmedEmail = usuario.Email?.Trim();
            if (!string.IsNullOrWhiteSpace(trimmedEmail))
            {
                existing.Email = trimmedEmail;
            }

            var trimmedTelefone = usuario.Telefone?.Trim();
            if (!string.IsNullOrWhiteSpace(trimmedTelefone))
            {
                existing.Telefone = trimmedTelefone;
            }

            if (usuario.ChavePix != null)
            {
                var trimmedPix = usuario.ChavePix.Trim();
                existing.ChavePix = string.IsNullOrWhiteSpace(trimmedPix) ? null : trimmedPix;
            }

            if (usuario.Posicao.HasValue)
            {
                existing.Posicao = usuario.Posicao.Value;
            }

            await _repo.UpdateAsync(existing);
            return existing;
        }
    }
}