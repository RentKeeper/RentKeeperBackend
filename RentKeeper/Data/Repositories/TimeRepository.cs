using Microsoft.EntityFrameworkCore;
using RentKeeper.Data.Context;
using RentKeeper.Data.Interfaces;
using RentKeeper.Objects.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentKeeper.Data.Repositories
{
    public class TimeRepository : ITimeRepository
    {
        private readonly RentKeeperDbContext _context;
        public TimeRepository(RentKeeperDbContext context) => _context = context;

        public async Task AddAsync(Time time)
        {
            await _context.Set<Time>().AddAsync(time);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var ent = await _context.Set<Time>().FindAsync(id);
            if (ent != null)
            {
                _context.Set<Time>().Remove(ent);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Time>> GetAllAsync(int page, int pageSize)
        {
            return await _context.Set<Time>()
                .Include(t => t.Usuarios)
                .Include(t => t.JogosComoMandante)
                .ThenInclude(j => j.TimeVisitante)
                .Include(t => t.JogosComoVisitante)
                .ThenInclude(j => j.TimeMandante)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task<Time?> GetByIdAsync(int id)
        {
            return await _context.Set<Time>()
                .Include(t => t.Usuarios)
                .Include(t => t.JogosComoMandante)
                    .ThenInclude(j => j.TimeVisitante)
                .Include(t => t.JogosComoVisitante)
                    .ThenInclude(j => j.TimeMandante)
                .FirstOrDefaultAsync(t => t.IdTime == id);
        }

        public async Task UpdateAsync(Time time)
        {
            _context.Set<Time>().Update(time);
            await _context.SaveChangesAsync();
        }
    }
}
