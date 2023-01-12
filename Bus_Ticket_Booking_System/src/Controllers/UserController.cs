using System;
using Bus_Ticket_Booking_System.Interfaces.Services;
using Bus_Ticket_Booking_System.src.Data;
using Bus_Ticket_Booking_System.src.Models;
using Bus_Ticket_Booking_System.src.Models.Dto;
using Microsoft.AspNetCore.Mvc;

namespace Bus_Ticket_Booking_System.src.Controllers
{
	public class UserController: ControllerBase
	{
        private readonly ILogger<UserController> _logger;
        private readonly IUserService _userService;

        public UserController(ILogger<UserController> logger, BusTicketDbContext busTicketDbContext, IUserService userService)
		{
            _logger = logger;
            _userService = userService;

        }

		[HttpPost("signup")]
		public  IActionResult signup(UserAddRequest userAddRequest)
		{
			try
			{
				_userService.signup(userAddRequest);
			}
			catch(Exception e)
			{
				return BadRequest(e.Message);
			}
			return Ok();
		}

        [HttpPost("login")]
        public ActionResult login(UserAddLogin userAddRequest)
        {
            try
            {
                var genericResponse = new ResponseModel<string>();
                genericResponse.message = _userService.verifyUser(userAddRequest);


                return Ok(genericResponse);
            }

            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}

