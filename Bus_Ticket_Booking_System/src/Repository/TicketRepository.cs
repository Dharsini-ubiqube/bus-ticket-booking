using System;
using Bus_Ticket_Booking_System.Interfaces.Repositories;
using Bus_Ticket_Booking_System.src.Data;
using Bus_Ticket_Booking_System.src.Models;
using MailKit.Net.Smtp;
using Microsoft.EntityFrameworkCore;
using MimeKit;

namespace Bus_Ticket_Booking_System.src.Repository
{
	public class TicketRepository:ITicketRepository
	{
        private readonly BusTicketDbContext _busTicketDbContext;
        private readonly IBusRepository _busRepository;
        private readonly IConfiguration _config;

        public TicketRepository(BusTicketDbContext busTicketDbContext,IBusRepository busRepository, IConfiguration config)
        {
            _config = config;
            _busTicketDbContext = busTicketDbContext;
            _busRepository = busRepository;
        }
        public void bookTicket(TicketModel ticket)
        {
            var busModel = _busTicketDbContext.Buses.Find(ticket.busId);
            var ticketAll = _busTicketDbContext.Tickets.ToList();
            var currentDate = DateTime.UtcNow;
            int seatsOccupy = 0;
            if (currentDate > busModel.date)
            {
                throw new Exception("Date of journey is not applicable");


            }
            if(busModel.seats ==0)
            {
                throw new Exception("seats are not available");
            }
            if (busModel != null && (ticket.start==busModel.BoardingLocation && ticket.end==busModel.DestinationLocation) )
            {
                ticket.price = (int)busModel.price * ticket.numberOfSets;
                busModel.seats = busModel.seats - ticket.numberOfSets;
                busModel.seatsBtoVia = busModel.seatsBtoVia - ticket.numberOfSets;
                busModel.seatsViatoD = busModel.seatsViatoD - ticket.numberOfSets;
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

            SendMail(ticket);
            //ticket.date = DateTime.UtcNow.ToString("yyyyMMdd");
            
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
        public void SendMail(TicketModel ticket)
        {
            var busModel = _busTicketDbContext.Buses.Find(ticket.busId);
            var dateandtime = busModel.date;
            var date = dateandtime.ToShortDateString();
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress(_config.GetSection("MailBody").Value, _config.GetSection("MailId").Value));
            message.To.Add(new MailboxAddress("", ticket.userEmail));
            message.Subject = _config.GetSection("MailBody").Value;
            message.Body = new TextPart(MimeKit.Text.TextFormat.Plain)
            {
                Text = "Your ticket was confirmed with \u2009 "+ ticket.numberOfSets + "\u2009seats\u2009" + date + "\u2009 from\u2009" + ticket.start + "\u2009to\u2009" + ticket.end + "\u2009at\u2009" + busModel.time + "\u2009 Be ready at your borading location\u2009" + ticket.start + "\u2009 10 mins before.\n" + "Thank you visiting us! Have a safe journey!" ,
            };
            using (var client = new SmtpClient())
            {
                client.Connect(_config.GetSection("SmtpMail").Value, 587, false);
                client.Authenticate(_config.GetSection("MailId").Value, _config.GetSection("Password").Value);
                client.Send(message);
                client.Disconnect(true);
            }
        }

    }
}

