using System;
using System.ComponentModel.DataAnnotations;

namespace Bus_Ticket_Booking_System.src.Models.Dto
{
	public class AddBusRequest
	{
        public string? BusName { get; set; }
        public string? BoardingLocation { get; set; }
        public string? DestinationLocation { get; set; }
        public string? Via { get; set; }
        public int? price { get; set; }
        public int? seats { get; set; }
        public int? seatsBtoVia { get; set; }
        public int? seatsViatoD { get; set; }
        public string? time { get; set; }
        public DateTime date { get; set; }
    }
}

