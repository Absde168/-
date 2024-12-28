using HotelGraphQL.Models;

namespace HotelGraphQL.DAO
{
    public interface IRoomRepository
    {
        IQueryable<Room> GetAllRooms();
        Task<Room> GetRoomById(int id);
        Task<Room> AddRoom(Room room);
        Task<Room> UpdateRoom(Room room);
        Task<bool> DeleteRoom(int id);
    }
}
