using HotelBookingAPI.Models;

namespace HotelBookingAPI.Services
{
    public interface IBookingService
    {
        Task<List<Booking>> GetAllBookings();
        Task<Booking?> GetBookingById(int id);
        Task<Booking> CreateBooking(Booking booking);
        Task<bool> CancelBooking(int id);
    }
}