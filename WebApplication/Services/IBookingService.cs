using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace WebApplication.Services
{
    public interface IBookingService
    {
        Task<IEnumerable<Booking>> GetBookings();
        Task<ActionResult<Booking>> CreateBooking(Booking booking);
        
       
    }
}