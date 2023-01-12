using System;
using Bus_Ticket_Booking_System.Interfaces.Repositories;
using Bus_Ticket_Booking_System.src.Data;
using Bus_Ticket_Booking_System.src.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Bus_Ticket_Booking_System.src.Repository
{
	public class BusRepository:IBusRepository
	{
        private readonly BusTicketDbContext _busTicketDbContext;
        public BusRepository(BusTicketDbContext busTicketDbContext)
		{
            _busTicketDbContext = busTicketDbContext;
        }

        public void addBuses(BusModel busModel)
        {
            _busTicketDbContext.Buses.Add(busModel);
            _busTicketDbContext.SaveChanges();
        }
        public IEnumerable<BusModel> getAllbuses()
        {
            var bus = _busTicketDbContext.Buses.ToList();
            return (bus);
        }
        public string deleteBuses(int id)
        {
           
            var bus = _busTicketDbContext.Buses.Where(e => e.id== id).SingleOrDefault();

            if (bus != null)
            {
                _busTicketDbContext.Buses.Remove(bus);
                _busTicketDbContext.SaveChanges();
                return ("bus " + bus.id+ " Is deleted");
            }


            throw new Exception("unable to bus");

        }
        public IEnumerable<BusModel> getBusById(int id)
        {
            var bus = _busTicketDbContext.Buses.Find(id);
            if (bus == null)
            {
                throw new Exception("Not found");
            }

            yield return (bus);
        }
    }
}

