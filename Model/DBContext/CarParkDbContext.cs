using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Model.Entity;

namespace Model.DBContext
{
    public class CarParkDbContext : DbContext
    {
        public DbSet<BookingOffice> BookingOffices { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<ParkingLot> ParkingLots { get; set; }
        public DbSet<Trip> Trips { get; set; }
        public DbSet<Ticket> Ticks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=localhost,1433;database=blog;uid=SA;password=Anh_hoang_99;Database=CarPark_v1;Trusted_Connection=True;Integrated Security=false;");
        }
    }
}
