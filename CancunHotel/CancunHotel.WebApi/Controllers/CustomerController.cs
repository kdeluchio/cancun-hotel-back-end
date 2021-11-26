using CancunHotel.Application.Interfaces;
using CancunHotel.Application.ViewModels;
using CancunHotel.Domain.Enums;
using CancunHotel.Domain.Interfaces.Business;
using CancunHotel.Domain.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Net;
using System.Threading.Tasks;

namespace CancunHotel.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ILogger<CustomerController> _logger;
        private readonly ICustomerService _customerService;
        private readonly IManagementToken _managementToken;

        public CustomerController(ILogger<CustomerController> logger,
                                  ICustomerService customerService,
                                  IManagementToken managementToken)
        {
            _logger = logger;
            _customerService = customerService;
            _managementToken = managementToken;
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var userId = Guid.Parse(_managementToken.ReadClaim(TokenClaims.UserId));
                ProfileVM result = await _customerService.GetById(userId);
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
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateProfileVM resquest)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            try
            {
                ProfileVM result = await _customerService.Create(resquest);
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
        [HttpPost("authentication")]
        public async Task<IActionResult> Authentication([FromBody] LoginVM resquest)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            try
            {
                TokenVM result = await _customerService.Authentication(resquest);
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

    }
}
