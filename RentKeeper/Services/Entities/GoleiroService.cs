using RentKeeper.Data.Context;
using RentKeeper.Models;
using RentKeeper.Objects.Dtos.Entities;
using RentKeeper.Services.Interfaces;

namespace RentKeeper.Services.Entities
{
    public class GoleiroService : IGoleiroService
    {
        private readonly RentKeeperDbContext _context;

        public GoleiroService(RentKeeperDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Goleiro> GetAll() => _context.Goleiros.ToList();

        public Goleiro GetById(int id) => _context.Goleiros.FirstOrDefault(g => g.Id == id);

        public Goleiro Create(GoleiroDto dto)
        {
            var goleiro = new Goleiro
            {
                Nome = dto.Nome,
                PrecoPorJogo = dto.PrecoPorJogo,
                Disponivel = dto.Disponivel,
                Avaliacao = dto.Avaliacao,
                UsuarioId = dto.UsuarioId
            };

            _context.Goleiros.Add(goleiro);
            _context.SaveChanges();

            return goleiro;
        }

        public Goleiro Update(int id, GoleiroDto dto)
        {
            var goleiro = _context.Goleiros.FirstOrDefault(g => g.Id == id);
            if (goleiro == null)
                return null;

            goleiro.Nome = dto.Nome;
            goleiro.PrecoPorJogo = dto.PrecoPorJogo;
            goleiro.Disponivel = dto.Disponivel;
            goleiro.Avaliacao = dto.Avaliacao;
            goleiro.UsuarioId = dto.UsuarioId;

            _context.SaveChanges();
            return goleiro;
        }

        public bool Delete(int id)
        {
            var goleiro = _context.Goleiros.FirstOrDefault(g => g.Id == id);
            if (goleiro == null)
                return false;

            _context.Goleiros.Remove(goleiro);
            _context.SaveChanges();
            return true;
        }
    }
}
