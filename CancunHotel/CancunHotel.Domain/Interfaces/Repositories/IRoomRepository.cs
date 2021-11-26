using CancunHotel.Domain.Models;
using System;
using System.Threading.Tasks;

namespace CancunHotel.Domain.Interfaces.Repositories
{
    public interface IRoomRepository : IBaseRepository<Room>
    {
        Task<int> CountRooms(string number, string floor, Guid? currentRoomId=null);
    }
}
