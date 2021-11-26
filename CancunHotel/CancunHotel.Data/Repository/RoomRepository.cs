using CancunHotel.Data.Context;
using CancunHotel.Domain.Interfaces.Repositories;
using CancunHotel.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace CancunHotel.Data.Repository
{
    public class RoomRepository : BaseRepository<Room>, IRoomRepository
    {
        public RoomRepository(CancunHotelContext context)
            : base(context)
        {
        }

        public async Task<int> CountRooms(string number, string floor, Guid? currentRoomId=null)
        {
            return await DbSet.CountAsync(x => x.Number == number 
                                            && x.Floor == floor
                                            && (currentRoomId == null || (currentRoomId != null && x.Id != currentRoomId))) ;
        }
    }
}