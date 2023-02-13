using System;
using Bus_Ticket_Booking_System.src.Models;
using Bus_Ticket_Booking_System.src.Models.Dto;

namespace Bus_Ticket_Booking_System.Interfaces.Repositories
{
	public interface ITicketRepository
	{
        public void bookTicket(TicketModel ticket);
        public IEnumerable<TicketModel> getAllBookings();
        public IEnumerable<TicketModel> getBookingByEmail(string email);

    }
}

