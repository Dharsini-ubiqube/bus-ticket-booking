using System;
using System.ComponentModel.DataAnnotations;

namespace Bus_Ticket_Booking_System.src.Models.Dto
{
	public class AddBusRequest
	{
        public string? BusName { get; set; }
        public string? BoardingLocation { get; set; }
        public string? DestinationLocation { get; set; }
        public int? price { get; set; }
        public int? seats { get; set; }
        public string? time { get; set; }
        public string? date { get; set; }
    }
}

