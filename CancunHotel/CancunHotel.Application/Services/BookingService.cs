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
    public class BookingService : IBookingService
    {
        private readonly IBookingRepository _bookingRepository;
        private readonly IMapper _mapper;
        private readonly IValidateBooking _validateBooking;
        private readonly IManagementToken _managementToken;

        public BookingService(IBookingRepository bookingRepository,
                              IMapper mapper,
                              IValidateBooking validateBooking,
                              IManagementToken managementToken)
        {
            _bookingRepository = bookingRepository;
            _mapper = mapper;
            _validateBooking = validateBooking;
            _managementToken = managementToken;
        }

        public async Task Cancel(Guid bookingId)
        {
            var entity = await _bookingRepository.GetByIdAsync(bookingId);
            if (entity != null)
            {
                entity.Cancelled = true;
            }

            await _validateBooking.ValidateOnCancel(entity);
            await _bookingRepository.UpdateAsync(entity);
        }

        public async Task<BookingVM> Create(CreateBookingVM request)
        {
            var entity = _mapper.Map<Booking>(request);

            var userId = Guid.Parse(_managementToken.ReadClaim(Domain.Enums.TokenClaims.UserId));
            entity.CustomerId = userId;

            await _validateBooking.ValidateOnCreate(entity);

            var result = await _bookingRepository.InsertAsync(entity);

            return _mapper.Map<BookingVM>(result);
        }

        public async Task<List<BookingVM>> GetByCustomer(Guid customerId)
        {
            var entity = await _bookingRepository.GetByCustomer(customerId);
            if (entity == null)
                return null;

            return entity.ProjectTo<BookingVM>(_mapper.ConfigurationProvider).ToList();
        }

        public async Task<List<BookingDatesVM>> GetUnavailableDatesByRoomId(Guid roomId)
        {
            var entity = await _bookingRepository.GetUnavailableDatesByRoomId(roomId);
            if (entity == null)
                return null;

            return entity.ProjectTo<BookingDatesVM>(_mapper.ConfigurationProvider).ToList();
        }

        public async Task<BookingVM> Update(UpdateBookingVM request)
        {
            var entity = await _bookingRepository.GetByIdAsync(request.Id);
            if (entity != null)
            {
                entity.CheckIn = request.CheckIn;
                entity.CheckOut = request.CheckOut;
            }

            await _validateBooking.ValidateOnUpdate(entity);

            var result = await _bookingRepository.UpdateAsync(entity);

            return _mapper.Map<BookingVM>(result);
        }
    
    }
}
