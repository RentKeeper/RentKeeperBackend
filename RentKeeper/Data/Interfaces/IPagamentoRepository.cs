using System.Collections.Generic;
using System.Threading.Tasks;
using RentKeeper.Objects.Models;

namespace RentKeeper.Data.Interfaces
{
    public interface IPagamentoRepository
    {
        Task<Pagamento?> GetByIdAsync(int id);
        Task<IEnumerable<Pagamento>> GetAllAsync(int page, int pageSize);
        Task AddAsync(Pagamento pagamento);
        Task UpdateAsync(Pagamento pagamento);
        Task DeleteAsync(int id);
    }
}
