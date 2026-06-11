using HotelBookingAPI.DTOs;

namespace HotelBookingAPI.Services
{
    public interface IAuthService
    {
        Task<string> Register(RegisterDTO registerDTO);
        Task<string> Login(LoginDTO loginDTO);
    }
}