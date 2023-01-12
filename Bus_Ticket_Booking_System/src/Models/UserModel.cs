using System;
using System.ComponentModel.DataAnnotations;

namespace Bus_Ticket_Booking_System.src.Models
{
	public class UserModel
	{
        public Guid Id { get; set; }
        public string? name { get; set; }
        [Key]
        public string? email { get; set; }
        public string? password { get; set; }
        public bool isAdmin { get; set; } = false;
    }
}

