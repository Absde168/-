using HotelGraphQL.Models;

namespace HotelGraphQL.DAO
{
    public interface IGuestRepository
    {
        IQueryable<Guest> GetAllGuests();
        Task<Guest> GetGuestById(int id);
        Task<Guest> AddGuest(Guest guest);
        Task<Guest> UpdateGuest(Guest guest);
        Task<bool> DeleteGuest(int id);
    }
}
