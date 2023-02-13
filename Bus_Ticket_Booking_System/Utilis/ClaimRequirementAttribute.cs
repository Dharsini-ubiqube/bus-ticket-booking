using System;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;

namespace Bus_Ticket_Booking_System.Utilis
{
	public class ClaimRequirementAttribute : TypeFilterAttribute
    {
        public ClaimRequirementAttribute(string claimType, string claimValue) : base(typeof(ClaimRequirementFilter))
        {
            Arguments = new object[] { new Claim(claimType, claimValue) };
        }
    }
}

