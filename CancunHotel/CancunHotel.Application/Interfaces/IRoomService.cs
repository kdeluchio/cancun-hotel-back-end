using CancunHotel.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CancunHotel.Application.Interfaces
{
    public interface IRoomService
    {
        Task<RoomVM> GetById(Guid id);
        Task<List<RoomVM>> GetAll();
        Task<RoomVM> Create(CreateRoomVM request);
        Task<RoomVM> Update(RoomVM request);
        Task Delete(Guid id);
    }
}
