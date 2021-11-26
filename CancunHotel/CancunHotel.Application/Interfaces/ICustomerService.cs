using CancunHotel.Application.ViewModels;
using System;
using System.Threading.Tasks;

namespace CancunHotel.Application.Interfaces
{
    public interface ICustomerService
    {
        Task<ProfileVM> GetById(Guid id);
        Task<ProfileVM> Create(CreateProfileVM request);
        Task<TokenVM> Authentication(LoginVM request);
    }
}
