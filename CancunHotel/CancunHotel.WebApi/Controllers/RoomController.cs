using CancunHotel.Application.Interfaces;
using CancunHotel.Application.ViewModels;
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
    public class RoomController : ControllerBase
    {
        private readonly ILogger<RoomController> _logger;
        private readonly IRoomService _roomService;

        public RoomController(ILogger<RoomController> logger,
                              IRoomService roomService)
        {
            _logger = logger;
            _roomService = roomService;
        }

        [AllowAnonymous]
        [HttpGet("get-by-id")]
        public async Task<IActionResult> GetById(Guid id)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            try
            {
                RoomVM result = await _roomService.GetById(id);
                if (result == null)
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
        [HttpGet("get-all")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                List<RoomVM> result = await _roomService.GetAll();
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

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody]CreateRoomVM request)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            try
            {
                RoomVM result = await _roomService.Create(request);
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
        public async Task<IActionResult> Update([FromBody] RoomVM request)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            try
            {
                RoomVM result = await _roomService.Update(request);
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
        [HttpDelete]
        public async Task<IActionResult> Delete(Guid id)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            try
            {
                await _roomService.Delete(id);
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

    }
}
