using System;
using Bus_Ticket_Booking_System.Interfaces.Services;
using Bus_Ticket_Booking_System.src.Models;
using Bus_Ticket_Booking_System.src.Models.Dto;
using Bus_Ticket_Booking_System.src.Services;
using Bus_Ticket_Booking_System.Utilis;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Web.Resource;

namespace Bus_Ticket_Booking_System.src.Controllers
{
    [RequiredScope(RequiredScopesConfigurationKey = "AzuredAd:Scopes")]
    [ClaimRequirementAttribute("role", "ADMIN")]
    [ApiController]
    public class LocationController:ControllerBase
	{
		private readonly ILocationService _locationService;
        public LocationController(ILocationService locationService)
		{
			_locationService = locationService;
		}
		[HttpPost("addLocation")]
		public IActionResult addLocation(AddLocationModel addLocationModel)
		{
            try
            {
                _locationService.addLocation(addLocationModel);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            return Ok();
        }
        [HttpGet("getAllLocation")]
        public ActionResult<IEnumerable<LocationModel>> getAllLocations()
        {
            try
            {
                return Ok(_locationService.getAllLocations());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }
        [HttpGet("gellLocationById/{id}")]
        public ActionResult<IEnumerable<LocationModel>> getLocationById(int id)
        {

            try
            {
                return Ok(_locationService.getLocationById(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpDelete("deleteLocation/{id}")]
        public IActionResult DeleteLocation(int id)
        {
            try
            {
                return Ok(_locationService.DeleteLocation(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }
    }
}

