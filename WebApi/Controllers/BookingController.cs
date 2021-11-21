using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using WebApi.Repositories;

namespace WebApi.Controllers
{
    [Route("api[controller]")]
    [ApiController]
    public class BookingController: ControllerBase
    {
        private readonly IBookingRepository bookingRepository;
        public BookingController(IBookingRepository bookingRepository)
        {
            this.bookingRepository = bookingRepository;

        }
        
        [HttpGet]
        public async Task<ActionResult> GetBookings()
        {
            try
            {
                return Ok(await bookingRepository.GetBookings());
            }
            catch (Exception e)
            {
                StatusCode(StatusCodes.Status500InternalServerError,"Error retrieving from the database ");
                throw;
            }
        }
        
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Booking>> GetBooking(int id)
        {
            try
            {
                var result = await bookingRepository.GetBooking(id);
                if (result == null )
                {
                    return NotFound();
                }

                return result;
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,"Error retrieving from the database ");
                
            }
        }
        [HttpPost]
        public async Task<ActionResult<Booking>> CreateBooking(Booking booking)
        {
            try
            {
                if (booking == null)
                {
                    return BadRequest();
                }
                var createdBooking = await bookingRepository.AddBooking(booking);

                return CreatedAtAction(nameof(GetBooking),new {id = createdBooking.Id},createdBooking );
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,"Error retrieving from the database ");
                
            }
            
        }
        [HttpPut("{id:int}")]
        public async Task<ActionResult<Booking>> UpdateBooking(int id, Booking booking)
        {
            try
            {
                if (id != booking.Id)
                {
                    return BadRequest("Resource ID mismatch");
                }
                var res = await bookingRepository.GetBooking(id);
                if (res == null)
                {
                    return NotFound($"Resource with ID = {id} not found");
                }

                return await bookingRepository.UpdateBooking(booking);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,"Error updating data");
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Booking>> DeleteBooking(int id)
        {
            try
            {
                var res = await bookingRepository.GetBooking(id);
                if (res == null)
                {
                    return NotFound($"Resource with ID = {id} not found");
                }

               return await bookingRepository.DeleteBooking(id);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,"Error deleting  data");
            }
        }
    }
}