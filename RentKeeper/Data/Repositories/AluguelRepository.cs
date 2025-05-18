using Microsoft.EntityFrameworkCore;
using RentKeeper.Data.Context;
using RentKeeper.Data.Interfaces;
using RentKeeper.Objects.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentKeeper.Data.Repositories
{
    public class AluguelRepository : IAluguelRepository
    {
        private readonly RentKeeperDbContext _context;
        public AluguelRepository(RentKeeperDbContext context) => _context = context;

        public async Task AddAsync(Aluguel aluguel)
        {
            await _context.Set<Aluguel>().AddAsync(aluguel);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var ent = await _context.Set<Aluguel>().FindAsync(id);
            if (ent != null)
            {
                _context.Set<Aluguel>().Remove(ent);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Aluguel>> GetAllAsync(int page, int pageSize)
        {
            return await _context.Set<Aluguel>()
                .Include(a => a.Anuncio)
                .Include(a => a.Contratante)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task<Aluguel?> GetByIdAsync(int id)
        {
            return await _context.Set<Aluguel>()
                .Include(a => a.Anuncio)
                .Include(a => a.Contratante)
                .FirstOrDefaultAsync(a => a.IdAluguel == id);
        }

        public async Task UpdateAsync(Aluguel aluguel)
        {
            _context.Set<Aluguel>().Update(aluguel);
            await _context.SaveChangesAsync();
        }
    }
}
