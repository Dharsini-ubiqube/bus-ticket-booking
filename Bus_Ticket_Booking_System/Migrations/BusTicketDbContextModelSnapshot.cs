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
                        .HasColumnType("longtext");

                    b.Property<string>("BusName")
                        .HasColumnType("longtext");

                    b.Property<string>("DestinationLocation")
                        .HasColumnType("longtext");

                    b.Property<string>("date")
                        .HasColumnType("longtext");

                    b.Property<int?>("price")
                        .HasColumnType("int");

                    b.Property<int?>("seats")
                        .HasColumnType("int");

                    b.Property<string>("time")
                        .HasColumnType("longtext");

                    b.HasKey("id");

                    b.ToTable("Buses");
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
#pragma warning restore 612, 618
        }
    }
}
