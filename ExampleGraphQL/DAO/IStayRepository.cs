using HotelGraphQL.Models;

namespace HotelGraphQL.DAO
{
    public interface IStayRepository
    {
        IQueryable<Stay> GetAllStays();
        Task<Stay> GetStayById(int id);
        Task<Stay> AddStay(Stay stay);
        Task<Stay> UpdateStay(Stay stay);
        Task<bool> DeleteStay(int id);
    }
}
