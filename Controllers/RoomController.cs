using HotelBookingAPI.Models;
using HotelBookingAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HotelBookingAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RoomController : ControllerBase
    {
        private readonly IRoomService _roomService;

        public RoomController(IRoomService roomService)
        {
            _roomService = roomService;
        }

        // GET api/room
        [HttpGet]
        public async Task<IActionResult> GetAllRooms()
        {
            var rooms = await _roomService.GetAllRooms();
            return Ok(rooms);
        }

        // GET api/room/1
        [HttpGet("{id}")]
        public async Task<IActionResult> GetRoomById(int id)
        {
            var room = await _roomService.GetRoomById(id);
            if (room == null)
                return NotFound("Room not found");
            return Ok(room);
        }

        // POST api/room
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddRoom(Room room)
        {
            var newRoom = await _roomService.AddRoom(room);
            return CreatedAtAction(nameof(GetRoomById),
                                   new { id = newRoom.Id },
                                   newRoom);
        }

        // PUT api/room/1
        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> UpdateRoom(int id, Room updatedRoom)
        {
            var room = await _roomService.UpdateRoom(id, updatedRoom);
            if (room == null)
                return NotFound("Room not found");
            return Ok(room);
        }

        // DELETE api/room/1
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteRoom(int id)
        {
            var result = await _roomService.DeleteRoom(id);
            if (!result)
                return NotFound("Room not found");
            return Ok("Room deleted successfully");
        }
    }
}