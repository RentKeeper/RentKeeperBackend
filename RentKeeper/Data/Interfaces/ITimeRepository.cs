using System.Collections.Generic;
using System.Threading.Tasks;
using RentKeeper.Objects.Models;

namespace RentKeeper.Data.Interfaces
{
    public interface ITimeRepository
    {
        Task<Time?> GetByIdAsync(int id);
        Task<IEnumerable<Time>> GetAllAsync(int page, int pageSize);
        Task AddAsync(Time time);
        Task UpdateAsync(Time time);
        Task DeleteAsync(int id);
    }
}
