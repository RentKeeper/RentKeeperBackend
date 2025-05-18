using Microsoft.EntityFrameworkCore;
using RentKeeper.Data.Context;
using RentKeeper.Data.Interfaces;
using RentKeeper.Objects.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentKeeper.Data.Repositories
{
    public class PagamentoRepository : IPagamentoRepository
    {
        private readonly RentKeeperDbContext _context;
        public PagamentoRepository(RentKeeperDbContext context) => _context = context;

        public async Task AddAsync(Pagamento pagamento)
        {
            await _context.Set<Pagamento>().AddAsync(pagamento);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var ent = await _context.Set<Pagamento>().FindAsync(id);
            if (ent != null)
            {
                _context.Set<Pagamento>().Remove(ent);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Pagamento>> GetAllAsync(int page, int pageSize)
        {
            return await _context.Set<Pagamento>()
                .Include(p => p.Aluguel)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task<Pagamento?> GetByIdAsync(int id)
        {
            return await _context.Set<Pagamento>()
                .Include(p => p.Aluguel)
                .FirstOrDefaultAsync(p => p.IdPagamento == id);
        }

        public async Task UpdateAsync(Pagamento pagamento)
        {
            _context.Set<Pagamento>().Update(pagamento);
            await _context.SaveChangesAsync();
        }
    }
}
