using AutoMapper;
using AutoMapper.QueryableExtensions;
using CancunHotel.Application.Interfaces;
using CancunHotel.Application.ViewModels;
using CancunHotel.Domain.Interfaces.Business;
using CancunHotel.Domain.Interfaces.Repositories;
using CancunHotel.Domain.Interfaces.Validations;
using CancunHotel.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CancunHotel.Application.Services
{
    public class RoomService : IRoomService
    {
        private readonly IRoomRepository _roomRepository;
        private readonly IMapper _mapper;
        private readonly IValidateRoom _validateRoom;

        public RoomService(IMapper mapper,
                           IRoomRepository roomRepository,
                           IValidateRoom validateRoom)
        {
            _mapper = mapper;
            _roomRepository = roomRepository;
            _validateRoom = validateRoom;
        }

        public async Task<RoomVM> GetById(Guid id)
        {
            var entity = await _roomRepository.GetByIdAsync(id);
            if (entity == null)
                return null;

            return _mapper.Map<RoomVM>(entity);
        }

        public async Task<List<RoomVM>> GetAll()
        {
            var entity = await _roomRepository.GetByAllAsync();
            if (entity == null)
                return null;

            return entity.ProjectTo<RoomVM>(_mapper.ConfigurationProvider).ToList();
        }

        public async Task<RoomVM> Create(CreateRoomVM request)
        {
            var entity = _mapper.Map<Room>(request);
            await _validateRoom.ValidateOnCreate(entity);

            var result = await _roomRepository.InsertAsync(entity);

            return _mapper.Map<RoomVM>(result);
        }

        public async Task<RoomVM> Update(RoomVM request)
        {
            var entity = await _roomRepository.GetByIdAsync(request.Id);
            if (entity != null)
            {
                entity.Number = request.Number;
                entity.Floor = request.Floor;
                entity.Description = request.Description;
            } 

            await _validateRoom.ValidateOnUpdate(entity);

            var result = await _roomRepository.UpdateAsync(entity);

            return _mapper.Map<RoomVM>(result);
        }

        public async Task Delete(Guid id)
        {
            await _validateRoom.ValidateOnRemove(id);
            await _roomRepository.DeleteAsync(id);
        }

  
    }
}
