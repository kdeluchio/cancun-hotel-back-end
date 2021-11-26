using CancunHotel.Data.Context;
using CancunHotel.Domain.Interfaces.Repositories;
using CancunHotel.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace CancunHotel.Data.Repository
{
    public class CustomerRepository : BaseRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(CancunHotelContext context)
            : base(context)
        {
        }

        public async Task<Customer> GetByEmail(string eMail)
        {
            return await DbSet.FirstOrDefaultAsync(x => x.EMail.Trim() == eMail.Trim());
        }
    }
}
