using System;
using System.Net.Mail;
using Bus_Ticket_Booking_System.Interfaces.Repositories;
using Bus_Ticket_Booking_System.Interfaces.Services;
using Bus_Ticket_Booking_System.src.Models;
using Bus_Ticket_Booking_System.src.Models.Dto;
using Bus_Ticket_Booking_System.src.Repository;

namespace Bus_Ticket_Booking_System.src.Services
{
	public class TicketService:ITicketService
	{
        private readonly ITicketRepository _ticketRepository;
        public TicketService(ITicketRepository ticketRepository)

		{
			_ticketRepository = ticketRepository;
		}
        public void bookTicket(AddTicket ticketModel)
        {
            var ticket = new TicketModel();
            ticket.busId = ticketModel.busId;
            ticket.userEmail = ticketModel.userEmail;
            ticket.numberOfSets = ticketModel.numberOfSeats;
            ticket.start = ticketModel.start;
            ticket.end = ticketModel.end;
   
            _ticketRepository.bookTicket(ticket);
        }
        public IEnumerable<TicketModel> getAllBookings()
        {

            return (_ticketRepository.getAllBookings());
        }
        public IEnumerable<TicketModel> getBookingByEmail(string email)
        {
            return (_ticketRepository.getBookingByEmail(email));
        }
        public void SendMail(string emailBody)
        {
            
        }
    }
}

