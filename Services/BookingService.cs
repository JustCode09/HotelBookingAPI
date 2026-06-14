using HotelBookingAPI.Data;
using HotelBookingAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelBookingAPI.Services
{
    public class BookingService : IBookingService
    {
        private readonly AppDbContext _context;

        public BookingService(AppDbContext context)
        {
            _context = context;
        }

        // GET ALL
        public async Task<List<Booking>> GetAllBookings()
        {
            return await _context.Bookings.ToListAsync();
        }

        // GET ONE
        public async Task<Booking?> GetBookingById(int id)
        {
            return await _context.Bookings
                   .FirstOrDefaultAsync(b => b.Id == id);
        }

        // CREATE BOOKING
        public async Task<Booking> CreateBooking(Booking booking)
        {
            // Check if room exists
            var room = await _context.Rooms
                       .FirstOrDefaultAsync(r => r.Id == booking.RoomId);

            if (room == null) return null!;

            // Check if room is available
            if (!room.IsAvailable) return null!;

            // Set booking details
            booking.Status = "Confirmed";

            // Mark room as unavailable
            room.IsAvailable = false;

            _context.Bookings.Add(booking);
            await _context.SaveChangesAsync();
            return booking;
        }

        // CANCEL BOOKING
        public async Task<bool> CancelBooking(int id)
        {
            var booking = await _context.Bookings
                          .FirstOrDefaultAsync(b => b.Id == id);

            if (booking == null) return false;

            // Find the room and mark available again
            var room = await _context.Rooms
                       .FirstOrDefaultAsync(r => r.Id == booking.RoomId);

            if (room != null)
                room.IsAvailable = true;

            // Update booking status
            booking.Status = "Cancelled";

            await _context.SaveChangesAsync();
            return true;
        }
    }
}