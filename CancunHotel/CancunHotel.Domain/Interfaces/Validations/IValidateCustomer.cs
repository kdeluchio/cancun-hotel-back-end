using CancunHotel.Domain.Models;
using System;
using System.Threading.Tasks;

namespace CancunHotel.Domain.Interfaces.Validations
{
    public interface IValidateCustomer
    {
        Task ValidateOnCreate(Customer model);
        Task ValidateOnLogin(Customer model, string password);
    }
}
