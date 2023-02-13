using System;
using System.ComponentModel.DataAnnotations;

namespace Bus_Ticket_Booking_System.src.Models
{
	public class UserModel
	{
        public string? Name { get; set; }
        [Key]
        public string Email { get; set; }
        public string? role { get; set; } = "USER";
         
    }
}

