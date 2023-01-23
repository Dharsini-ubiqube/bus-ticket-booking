using System;
using Bus_Ticket_Booking_System.src.Models;
using Bus_Ticket_Booking_System.src.Models.Dto;

namespace Bus_Ticket_Booking_System.Interfaces.Services
{
	public interface ITicketService
	{
        public void bookTicket(AddTicket ticket);
        public IEnumerable<TicketModel> getAllBookings();
        public IEnumerable<TicketModel> getBookingByEmail(string email);
    }
}

