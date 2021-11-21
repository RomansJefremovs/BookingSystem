using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Models;
using WebApi.Models;

namespace WebApi.Repositories
{
    public class BookingRepositoryImp: IBookingRepository
    {
        private readonly MyDBContext myDbContext;

        public BookingRepositoryImp( MyDBContext myDbContext)
        {
            this.myDbContext = myDbContext;
        }
        public async Task<IEnumerable<Booking>> GetBookings()
        {
            return await myDbContext.Bookings.ToListAsync();
        }

        public async Task<Booking> GetBooking(int bookingId)
        {
            return await myDbContext.Bookings.FirstOrDefaultAsync(b=>b.Id == bookingId);
        }

        public async Task<Booking> AddBooking(Booking booking)
        {
           var result = await myDbContext.Bookings.AddAsync(booking);
           await myDbContext.SaveChangesAsync();
           return result.Entity;
        }

        public async Task<Booking> UpdateBooking(Booking booking)
        {
            var result = await myDbContext.Bookings.FirstOrDefaultAsync(b => b.Id == booking.Id);
            if (result != null)
            {
                result.Id = booking.Id;
                result.BookedQuantity = booking.BookedQuantity;
                result.DateFrom = booking.DateFrom;
                result.DateTo = booking.DateTo;
                result.ResourceId = booking.ResourceId;
                await myDbContext.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async void DeleteBooking(int bookingId)
        {
            var result = await myDbContext.Bookings.FirstOrDefaultAsync(b=>b.Id == bookingId);
            if (result != null)
            {
                 myDbContext.Bookings.Remove(result);
                 await myDbContext.SaveChangesAsync();
            }
        }
    }
}