using System;
using Bus_Ticket_Booking_System.src.Models;
using Bus_Ticket_Booking_System.src.Models.Dto;

namespace Bus_Ticket_Booking_System.Interfaces.Services
{
	public interface IUserService
    {

       public void signup(UserAddRequest userAddRequest){
            
        }

        public string? verifyUser(UserAddLogin userAddRequest);
    }
}

