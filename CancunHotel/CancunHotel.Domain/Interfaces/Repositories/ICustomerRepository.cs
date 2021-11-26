using CancunHotel.Domain.Models;
using System.Threading.Tasks;

namespace CancunHotel.Domain.Interfaces.Repositories
{
    public interface ICustomerRepository : IBaseRepository<Customer>
    {
        Task<Customer> GetByEmail(string eMail);
    }
}
