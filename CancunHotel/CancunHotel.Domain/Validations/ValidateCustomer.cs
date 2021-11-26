using CancunHotel.Domain.Interfaces.Repositories;
using CancunHotel.Domain.Interfaces.Validations;
using CancunHotel.Domain.Models;
using CancunHotel.Domain.Utils;
using System;
using System.Net;
using System.Threading.Tasks;

namespace CancunHotel.Domain.Validations
{
    public class ValidateCustomer : IValidateCustomer
    {
        private readonly ICustomerRepository _customerRepository;

        public ValidateCustomer(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task ValidateOnCreate(Customer model)
        {
            if (await _customerRepository.GetByEmail(model.EMail) != null)
                throw new RoulesException(HttpStatusCode.NotFound, "This email already exists in the system.");

            if (model.Password.Trim().Length < 8)
                throw new RoulesException(HttpStatusCode.NotFound, "The password must be more than 8 characters.");

        }

        public async Task ValidateOnLogin(Customer model, string password)
        {
            if (model == null)
                throw new RoulesException(HttpStatusCode.Unauthorized, "Inválid e-mail.");

            if (model.Password.Trim() != password)
                throw new RoulesException(HttpStatusCode.Unauthorized, "Inválid password.");
        }
    }
}
