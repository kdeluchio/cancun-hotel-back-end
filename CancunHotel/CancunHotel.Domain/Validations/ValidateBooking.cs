using CancunHotel.Domain.Interfaces.Business;
using CancunHotel.Domain.Interfaces.Repositories;
using CancunHotel.Domain.Interfaces.Validations;
using CancunHotel.Domain.Models;
using CancunHotel.Domain.Utils;
using System;
using System.Net;
using System.Threading.Tasks;

namespace CancunHotel.Domain.Validations
{
    public class ValidateBooking : IValidateBooking
    {
        private readonly IBookingRepository _bookingRepository;
        private readonly IRoomRepository _roomRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly IManagementToken _managementToken;

        public ValidateBooking(IBookingRepository bookingRepository,
                               IRoomRepository roomRepository,
                               ICustomerRepository customerRepository,
                               IManagementToken managementToken)
        {
            _bookingRepository = bookingRepository;
            _roomRepository = roomRepository;
            _customerRepository = customerRepository;
            _managementToken = managementToken;
        }

        public async Task ValidateOnCreate(Booking model)
        {
            if (await _roomRepository.GetByIdAsync(model.RoomId) == null)
                throw new RoulesException(HttpStatusCode.Conflict, "Invalid Room.");

            if (await _customerRepository.GetByIdAsync(model.CustomerId) == null)
                throw new RoulesException(HttpStatusCode.Conflict, "Invalid Customer.");

            if (model.CheckIn.Date > model.CheckOut.Date)
                throw new RoulesException(HttpStatusCode.Conflict, "The check-in date cannot be later than the check-out date.");

            if ((model.CheckOut.Date - model.CheckIn.Date).TotalDays > 3)
                throw new RoulesException(HttpStatusCode.Conflict, "The reservation cannot be longer than 3 days.");
            
            if (model.CheckIn.Date < DateTime.Now.Date)
                throw new RoulesException(HttpStatusCode.Conflict, "Invalid checkin date.");

            if (Math.Abs((DateTime.Now.Date - model.CheckIn.Date).TotalDays) > 30)
                throw new RoulesException(HttpStatusCode.Conflict, "It cannot be booked more than 30 days in advance.");

            if (!await _bookingRepository.IsAvailableDate(model.CheckIn.Date, model.CheckOut.Date, model.RoomId))
                throw new RoulesException(HttpStatusCode.Conflict, string.Format("Dates between {0} and {1} are not available.", model.CheckIn.Date, model.CheckOut.Date));
        }

        public async Task ValidateOnCancel(Booking model)
        {
            if (model == null || await _bookingRepository.GetByIdAsync(model.Id) == null)
                throw new RoulesException(HttpStatusCode.Conflict, "Booking was not founded.");

            if (model.CheckIn.Date <= DateTime.Now.Date)
                throw new RoulesException(HttpStatusCode.Conflict, "We cannot cancel reservations that have already started.");

            var userAccess = Convert.ToInt32(_managementToken.ReadClaim(Enums.TokenClaims.UserAccess));
            if (userAccess == (int)Enums.UserAccessLevel.Restricted)
            {
                var userId = Guid.Parse(_managementToken.ReadClaim(Enums.TokenClaims.UserId));
                if (model.CustomerId != userId)
                    throw new RoulesException(HttpStatusCode.Conflict, "The reservation can be canceled only by the person who created it.");
            }
        }

        public async Task ValidateOnUpdate(Booking model)
        {
            if (model == null || await _bookingRepository.GetByIdAsync(model.Id) == null)
                throw new RoulesException(HttpStatusCode.Conflict, "Booking was not founded.");

            var userAccess = Convert.ToInt32(_managementToken.ReadClaim(Enums.TokenClaims.UserAccess));
            if (userAccess == (int)Enums.UserAccessLevel.Restricted)
            {
                var userId = Guid.Parse(_managementToken.ReadClaim(Enums.TokenClaims.UserId));
                if (model.CustomerId != userId)
                    throw new RoulesException(HttpStatusCode.Conflict, "The reservation can be updated only by the person who created it.");
            }

            if (model.CheckIn.Date > model.CheckOut.Date)
                throw new RoulesException(HttpStatusCode.Conflict, "The check-in date cannot be later than the check-out date.");

            if ((model.CheckOut.Date - model.CheckIn.Date).TotalDays > 3)
                throw new RoulesException(HttpStatusCode.Conflict, "The reservation cannot be longer than 3 days.");

            if (model.CheckIn.Date < DateTime.Now.Date)
                throw new RoulesException(HttpStatusCode.Conflict, "Invalid checkin date.");

            if (Math.Abs((DateTime.Now.Date - model.CheckIn.Date).TotalDays) > 30)
                throw new RoulesException(HttpStatusCode.Conflict, "It cannot be booked more than 30 days in advance.");

            if (!await _bookingRepository.IsAvailableDate(model.CheckIn.Date, model.CheckOut.Date, model.RoomId, model.Id))
                throw new RoulesException(HttpStatusCode.Conflict, string.Format("Dates between {0} and {1} are not available.", model.CheckIn.Date, model.CheckOut.Date));

        }
    
    }
}
