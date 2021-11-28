using CancunHotel.Domain.Interfaces.Repositories;
using CancunHotel.Domain.Interfaces.Validations;
using CancunHotel.Domain.Models;
using CancunHotel.Domain.Utils;
using System;
using System.Net;
using System.Threading.Tasks;

namespace CancunHotel.Domain.Validations
{
    public class ValidateRoom : IValidateRoom
    {
        private readonly IRoomRepository _roomRepository;

        public ValidateRoom(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }

        public async Task ValidateOnCreate(Room model)
        {
            var counter = await _roomRepository.CountRooms(model.Number, model.Floor);
            if (counter > 0)
                throw new RoulesException(HttpStatusCode.Conflict, "This room already exists.");
        }

        public async Task ValidateOnRemove(Guid id)
        {
            if (await _roomRepository.GetByIdAsync(id) == null)
                throw new RoulesException(HttpStatusCode.NotFound, "This room is not exists.");
        }

        public async Task ValidateOnUpdate(Room model)
        {
            if (model == null || await _roomRepository.GetByIdAsync(model.Id) == null)
                throw new RoulesException(HttpStatusCode.NotFound, "This room is not exists.");

            var counter = await _roomRepository.CountRooms(model.Number, model.Floor, model.Id);
            if (counter > 0)
                throw new RoulesException(HttpStatusCode.Conflict, "This room already exists.");
        }
    }
}
