using HotelBookingAPI.Models;
using HotelBookingAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HotelBookingAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _bookingService;

        public BookingController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        // GET api/booking
        [HttpGet]
        public async Task<IActionResult> GetAllBookings()
        {
            var bookings = await _bookingService.GetAllBookings();
            return Ok(bookings);
        }

        // GET api/booking/1
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBookingById(int id)
        {
            var booking = await _bookingService.GetBookingById(id);
            if (booking == null)
                return NotFound("Booking not found");
            return Ok(booking);
        }

        // POST api/booking
        [HttpPost]
        public async Task<IActionResult> CreateBooking(Booking booking)
        {
            var newBooking = await _bookingService.CreateBooking(booking);
            if (newBooking == null)
                return BadRequest("Room not available or not found");
            return CreatedAtAction(nameof(GetBookingById),
                                   new { id = newBooking.Id },
                                   newBooking);
        }

        // DELETE api/booking/1
        [HttpDelete("{id}")]
        public async Task<IActionResult> CancelBooking(int id)
        {
            var result = await _bookingService.CancelBooking(id);
            if (!result)
                return NotFound("Booking not found");
            return Ok("Booking cancelled successfully");
        }
    }
}
