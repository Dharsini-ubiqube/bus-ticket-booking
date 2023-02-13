using System;
using Bus_Ticket_Booking_System.src.Models;
using Bus_Ticket_Booking_System.src.Models.Dto;
using Microsoft.AspNetCore.Mvc;

namespace Bus_Ticket_Booking_System.Interfaces.Services
{
    public interface IBusService
    {
        public void addBuses(AddBusRequest busModel) { }

        public string deleteBuses(int id);

        public IEnumerable<BusModel> getAllbuses();
        public IEnumerable<BusModel> getBusById(int id);
        public BusModel getByBoardingandDestination(string BoardingLocation, string DestinationLocation, string date);
        public IEnumerable<BusModel> UpdateBusById(int id, BusModel busModel);
    }
}

