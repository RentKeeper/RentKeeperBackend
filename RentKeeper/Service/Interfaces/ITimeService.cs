using System.Collections.Generic;
using System.Threading.Tasks;
using RentKeeper.Objects.Models;

namespace RentKeeper.Services.Interfaces
{
    public interface ITimeService
    {
        Task<Time?> GetByIdAsync(int id);
        Task<IEnumerable<Time>> GetAllAsync(int page, int pageSize);
        Task<Time> CreateAsync(Time time);
        Task<Time> UpdateAsync(int id, Time time);
        Task DeleteAsync(int id);
    }
}
