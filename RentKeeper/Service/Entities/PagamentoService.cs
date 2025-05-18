using System.Collections.Generic;
using System.Threading.Tasks;
using RentKeeper.Data.Interfaces;
using RentKeeper.Objects.Models;
using RentKeeper.Services.Interfaces;

namespace RentKeeper.Services.Entities
{
    public class PagamentoService : IPagamentoService
    {
        private readonly IPagamentoRepository _repo;
        public PagamentoService(IPagamentoRepository repo) => _repo = repo;

        public async Task<Pagamento> CreateAsync(Pagamento pagamento)
        {
            await _repo.AddAsync(pagamento);
            return pagamento;
        }

        public async Task DeleteAsync(int id) => await _repo.DeleteAsync(id);

        public async Task<IEnumerable<Pagamento>> GetAllAsync(int page, int pageSize)
            => await _repo.GetAllAsync(page, pageSize);

        public async Task<Pagamento?> GetByIdAsync(int id)
            => await _repo.GetByIdAsync(id);

        public async Task<Pagamento> UpdateAsync(int id, Pagamento pagamento)
        {
            pagamento.IdPagamento = id;
            await _repo.UpdateAsync(pagamento);
            return pagamento;
        }
    }
}
