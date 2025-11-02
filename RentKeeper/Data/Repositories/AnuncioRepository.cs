using Microsoft.EntityFrameworkCore;
using RentKeeper.Data.Context;
using RentKeeper.Data.Interfaces;
using RentKeeper.Objects.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentKeeper.Data.Repositories
{
    public class AnuncioRepository : IAnuncioRepository
    {
        private readonly RentKeeperDbContext _context;
        public AnuncioRepository(RentKeeperDbContext context) => _context = context;

        public async Task AddAsync(Anuncio anuncio)
        {
            await _context.Set<Anuncio>().AddAsync(anuncio);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.Set<Anuncio>().FindAsync(id);
            if (entity != null)
            {
                _context.Set<Anuncio>().Remove(entity);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Anuncio>> GetAllAsync(int page, int pageSize)
        {
            return await _context.Set<Anuncio>()
                .Include(a => a.Usuario)
                .Where(a => a.Disponivel)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task<Anuncio?> GetByIdAsync(int id)
        {
            return await _context.Set<Anuncio>()
                .Include(a => a.Usuario)
                .Include(a => a.Alugueis)
                .FirstOrDefaultAsync(a => a.IdAnuncio == id);
        }

        public async Task UpdateAsync(Anuncio anuncio)
        {
            _context.Set<Anuncio>().Update(anuncio);
            await _context.SaveChangesAsync();
        }
    }
}
