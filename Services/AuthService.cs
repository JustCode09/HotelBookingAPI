using HotelBookingAPI.Data;
using HotelBookingAPI.DTOs;
using HotelBookingAPI.Helpers;
using HotelBookingAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelBookingAPI.Services
{
    public class AuthService : IAuthService
    {
        private readonly AppDbContext _context;
        private readonly JwtHelper _jwtHelper;

        public AuthService(AppDbContext context, JwtHelper jwtHelper)
        {
            _context = context;
            _jwtHelper = jwtHelper;
        }

        // REGISTER
        public async Task<string> Register(RegisterDTO registerDTO)
        {
            // Check if email already exists
            var existingUser = await _context.Users
                .FirstOrDefaultAsync(u => u.Email == registerDTO.Email);

            if (existingUser != null)
                return "Email already exists";

            // Hash password
            var hashedPassword = BCrypt.Net.BCrypt.HashPassword(registerDTO.Password);

            // Create new user
            var user = new User
            {
                Name = registerDTO.Name,
                Email = registerDTO.Email,
                Password = hashedPassword,
                Role = "Customer",
                CreatedAt = DateTime.Now
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            // Generate and return token
            return _jwtHelper.GenerateToken(user);
        }

        // LOGIN
        public async Task<string> Login(LoginDTO loginDTO)
        {
            // Find user by email
            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.Email == loginDTO.Email);

            if (user == null)
                return "Invalid email or password";

            // Verify password
            bool isPasswordValid = BCrypt.Net.BCrypt
                .Verify(loginDTO.Password, user.Password);

            if (!isPasswordValid)
                return "Invalid email or password";

            // Generate and return token
            return _jwtHelper.GenerateToken(user);
        }
    }
}