using System;
using Bus_Ticket_Booking_System.Interfaces.Repositories;
using Bus_Ticket_Booking_System.src.Data;
using Bus_Ticket_Booking_System.src.Models;
using Bus_Ticket_Booking_System.src.Models.Dto;

namespace Bus_Ticket_Booking_System.src.Repository
{
	public class UserRepository : IUserRepository
    {
		private readonly BusTicketDbContext _busTicketDbContext;

        public UserRepository(BusTicketDbContext busTicketDbContext)
		{
			_busTicketDbContext = busTicketDbContext;

        }

		public void addUser(UserAddRequest userAddRequest)
		{
			var user = new UserModel();
			user.Email = userAddRequest.Email;
			user.Name = userAddRequest.Name;
			
			_busTicketDbContext.Users.Add(user);
			_busTicketDbContext.SaveChanges();
        }

        public UserModel getUserByEmail(string email)
        {
			var user = _busTicketDbContext.Users.Find(email);

			return user;
        }

        public string? verifyUser(UserAddLogin userAddRequest)
        {
            throw new NotImplementedException();
        }
    }	
}

