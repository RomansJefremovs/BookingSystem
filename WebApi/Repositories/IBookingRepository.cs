using System.Collections.Generic;
using System.Threading.Tasks;
using Models;

namespace WebApi.Repositories
{
    public interface IBookingRepository
    {
        Task<IEnumerable<Booking>> GetBookings();
        Task<Booking> GetBooking(int bookingId);
        Task<Booking> AddBooking(Booking booking);
        Task<Booking> UpdateBooking(Booking booking);
        Task<Booking> DeleteBooking(int bookingId);
    }
}