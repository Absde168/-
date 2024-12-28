using HotelGraphQL.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelGraphQL.DAO
{
    public class GuestRepository : IGuestRepository
    {
        private readonly HotelDbContext _db;

        public GuestRepository(HotelDbContext db)
        {
            _db = db;
        }

        public IQueryable<Guest> GetAllGuests()
        {
            return _db.Guests.AsQueryable();
        }

        public async Task<Guest> GetGuestById(int id)
        {
            return await _db.Guests.FirstOrDefaultAsync(g => g.Id == id);
        }

        public async Task<Guest> AddGuest(Guest guest)
        {
            _db.Guests.Add(guest);
            await _db.SaveChangesAsync();
            return guest;
        }

        public async Task<Guest> UpdateGuest(Guest guest)
        {
            var existingGuest = await _db.Guests.FirstOrDefaultAsync(g => g.Id == guest.Id);
            if (existingGuest != null)
            {
                existingGuest.Name = guest.Name;
                existingGuest.Phone = guest.Phone;
                _db.Guests.Update(existingGuest);
                await _db.SaveChangesAsync();
            }
            return existingGuest!;
        }

        public async Task<bool> DeleteGuest(int id)
        {
            var guest = await _db.Guests.FirstOrDefaultAsync(g => g.Id == id);
            if (guest != null)
            {
                _db.Guests.Remove(guest);
                await _db.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
