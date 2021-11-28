using CancunHotel.Data.Context;
using CancunHotel.Domain.Interfaces.Repositories;
using CancunHotel.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CancunHotel.Data.Repository
{
    public class BookingRepository : BaseRepository<Booking>, IBookingRepository
    {
        public BookingRepository(CancunHotelContext context)
            : base(context)
        {
        }

        public async Task<IQueryable<Booking>> GetByCustomer(Guid customerId)
        {
            var bookings = await DbSet.Include(x => x.Room)
                                      .Include(x => x.Customer)
                                      .Where(x => x.CustomerId == customerId)
                                      .OrderByDescending(x => x.CheckIn)
                                      .ToListAsync();

            return bookings.AsQueryable();
        }

        public async Task<IQueryable<Booking>> GetUnavailableDatesByRoomId(Guid roomId)
        {
            var bookings = await DbSet.Include(x => x.Room)
                                      .Include(x => x.Customer)
                                      .Where(x => x.CheckIn.Date >= DateTime.Now.Date 
                                               && !x.Cancelled
                                               && x.RoomId == roomId)
                                      .OrderBy(x => x.CheckIn)
                                      .ToListAsync();

            return bookings.AsQueryable();
        }

        public async Task<bool> IsAvailableDate(DateTime checkIn, DateTime checkOut, Guid roomId, Guid? currentBookingId=null)
        {
            //checkIn
            var checkInCounter = await DbSet.Where(x => checkIn.Date >= x.CheckIn.Date
                                                  && checkIn.Date <= x.CheckOut.Date
                                                  && !x.Cancelled
                                                  && x.CheckIn.Date >= DateTime.Now.Date
                                                  && x.RoomId == roomId
                                                  && (currentBookingId ==  null || (currentBookingId != null && x.Id != currentBookingId)))
                                         .CountAsync();

            if (checkInCounter > 0)
                return false;

            //checkOut
            var checkOutCounter = await DbSet.Where(x => checkOut.Date >= x.CheckIn.Date
                                                      && checkOut.Date <= x.CheckOut.Date
                                                      && !x.Cancelled
                                                      && x.CheckIn.Date >= DateTime.Now.Date
                                                      && x.RoomId == roomId
                                                      && (currentBookingId == null || (currentBookingId != null && x.Id != currentBookingId)))
                                             .CountAsync();

            return checkOutCounter == 0;
        }
    }
}
