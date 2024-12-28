using HotelGraphQL.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelGraphQL.DAO
{
    public class RoomRepository : IRoomRepository
    {
        private readonly HotelDbContext _db;

        public RoomRepository(HotelDbContext db)
        {
            _db = db;
        }

        public IQueryable<Room> GetAllRooms()
        {
            return _db.Rooms.AsQueryable();
        }

        public async Task<Room> GetRoomById(int id)
        {
            return await _db.Rooms.FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task<Room> AddRoom(Room room)
        {
            _db.Rooms.Add(room);
            await _db.SaveChangesAsync();
            return room;
        }

        public async Task<Room> UpdateRoom(Room room)
        {
            var existingRoom = await _db.Rooms.FirstOrDefaultAsync(r => r.Id == room.Id);
            if (existingRoom != null)
            {
                existingRoom.Number = room.Number;
                existingRoom.Capacity = room.Capacity;
                existingRoom.PricePerNight = room.PricePerNight;
                existingRoom.IsReserved = room.IsReserved;
                _db.Rooms.Update(existingRoom);
                await _db.SaveChangesAsync();
            }
            return existingRoom!;
        }

        public async Task<bool> DeleteRoom(int id)
        {
            var room = await _db.Rooms.FirstOrDefaultAsync(r => r.Id == id);
            if (room != null)
            {
                _db.Rooms.Remove(room);
                await _db.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
