using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Project_HotelManagement
{
    public class HotelManagementDbContext(DbContextOptions<HotelManagementDbContext> options) : DbContext(options)
    {
        public DbSet<Customers> Customers { get; set; }
        public DbSet<Bookings> Bookings { get; set; }
        public DbSet<Rooms> Rooms { get; set; }
        public DbSet<Payments> Payments { get; set; }
        public DbSet<Services> Services { get; set; }
        public DbSet<Booking_Services> Bookings_Services { get; set;}
    }
}
