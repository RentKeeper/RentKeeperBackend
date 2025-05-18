using System.Collections.Generic;
using System.Threading.Tasks;
using RentKeeper.Objects.Models;

namespace RentKeeper.Services.Interfaces
{
    public interface IPagamentoService
    {
        Task<Pagamento?> GetByIdAsync(int id);
        Task<IEnumerable<Pagamento>> GetAllAsync(int page, int pageSize);
        Task<Pagamento> CreateAsync(Pagamento pagamento);
        Task<Pagamento> UpdateAsync(int id, Pagamento pagamento);
        Task DeleteAsync(int id);
    }
}
