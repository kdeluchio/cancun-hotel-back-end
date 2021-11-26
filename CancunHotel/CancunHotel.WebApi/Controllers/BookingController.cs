using CancunHotel.Application.Interfaces;
using CancunHotel.Application.ViewModels;
using CancunHotel.Domain.Enums;
using CancunHotel.Domain.Interfaces.Business;
using CancunHotel.Domain.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace CancunHotel.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookingController : ControllerBase
    {
        private readonly ILogger<BookingController> _logger;
        private readonly IManagementToken _managementToken;
        private readonly IBookingService _bookingService;

        public BookingController(ILogger<BookingController> logger,
                                 IManagementToken managementToken,
                                 IBookingService bookingService)
        {
            _logger = logger;
            _managementToken = managementToken;
            _bookingService = bookingService;
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateBookingVM request)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            try
            {
                BookingVM result = await _bookingService.Create(request);
                return Ok(result);
            }
            catch (RoulesException ex)
            {
                return StatusCode((int)ex.HttpStatusCode, ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [Authorize]
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateBookingVM request)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            try
            {
                BookingVM result = await _bookingService.Update(request);
                return Ok(result);
            }
            catch (RoulesException ex)
            {
                return StatusCode((int)ex.HttpStatusCode, ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [Authorize]
        [HttpPatch("cancel")]
        public async Task<IActionResult> Cancel(Guid id)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            try
            {
                await _bookingService.Cancel(id);
                return Ok();
            }
            catch (RoulesException ex)
            {
                return StatusCode((int)ex.HttpStatusCode, ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [Authorize]
        [HttpGet("get-my-bookings")]
        public async Task<IActionResult> GetMyBookings()
        {
            try
            {
                var userId = Guid.Parse(_managementToken.ReadClaim(TokenClaims.UserId));
                List<BookingVM> result = await _bookingService.GetByCustomer(userId);
                if (result == null || result.Count == 0)
                    return NotFound();

                return Ok(result);
            }
            catch (RoulesException ex)
            {
                return StatusCode((int)ex.HttpStatusCode, ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [AllowAnonymous]
        [HttpGet("get-unavailable-dates-by-room-id")]
        public async Task<IActionResult> GetUnavailableDates(Guid roomId)
        {
            try
            {
                List<BookingDatesVM> result = await _bookingService.GetUnavailableDatesByRoomId(roomId);
                if (result == null || result.Count ==0)
                    return NotFound();

                return Ok(result);
            }
            catch (RoulesException ex)
            {
                return StatusCode((int)ex.HttpStatusCode, ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

    }
}
