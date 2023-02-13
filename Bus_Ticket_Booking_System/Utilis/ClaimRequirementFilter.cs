using System;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc.Filters;
using Bus_Ticket_Booking_System.src.Models;
using Bus_Ticket_Booking_System.src.Data;

namespace Bus_Ticket_Booking_System.Utilis
{
	public class ClaimRequirementFilter : IAuthorizationFilter
    {
        private readonly Claim _claim;
        private readonly BusTicketDbContext _busTicketDbContext;

        public ClaimRequirementFilter(Claim claim, BusTicketDbContext busTiketDbContext)
        {
            _claim = claim;
            _busTicketDbContext = busTiketDbContext;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            //var hasClaim = context.HttpContext.User.Claims.Any(c => c.Type == _claim.Type && c.Value == _claim.Value);

            var email = context.HttpContext.User.FindFirstValue("preferred_username");

            var user = _busTicketDbContext.Users.Where(u=> u.Email==email).FirstOrDefault();

            Console.WriteLine(user.role);

            if (user.role != _claim.Value)
            {
                context.Result = new ForbidResult();
            }
        }
    }
}

