using HotelGraphQL.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelGraphQL
{
    public class HotelDbContext : DbContext
    {
        public HotelDbContext(DbContextOptions<HotelDbContext> options) : base(options)
        { }

        public DbSet<Room> Rooms { get; set; }
        public DbSet<Guest> Guests { get; set; }
        public DbSet<Stay> Stays { get; set; }
        public DbSet<Service> Services { get; set; }
    }
}
