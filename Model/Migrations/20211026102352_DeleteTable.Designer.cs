﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Model.DBContext;

namespace Model.Migrations
{
    [DbContext(typeof(CarParkDbContext))]
    [Migration("20211026102352_DeleteTable")]
    partial class DeleteTable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Model.Entity.BookingOffice", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("EndContractDeadline")
                        .HasColumnType("datetime2");

                    b.Property<string>("OfficeName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OfficePhone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OfficePlace")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("OfficePrime")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartContractDeadline")
                        .HasColumnType("datetime2");

                    b.Property<int?>("TripId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TripId");

                    b.ToTable("BookingOffices");
                });

            modelBuilder.Entity("Model.Entity.Car", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CarColor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CarType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Company")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LicensePlate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ParkingLotId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ParkingLotId");

                    b.ToTable("Cars");
                });

            modelBuilder.Entity("Model.Entity.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Account")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("Department")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Sex")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("Model.Entity.ParkingLot", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ParkArea")
                        .HasColumnType("int");

                    b.Property<string>("ParkName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ParkPlace")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ParkPrice")
                        .HasColumnType("int");

                    b.Property<string>("ParkStratus")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ParkingLots");
                });

            modelBuilder.Entity("Model.Entity.Ticket", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("BookingTime")
                        .HasColumnType("datetime2");

                    b.Property<int?>("CarId")
                        .HasColumnType("int");

                    b.Property<string>("CustomerName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LicensePlate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TripId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CarId");

                    b.HasIndex("TripId");

                    b.ToTable("Ticks");
                });

            modelBuilder.Entity("Model.Entity.Trip", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BookedTicketNumber")
                        .HasColumnType("int");

                    b.Property<string>("CarType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DepartureDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DepartureTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Destination")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Driver")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MaximumOnlineTicketNumber")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Trips");
                });

            modelBuilder.Entity("Model.Entity.BookingOffice", b =>
                {
                    b.HasOne("Model.Entity.Trip", "Trip")
                        .WithMany()
                        .HasForeignKey("TripId");

                    b.Navigation("Trip");
                });

            modelBuilder.Entity("Model.Entity.Car", b =>
                {
                    b.HasOne("Model.Entity.ParkingLot", "ParkingLot")
                        .WithMany()
                        .HasForeignKey("ParkingLotId");

                    b.Navigation("ParkingLot");
                });

            modelBuilder.Entity("Model.Entity.Ticket", b =>
                {
                    b.HasOne("Model.Entity.Car", "Car")
                        .WithMany()
                        .HasForeignKey("CarId");

                    b.HasOne("Model.Entity.Trip", "Trip")
                        .WithMany()
                        .HasForeignKey("TripId");

                    b.Navigation("Car");

                    b.Navigation("Trip");
                });
#pragma warning restore 612, 618
        }
    }
}
