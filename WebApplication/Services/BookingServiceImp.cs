using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace WebApplication.Services
{
    public class BookingServiceImp:IBookingService
    {
        private readonly HttpClient httpClient;
        
        public BookingServiceImp(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<IEnumerable<Booking>> GetBookings()
        {
            return await httpClient.GetJsonAsync<Booking[]>("apiBooking");
        }

        public async Task<ActionResult<Booking>> CreateBooking(Booking booking)
        {
            return await httpClient.PostJsonAsync<Booking>("apiBooking", booking);
        }
    }
}