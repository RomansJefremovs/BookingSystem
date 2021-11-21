using Microsoft.EntityFrameworkCore;
using Models;

namespace WebApi.Models
{
    public class MyDBContext: DbContext
    {
        public MyDBContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Resource> Resources { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source = BookingSystem.db");
        }
    }
}