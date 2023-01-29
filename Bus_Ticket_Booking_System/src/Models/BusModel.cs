using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bus_Ticket_Booking_System.src.Models
{
	public class BusModel
	{
		[Key]
		public int id { get; set; }
		public string? BusName { get; set; }
        //      public LocationModel? BoardingLocation { get; set; }
        //public LocationModel? DestinationLocation { get; set; }
        [ForeignKey("Location1")]//tpt
        public string? BoardingLocation { get; set; }
        [ForeignKey("Location3")]//chennai
        public string? Via { get; set; }
        [ForeignKey("Location2")]//cbe
        public string? DestinationLocation { get; set; }
       
        public virtual LocationModel Location1 { get; set; }
        public virtual LocationModel Location2 { get; set; }
        public virtual LocationModel Location3 { get; set; }
        public int? price { get; set; }
		public int? seats { get; set; }
        public int? seatsBtoVia { get; set; }
        public int? seatsViatoD { get; set; }
        public string? time { get; set; }
		public DateTime date { get; set; }
	}
}

