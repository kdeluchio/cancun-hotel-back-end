using CancunHotel.Domain.Models;
using System.Threading.Tasks;

namespace CancunHotel.Domain.Interfaces.Validations
{
    public interface IValidateBooking
    {
        Task ValidateOnCreate(Booking model);
        Task ValidateOnUpdate(Booking model);
        Task ValidateOnCancel(Booking model);
    }
}
