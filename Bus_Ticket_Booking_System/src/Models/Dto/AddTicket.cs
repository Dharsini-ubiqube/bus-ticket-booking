using System;
namespace Bus_Ticket_Booking_System.src.Models.Dto
{
	public class AddTicket
	{
        public int busId { get; set; }
        public string? userEmail { get; set; }
        public int numberOfSeats { get; set; }
        public string? start { get; set; }
        public string? end { get; set; }
    }
}

