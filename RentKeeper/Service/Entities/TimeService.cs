using System.Collections.Generic;
using System.Threading.Tasks;
using RentKeeper.Data.Interfaces;
using RentKeeper.Objects.Models;
using RentKeeper.Services.Interfaces;

namespace RentKeeper.Services.Entities
{
    public class TimeService : ITimeService
    {
        private readonly ITimeRepository _repo;
        public TimeService(ITimeRepository repo) => _repo = repo;

        public async Task<Time> CreateAsync(Time time)
        {
            await _repo.AddAsync(time);
            return time;
        }

        public async Task DeleteAsync(int id) => await _repo.DeleteAsync(id);

        public async Task<IEnumerable<Time>> GetAllAsync(int page, int pageSize)
            => await _repo.GetAllAsync(page, pageSize);

        public async Task<Time?> GetByIdAsync(int id)
            => await _repo.GetByIdAsync(id);

        public async Task<Time> UpdateAsync(int id, Time time)
        {
            time.IdTime = id;
            await _repo.UpdateAsync(time);
            return time;
        }
    }
}
