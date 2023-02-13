using System;
using Bus_Ticket_Booking_System.src.Models;
using Bus_Ticket_Booking_System.src.Models.Dto;

namespace Bus_Ticket_Booking_System.Interfaces.Repositories
{
	public interface ILocationRepository
	{
        public void addLocation(LocationModel location);
        public IEnumerable<LocationModel> getAllLocations();
        public IEnumerable<LocationModel> getLocationById(int id);
        public string DeleteLocation(int id);
        public IEnumerable<LocationModel> getLocationByName(string location);
    }
}

