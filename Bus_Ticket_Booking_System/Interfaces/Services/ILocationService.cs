using System;
using Bus_Ticket_Booking_System.src.Models;
using Bus_Ticket_Booking_System.src.Models.Dto;
using Microsoft.AspNetCore.Mvc;

namespace Bus_Ticket_Booking_System.Interfaces.Services
{
	public interface ILocationService
	{

        public void addLocation(AddLocationModel addLocationModel);
        public IEnumerable<LocationModel> getAllLocations();
        public IEnumerable<LocationModel> getLocationById(int id);
        public string DeleteLocation(int id);
    }
}

