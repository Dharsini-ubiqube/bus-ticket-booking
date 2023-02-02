﻿// <auto-generated />
using System;
using Bus_Ticket_Booking_System.src.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Bus_Ticket_Booking_System.Migrations
{
    [DbContext(typeof(BusTicketDbContext))]
    partial class BusTicketDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Bus_Ticket_Booking_System.src.Models.BusModel", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("BoardingLocation")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("BusName")
                        .HasColumnType("longtext");

                    b.Property<string>("DestinationLocation")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Via")
                        .HasColumnType("varchar(255)");

                    b.Property<DateTime>("date")
                        .HasColumnType("datetime(6)");

                    b.Property<int?>("price")
                        .HasColumnType("int");

                    b.Property<int?>("seats")
                        .HasColumnType("int");

                    b.Property<int?>("seatsBtoVia")
                        .HasColumnType("int");

                    b.Property<int?>("seatsViatoD")
                        .HasColumnType("int");

                    b.Property<string>("time")
                        .HasColumnType("longtext");

                    b.HasKey("id");

                    b.HasIndex("BoardingLocation");

                    b.HasIndex("DestinationLocation");

                    b.HasIndex("Via");

                    b.ToTable("Buses");
                });

            modelBuilder.Entity("Bus_Ticket_Booking_System.src.Models.LocationModel", b =>
                {
                    b.Property<string>("location")
                        .HasColumnType("varchar(255)");

                    b.Property<int>("id")
                        .HasColumnType("int");

                    b.HasKey("location");

                    b.ToTable("Locations");
                });

            modelBuilder.Entity("Bus_Ticket_Booking_System.src.Models.TicketModel", b =>
                {
                    b.Property<int>("ticketId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("busId")
                        .HasColumnType("int");

                    b.Property<DateTime>("date")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("end")
                        .HasColumnType("longtext");

                    b.Property<int>("numberOfSets")
                        .HasColumnType("int");

                    b.Property<int>("price")
                        .HasColumnType("int");

                    b.Property<string>("start")
                        .HasColumnType("longtext");

                    b.Property<string>("userEmail")
                        .HasColumnType("varchar(255)");

                    b.HasKey("ticketId");

                    b.HasIndex("busId");

                    b.HasIndex("userEmail");

                    b.ToTable("Tickets");
                });

            modelBuilder.Entity("Bus_Ticket_Booking_System.src.Models.UserModel", b =>
                {
                    b.Property<string>("email")
                        .HasColumnType("varchar(255)");

                    b.Property<Guid>("Id")
                        .HasColumnType("char(36)");

                    b.Property<bool>("isAdmin")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("name")
                        .HasColumnType("longtext");

                    b.Property<string>("password")
                        .HasColumnType("longtext");

                    b.HasKey("email");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Bus_Ticket_Booking_System.src.Models.BusModel", b =>
                {
                    b.HasOne("Bus_Ticket_Booking_System.src.Models.LocationModel", "Location1")
                        .WithMany()
                        .HasForeignKey("BoardingLocation");

                    b.HasOne("Bus_Ticket_Booking_System.src.Models.LocationModel", "Location2")
                        .WithMany()
                        .HasForeignKey("DestinationLocation");

                    b.HasOne("Bus_Ticket_Booking_System.src.Models.LocationModel", "Location3")
                        .WithMany()
                        .HasForeignKey("Via");

                    b.Navigation("Location1");

                    b.Navigation("Location2");

                    b.Navigation("Location3");
                });

            modelBuilder.Entity("Bus_Ticket_Booking_System.src.Models.TicketModel", b =>
                {
                    b.HasOne("Bus_Ticket_Booking_System.src.Models.BusModel", "bus")
                        .WithMany()
                        .HasForeignKey("busId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Bus_Ticket_Booking_System.src.Models.UserModel", "user")
                        .WithMany()
                        .HasForeignKey("userEmail");

                    b.Navigation("bus");

                    b.Navigation("user");
                });
#pragma warning restore 612, 618
        }
    }
}
