using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RentKeeper.Data.Context;
using RentKeeper.Data.Interfaces;
using RentKeeper.Objects.Models;

namespace RentKeeper.Data.Repositories
{
    public class JogoRepository : IJogoRepository
    {
        private readonly RentKeeperDbContext _context;

        public JogoRepository(RentKeeperDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Jogo jogo)
        {
            await _context.Set<Jogo>().AddAsync(jogo);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.Set<Jogo>().FindAsync(id);
            if (entity != null)
            {
                _context.Set<Jogo>().Remove(entity);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Jogo>> GetAllAsync(int page, int pageSize)
        {
            return await _context.Set<Jogo>()
                .Include(j => j.TimeMandante)
                .Include(j => j.TimeVisitante)
                .OrderBy(j => j.DataHora)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task<Jogo?> GetByIdAsync(int id)
        {
            return await _context.Set<Jogo>()
                .Include(j => j.TimeMandante)
                .Include(j => j.TimeVisitante)
                .FirstOrDefaultAsync(j => j.IdJogo == id);
        }

        public async Task UpdateAsync(Jogo jogo)
        {
            _context.Set<Jogo>().Update(jogo);
            await _context.SaveChangesAsync();
        }
    }
}
