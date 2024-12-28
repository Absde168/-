using HotelGraphQL.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelGraphQL.DAO
{
    public class ServiceRepository : IServiceRepository
    {
        private readonly HotelDbContext _db;

        public ServiceRepository(HotelDbContext db)
        {
            _db = db;
        }

        public IQueryable<Service> GetAllServices()
        {
            return _db.Services.AsQueryable();
        }

        public async Task<Service> GetServiceById(int id)
        {
            return await _db.Services.FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<Service> AddService(Service service)
        {
            _db.Services.Add(service);
            await _db.SaveChangesAsync();
            return service;
        }

        public async Task<Service> UpdateService(Service service)
        {
            var existingService = await _db.Services.FirstOrDefaultAsync(s => s.Id == service.Id);
            if (existingService != null)
            {
                existingService.Name = service.Name;
                existingService.Price = service.Price;
                _db.Services.Update(existingService);
                await _db.SaveChangesAsync();
            }
            return existingService!;
        }

        public async Task<bool> DeleteService(int id)
        {
            var service = await _db.Services.FirstOrDefaultAsync(s => s.Id == id);
            if (service != null)
            {
                _db.Services.Remove(service);
                await _db.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
