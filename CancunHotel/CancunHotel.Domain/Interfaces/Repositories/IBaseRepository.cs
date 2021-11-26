using CancunHotel.Domain.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CancunHotel.Domain.Interfaces.Repositories
{
    public interface IBaseRepository<T> : IDisposable where T : BaseEntity
    {
        Task<T> InsertAsync(T obj);
        Task<T> UpdateAsync(T obj);
        Task<bool> DeleteAsync(Guid id);
        Task<T> GetByIdAsync(Guid id);
        Task<IQueryable<T>> GetByAllAsync();
    }
}
