using System;
using Bus_Ticket_Booking_System.src.Models;

namespace Bus_Ticket_Booking_System.Interfaces.Repositories
{
	public interface IBusRepository
	{
        public void addBuses(BusModel busModel) { }
        public string deleteBuses(int id);
        public IEnumerable<BusModel> getAllbuses();
        public IEnumerable<BusModel> getBusById(int id);
        public IEnumerable<BusModel> UpdateBusById(int id, BusModel busModel);
    }
}

