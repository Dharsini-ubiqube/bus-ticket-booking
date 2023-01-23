using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bus_Ticket_Booking_System.src.Models
{
	public class LocationModel
	{
        [Key]
        public string? location { get; set; }
        public int id { get; set; }
    }
}

