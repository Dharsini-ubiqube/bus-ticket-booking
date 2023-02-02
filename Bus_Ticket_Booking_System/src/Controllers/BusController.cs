using System;
using Bus_Ticket_Booking_System.Interfaces.Services;
using Bus_Ticket_Booking_System.src.Models;
using Bus_Ticket_Booking_System.src.Models.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Bus_Ticket_Booking_System.src.Controllers
{
	
	[ApiController]
	//[Authorize]
	public class BusController : ControllerBase
	{
		private readonly IBusService _busService;
		public BusController(IBusService busService)
		{
			_busService = busService;
		}

		[HttpPost("AddBuses")]
		public IActionResult addBuses(AddBusRequest busModel)
		{
			try
			{
				_busService.addBuses(busModel);
			}
			catch (Exception e)
			{
				return BadRequest(e.Message);
			}
			return Ok(busModel);
		}

		[HttpGet("GetAllBuses")]
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

		[HttpGet("GetBusById/{id}")]
		public ActionResult<IEnumerable<BusModel>> getBusById(int id)
		{

			try
			{
				return Ok(_busService.getBusById(id));
			}
			catch (Exception e)
			{
				return BadRequest(e.Message);
			}
		}
		[HttpGet("getbyBoardingandDestination")]
		public ActionResult<IEnumerable<BusModel>> getByBoardingandDestination(string BoardingLocation,string DestinationLocation,string date)
		{
			try
			{
				return Ok(_busService.getByBoardingandDestination(BoardingLocation, DestinationLocation,date));
			}
			catch (Exception e)
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

