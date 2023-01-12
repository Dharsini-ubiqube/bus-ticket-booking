using System;
using Bus_Ticket_Booking_System.src.Models;
using Bus_Ticket_Booking_System.src.Models.Dto;

namespace Bus_Ticket_Booking_System.Interfaces.Repositories
{
	public interface IUserRepository
	{
		public void addUser(UserAddRequest userAddRequest);
		public UserModel getUserByEmail(string email);
        public string? verifyUser(UserAddLogin userAddRequest);
    }
}

