using HotelBookingAPI.Models;

namespace HotelBookingAPI.Services
{
    public interface IRoomService
    {
        Task<List<Room>> GetAllRooms();
        Task<Room> GetRoomById(int id);
        Task<Room> AddRoom(Room room);
        Task<Room> UpdateRoom(int id, Room updatedRoom);
        Task<bool> DeleteRoom(int id);
    }
}