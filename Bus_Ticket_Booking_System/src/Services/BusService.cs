using System;
using Bus_Ticket_Booking_System.Interfaces.Repositories;
using Bus_Ticket_Booking_System.Interfaces.Services;
using Bus_Ticket_Booking_System.src.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Bus_Ticket_Booking_System.src.Services
{
	public class BusService: IBusService
	{
		private readonly IBusRepository _busRepository;
		public BusService(IBusRepository busRepository)
		{
			_busRepository = busRepository;
		}
		public void addBuses(BusModel busModel)
		{
			if (busModel.BusName == null)
			{
                throw new Exception("Invalid BusName");
            }
			_busRepository.addBuses(busModel);
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
    }
}

