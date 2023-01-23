using System;
using Bus_Ticket_Booking_System.Interfaces.Repositories;
using Bus_Ticket_Booking_System.src.Data;
using Bus_Ticket_Booking_System.src.Models;
using Microsoft.EntityFrameworkCore;

namespace Bus_Ticket_Booking_System.src.Repository
{
	public class TicketRepository:ITicketRepository
	{
        private readonly BusTicketDbContext _busTicketDbContext;
        private readonly IBusRepository _busRepository;
        public TicketRepository(BusTicketDbContext busTicketDbContext,IBusRepository busRepository)
        {
            _busTicketDbContext = busTicketDbContext;
            _busRepository = busRepository;
        }
        public void bookTicket(TicketModel ticket)
        {
            var busModel = _busTicketDbContext.Buses.Find(ticket.busId);
            if (busModel != null && (ticket.start==busModel.BoardingLocation && ticket.end==busModel.DestinationLocation) )
            {
                ticket.price = (int)busModel.price * ticket.numberOfSets;
                busModel.seats = busModel.seats - ticket.numberOfSets;
            }
            else if (busModel != null && (ticket.start == busModel.BoardingLocation && ticket.end == busModel.Via))
            {
                ticket.price = (int)(busModel.price/2) * ticket.numberOfSets;
                busModel.seats = busModel.seats - ticket.numberOfSets;
                busModel.seatsBtoVia = busModel.seatsBtoVia - ticket.numberOfSets;
            }
            else if (busModel != null && (ticket.start == busModel.Via && ticket.end == busModel.DestinationLocation))
            {
                ticket.price = (int)(busModel.price / 2) * ticket.numberOfSets;
                busModel.seats = busModel.seats - ticket.numberOfSets;
                busModel.seatsViatoD = busModel.seatsViatoD - ticket.numberOfSets;
            }
            else
            {
                throw new Exception("Bus is not available as per your request");
            }
            ticket.date = DateTime.UtcNow.ToString("yyyyMMdd");

            try
            {
                _busTicketDbContext.Tickets.Add(ticket);
                _busTicketDbContext.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.InnerException.Message);
                throw new Exception(e.InnerException.Message);
            }

        }
        public IEnumerable<TicketModel> getAllBookings()
        {
            var ticket = _busTicketDbContext.Tickets.Include(e => e.bus).Include(e => e.user).Include(e => e.bus.Location1).Include(e => e.bus.Location2).ToList(); 
            return (ticket);
        }
        public IEnumerable<TicketModel> getBookingByEmail(string email)
        {
            var booking = _busTicketDbContext.Tickets.Include(e => e.bus).Include(e => e.bus.Location1).Include(e => e.bus.Location2).Include(e=>e.user).Where(e => e.userEmail == email).ToList();
            if (booking == null)
            {
                throw new Exception("Not found");
            }

           return (booking);
        }

    }
}

