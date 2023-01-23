using System;
using Bus_Ticket_Booking_System.Interfaces.Repositories;
using Bus_Ticket_Booking_System.src.Data;
using Bus_Ticket_Booking_System.src.Models;
using Bus_Ticket_Booking_System.src.Models.Dto;

namespace Bus_Ticket_Booking_System.src.Repository
{
	public class LocationRepository:ILocationRepository
	{
        private readonly BusTicketDbContext _busTicketDbContext;
        public LocationRepository(BusTicketDbContext busTicketDbContext)
		{
            _busTicketDbContext = busTicketDbContext;
        }
        public void addLocation(LocationModel location)
        {
            _busTicketDbContext.Locations.Add(location);
            _busTicketDbContext.SaveChanges();
        }

        
        public string DeleteLocation(int id)
        {

            var location = _busTicketDbContext.Locations.Where(e => e.id == id).SingleOrDefault();

            if (location != null)
            {
                _busTicketDbContext.Locations.Remove(location);
                _busTicketDbContext.SaveChanges();
                return (" " + " Is deleted");
            }


            throw new Exception("unable to bus");

        }

        public IEnumerable<LocationModel> getAllLocations()
        {
            var location = _busTicketDbContext.Locations.ToList();
            return (location);
        }

        public IEnumerable<LocationModel> getLocationById(int id)
        {
            var location = _busTicketDbContext.Locations.Find(id);
            if (location == null)
            {
                throw new Exception("Not found");
            }

            yield return (location);
        }

        //public LocationModel getLocationByName(string location)
        //{
        //    return _busTicketDbContext.Locations.Where(e => e.location == location).FirstOrDefault();
        //}
        public IEnumerable<LocationModel> getLocationByName(string location)
        {
            var Location = _busTicketDbContext.Locations.Find(location);
            if (Location == null)
            {
                throw new Exception("Not found");
            }

            yield return (Location);
        }
    }
}

