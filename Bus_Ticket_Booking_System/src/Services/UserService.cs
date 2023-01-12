using System;
using Bus_Ticket_Booking_System.Interfaces.Repositories;
using Bus_Ticket_Booking_System.Interfaces.Services;
using Bus_Ticket_Booking_System.src.Models;
using Bus_Ticket_Booking_System.src.Models.Dto;
using Bus_Ticket_Booking_System.Utilis;

namespace Bus_Ticket_Booking_System.src.Services
{
	public class UserService: IUserService
    {
        private readonly IJwtTokenUtilis _jwtTokenUtilis;
        private readonly IUserRepository _userRepository;
        public UserService(IJwtTokenUtilis jwtTokenUtilis, IUserRepository userRepository)
		{
            _jwtTokenUtilis = jwtTokenUtilis;
            _userRepository = userRepository;
        }

		public void signup(UserAddRequest userAddRequest)
		{
			if(userAddRequest.email == null)
			{
                throw new Exception("Invalid email");
            }

			var user = _userRepository.getUserByEmail(userAddRequest.email);

			if(user != null)
			{
                throw new Exception("User already exist");
            }

             _userRepository.addUser(userAddRequest);

		}

        public string verifyUser(UserAddLogin userAddLogin)
        {
            var user = _userRepository.getUserByEmail(userAddLogin.email);

            if (user == null)
            {
                throw new Exception("User with given email not found");
            }

            if (user.email != userAddLogin.email)
            {
                throw new Exception("invaild credentials");
            }

            return _jwtTokenUtilis.createToken(user);
        }
    }
}

