using CancunHotel.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CancunHotel.Application.Interfaces
{
    public interface IBookingService
    {
        Task<BookingVM> Create(CreateBookingVM request);
        Task<BookingVM> Update(UpdateBookingVM request);
        Task Cancel(Guid bookingId);
        Task<List<BookingVM>> GetByCustomer(Guid customerId);
        Task<List<BookingDatesVM>> GetUnavailableDatesByRoomId(Guid roomId);
    }
}
