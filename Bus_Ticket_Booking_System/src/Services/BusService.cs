using System;
using Bus_Ticket_Booking_System.Interfaces.Repositories;
using Bus_Ticket_Booking_System.Interfaces.Services;
using Bus_Ticket_Booking_System.src.Models;
using Bus_Ticket_Booking_System.src.Models.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Bus_Ticket_Booking_System.src.Services
{
	public class BusService : IBusService
	{
		private readonly IBusRepository _busRepository;
		private readonly ILocationRepository _locationRepository;

		public BusService(IBusRepository busRepository, ILocationRepository locationRepository)
		{
			_busRepository = busRepository;
			_locationRepository = locationRepository;
		}
        //public void addBuses(AddBusRequest busModel)
        //{
        //	if (busModel.BusName == null)
        //	{
        //              throw new Exception("Invalid BusName");
        //          }

        //	var boarding = _locationRepository.getLocationByName(busModel.BoardingLocation);

        //	var destination = _locationRepository.getLocationByName(busModel.DestinationLocation);

        //	if(boarding == null)
        //	{
        //              throw new Exception("invaild location given location not found");
        //	}

        //	if(destination == null)
        //	{
        //              throw new Exception("invaild location given location not found");
        //          }

        //	var bus = new BusModel();
        //	bus.BoardingLocation = boarding;
        //	bus.DestinationLocation = destination;
        //	bus.BusName = busModel.BusName;
        //	bus.price = busModel.price;
        //	bus.seats = busModel.seats;
        //	bus.time = busModel.time;
        //	bus.date = busModel.date;

        //          _busRepository.addBuses(bus);

        //}


        public void addBuses(AddBusRequest busModel)
        {
            if (busModel.BusName == null)
            {
                throw new Exception("Invalid BusName");
            }

            var boarding = _locationRepository.getLocationByName(busModel.BoardingLocation);

            var destination = _locationRepository.getLocationByName(busModel.DestinationLocation);

            if (boarding == null)
            {
                throw new Exception("invaild location given location not found");
            }

            if (destination == null)
            {
                throw new Exception("invaild location given location not found");
            }

            var bus = new BusModel();
            bus.BoardingLocation = busModel.BoardingLocation;
            bus.DestinationLocation = busModel.DestinationLocation;
            bus.Via = busModel.Via;
            bus.seatsBtoVia = busModel.seatsBtoVia;
            bus.seatsViatoD = busModel.seatsViatoD;
            bus.BusName = busModel.BusName;
            bus.price = busModel.price;
            bus.seats = busModel.seats;
            bus.time = busModel.time;
            bus.date = busModel.date;

            _busRepository.addBuses(bus);

        }



        public IEnumerable<BusModel> getAllbuses()
		{

			return (_busRepository.getAllbuses());
		}

		public string deleteBuses(int id)
		{
			return (_busRepository.deleteBuses(id));
		}
		public IEnumerable<BusModel> getBusById(int id)
		{
			return (_busRepository.getBusById(id));
		}
        public IEnumerable<BusModel> UpdateBusById(int id , BusModel busModel)
        {
			return (_busRepository.UpdateBusById(id, busModel));
        }
        public BusModel getByBoardingandDestination(string BoardingLocation, string DestinationLocation, string date)
        {


            return (_busRepository.getByBoardingandDestination(BoardingLocation, DestinationLocation, date));
        }
    }
		
    
}

