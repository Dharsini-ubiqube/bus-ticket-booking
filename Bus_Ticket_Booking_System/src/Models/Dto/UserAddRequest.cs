using System;
namespace Bus_Ticket_Booking_System.src.Models.Dto
{
	public class UserAddRequest
	{
        public string? name { get; set; }
        public string? email { get; set; }
        public string? password { get; set; }
    }
}

