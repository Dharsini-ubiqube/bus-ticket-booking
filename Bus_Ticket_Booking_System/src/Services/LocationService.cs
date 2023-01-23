using System;
using Bus_Ticket_Booking_System.Interfaces.Repositories;
using Bus_Ticket_Booking_System.Interfaces.Services;
using Bus_Ticket_Booking_System.src.Models;
using Bus_Ticket_Booking_System.src.Models.Dto;
using Bus_Ticket_Booking_System.src.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Bus_Ticket_Booking_System.src.Services
{
	public class LocationService: ILocationService
	{
		private readonly ILocationRepository _locationRepository;
		public LocationService(ILocationRepository locationRepository)
		{
			_locationRepository = locationRepository;
        }

		public void addLocation(AddLocationModel addLocationModel)
		{
            if (addLocationModel.location == null)
            {
                throw new Exception("Invalid BusName");
            }
            var location = new LocationModel();
            location.location = addLocationModel.location;
            _locationRepository.addLocation(location);
        }

        public string DeleteLocation(int id)
        {
            return (_locationRepository.DeleteLocation(id));
        }

        public IEnumerable<LocationModel> getAllLocations()
        {

            return (_locationRepository.getAllLocations());
        }
        public IEnumerable<LocationModel> getLocationById(int id)
        {
            return (_locationRepository.getLocationById(id));
        }
    }
}

