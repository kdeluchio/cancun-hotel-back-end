using AutoMapper;
using CancunHotel.Application.Interfaces;
using CancunHotel.Application.ViewModels;
using CancunHotel.Domain.Interfaces.Business;
using CancunHotel.Domain.Interfaces.Repositories;
using CancunHotel.Domain.Interfaces.Validations;
using CancunHotel.Domain.Models;
using System;
using System.Threading.Tasks;

namespace CancunHotel.Application.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;
        private readonly IManagementToken _managementToken;
        private readonly IValidateCustomer _validateCustomer;

        public CustomerService(IMapper mapper,
                               ICustomerRepository customerRepository,
                               IManagementToken managementToken,
                               IValidateCustomer validateCustomer)
        {
            _mapper = mapper;
            _customerRepository = customerRepository;
            _managementToken = managementToken;
            _validateCustomer = validateCustomer;
        }

        public async Task<TokenVM> Authentication(LoginVM request)
        {
            var entity = await _customerRepository.GetByEmail(request.EMail);
            await _validateCustomer.ValidateOnLogin(entity, request.Password);

            return new TokenVM
            {
                Token = _managementToken.Create(entity.Id, entity.UserAccessLevel)
            };
        }

        public async Task<ProfileVM> Create(CreateProfileVM request)
        {
            var entity = _mapper.Map<Customer>(request);
            await _validateCustomer.ValidateOnCreate(entity);

            var result = await _customerRepository.InsertAsync(entity);

            return _mapper.Map<ProfileVM>(result);
        }

        public async Task<ProfileVM> GetById(Guid id)
        {
            var entity = await _customerRepository.GetByIdAsync(id);
            if (entity == null)
                return null;

            return _mapper.Map<ProfileVM>(entity);
        }
    }
}
