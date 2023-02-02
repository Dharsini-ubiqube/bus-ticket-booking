using System;
using Bus_Ticket_Booking_System.Interfaces.Services;
using Bus_Ticket_Booking_System.src.Models;
using Bus_Ticket_Booking_System.src.Models.Dto;
using Bus_Ticket_Booking_System.src.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Bus_Ticket_Booking_System.src.Controllers
{
	[ApiController]
    //[Authorize]
    public class TicketController:ControllerBase
	{
        private readonly ITicketService _ticketService;
        public TicketController(ITicketService ticketService)
		{
			_ticketService = ticketService;
		}
        [HttpPost("bookTicket")]
        public IActionResult bookTicket(AddTicket ticketModel)
        {
            try
            {
                _ticketService.bookTicket(ticketModel);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            return Ok();
        }
        [HttpGet("getAllBookings")]
        public ActionResult<IEnumerable<TicketModel>> getAllBookings()
        {
            try
            {
                return Ok(_ticketService.getAllBookings());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }
        [HttpGet("gellBookingByEmail/{email}")]
        public ActionResult<IEnumerable<TicketModel>> getBookingByEmail(string email)
        {

            try
            {
                return Ok(_ticketService.getBookingByEmail(email));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}

