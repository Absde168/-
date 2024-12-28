using HotelGraphQL.Models;

namespace HotelGraphQL.DAO
{
    public interface IServiceRepository
    {
        IQueryable<Service> GetAllServices();
        Task<Service> GetServiceById(int id);
        Task<Service> AddService(Service service);
        Task<Service> UpdateService(Service service);
        Task<bool> DeleteService(int id);
    }
}
