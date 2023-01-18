using System;
using System.ComponentModel.DataAnnotations;

namespace Bus_Ticket_Booking_System.src.Models
{
	public class LocationModel
	{
        [Key]
        public int id { get; set; }
        public string location { get; set; }
    }
}

