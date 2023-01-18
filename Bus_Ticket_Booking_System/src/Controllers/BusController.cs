using System;
using Bus_Ticket_Booking_System.Interfaces.Services;
using Bus_Ticket_Booking_System.src.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Bus_Ticket_Booking_System.src.Controllers
{
   
    public class BusController : ControllerBase
	{
		private readonly IBusService _busService;
		public BusController(IBusService busService)
		{
			_busService = busService;
		}
		[HttpPost]
		[Route("AddBuses")]
		public IActionResult addBuses(BusModel busModel)
		{
			try
			{
				_busService.addBuses(busModel);
			}
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            return Ok();
        }
		[HttpGet]
		[Route("GetAllBuses")]
		public ActionResult<IEnumerable<BusModel>> getAllbuses()
		{
			try
			{
				return Ok(_busService.getAllbuses());
			}
			catch (Exception e)
			{
				return BadRequest(e.Message);
			}

		}
		[HttpGet]
		[Route("GetBusById/{id}")]
		public ActionResult <IEnumerable<BusModel>> getBusById(int id)
		{

			try
			{
				return Ok(_busService.getBusById(id));
			}
			catch(Exception e)
			{
				return BadRequest(e.Message);
			}
		}
		[HttpDelete]
		[Route("deleteBuses/{id}")]
		public IActionResult DeleteBuses( int id)
		{
			try
			{
				return Ok(_busService.deleteBuses(id));
			}
			catch(Exception e)
			{
				return BadRequest(e.Message);
			}
			
		}
		[HttpPut]
		[Route("update/{id}")]
		public IActionResult UpdateBusById(int id, BusModel busModel)
		{
			try {
				return Ok(_busService.UpdateBusById(id, busModel));
			}
			catch(Exception e)
			{
				return BadRequest(e.Message);
			}
		}
	}
}

