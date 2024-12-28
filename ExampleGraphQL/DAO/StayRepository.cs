using HotelGraphQL.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelGraphQL.DAO
{
    public class StayRepository : IStayRepository
    {
        private readonly HotelDbContext _db;

        public StayRepository(HotelDbContext db)
        {
            _db = db;
        }

        public IQueryable<Stay> GetAllStays()
        {
            return _db.Stays.AsQueryable();
        }

        public async Task<Stay> GetStayById(int id)
        {
            return await _db.Stays.FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<Stay> AddStay(Stay stay)
        {
            _db.Stays.Add(stay);
            await _db.SaveChangesAsync();
            return stay;
        }

        public async Task<Stay> UpdateStay(Stay stay)
        {
            var existingStay = await _db.Stays.FirstOrDefaultAsync(s => s.Id == stay.Id);
            if (existingStay != null)
            {
                existingStay.CheckInDate = stay.CheckInDate;
                existingStay.CheckOutDate = stay.CheckOutDate;
                existingStay.TotalPrice = stay.TotalPrice;
                _db.Stays.Update(existingStay);
                await _db.SaveChangesAsync();
            }
            return existingStay!;
        }

        public async Task<bool> DeleteStay(int id)
        {
            var stay = await _db.Stays.FirstOrDefaultAsync(s => s.Id == id);
            if (stay != null)
            {
                _db.Stays.Remove(stay);
                await _db.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
