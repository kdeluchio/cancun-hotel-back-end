using CancunHotel.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CancunHotel.Domain.Interfaces.Repositories
{
    public interface IBookingRepository : IBaseRepository<Booking>
    {
        Task<bool> IsAvailableDate(DateTime checkIn, DateTime checkOut, Guid roomId, Guid? currentBookingId = null);
        Task<IQueryable<Booking>> GetUnavailableDatesByRoomId(Guid roomId);
        Task<IQueryable<Booking>> GetByCustomer(Guid customerId);
    }
}
