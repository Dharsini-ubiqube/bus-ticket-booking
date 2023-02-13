//using System;
//using System.IdentityModel.Tokens.Jwt;
//using System.Security.Claims;
//using Bus_Ticket_Booking_System.src.Models;
//using Microsoft.IdentityModel.Tokens;

//namespace Bus_Ticket_Booking_System.Utilis
//{
//	public class JwtTokenUtilis : IJwtTokenUtilis
//    {
//		public JwtTokenUtilis()
//		{
//		}

//        public string createToken(UserModel user)
//        {
//            List<Claim> claims = new List<Claim>
//                {
//                    new Claim(ClaimTypes.Email,user.email),
//                    new Claim(ClaimTypes.Name,user.Id.ToString())
//                };

//            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("my favourite token is here thank you"));

//            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

//            var token = new JwtSecurityToken(
//                claims: claims,
//                expires: DateTime.Now.AddHours(2),
//                signingCredentials: cred
//                );

//            var Jwt = new JwtSecurityTokenHandler().WriteToken(token);

//            return Jwt;
//        }
//    }
//}

