using CancunHotel.Domain.Models;
using System;
using System.Threading.Tasks;

namespace CancunHotel.Domain.Interfaces.Validations
{
    public interface IValidateRoom
    {
        Task ValidateOnCreate(Room model);
        Task ValidateOnUpdate(Room model);
        Task ValidateOnRemove(Guid id);
    }
}
