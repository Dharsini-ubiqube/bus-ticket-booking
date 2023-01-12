using System;
using Bus_Ticket_Booking_System.src.Models;
using Microsoft.EntityFrameworkCore;

namespace Bus_Ticket_Booking_System.src.Data
{
    public class BusTicketDbContext : DbContext
    {
        public BusTicketDbContext(DbContextOptions<BusTicketDbContext> options) : base(options)
        {
        }
        public DbSet<UserModel> Users { get; set; }
        public DbSet<BusModel> Buses { get; set; }
    }
}

