using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bus_Ticket_Booking_System.src.Models
{
	public class TicketModel
	{
		[Key]
		public int ticketId { get; set; }
        [ForeignKey("bus")]
        public int busId { get; set; }
        [ForeignKey("user")]
        public string? userEmail { get; set; }
		public int numberOfSets { get; set; }
		public int price { get; set; }
		public string? date { get; set; }
        public string? start { get; set; }
        public string?end{ get; set; }
        public virtual BusModel  bus { get; set; }
        public virtual UserModel user { get; set; }

    }
}

