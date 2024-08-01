using Hotel.Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace Hotel.Dal;

public class HotelContext : DbContext
{
    public HotelContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Room> Rooms { get; set; }
    public DbSet<Visitor> Visitors { get; set; }
}
