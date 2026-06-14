using HotelBookingAPI.Data;
using HotelBookingAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelBookingAPI.Services
{
    public class RoomService : IRoomService
    {
        private readonly AppDbContext _context;

        public RoomService(AppDbContext context)
        {
            _context = context;
        }

        // CREATE
        public async Task<Room> AddRoom(Room room)
        {
            room.IsAvailable = true;
            _context.Rooms.Add(room);
            await _context.SaveChangesAsync();
            return room;
        }

        // READ ALL
        public async Task<List<Room>> GetAllRooms()
        {
            return await _context.Rooms.ToListAsync();
        }

        // READ ONE
        public async Task<Room> GetRoomById(int id)
        {
            return await _context.Rooms
                   .FirstOrDefaultAsync(r => r.Id == id);
        }

        // UPDATE
        public async Task<Room> UpdateRoom(int id, Room updatedRoom)
        {
            var room = await _context.Rooms
                       .FirstOrDefaultAsync(r => r.Id == id);
            if (room == null) return null;

            room.Name = updatedRoom.Name;
            room.Description = updatedRoom.Description;
            room.Price = updatedRoom.Price;
            room.IsAvailable = updatedRoom.IsAvailable;
            room.ImageUrl = updatedRoom.ImageUrl;

            await _context.SaveChangesAsync();
            return room;
        }

        // DELETE
        public async Task<bool> DeleteRoom(int id)
        {
            var room = await _context.Rooms
                       .FirstOrDefaultAsync(r => r.Id == id);
            if (room == null) return false;

            _context.Rooms.Remove(room);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}