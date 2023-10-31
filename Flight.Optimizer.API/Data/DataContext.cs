using Flight.Optimizer.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace Flight.Optimizer.API.Data;

public class DataContext: DbContext
{
    public DataContext(DbContextOptions options) : base(options) { }

    public DbSet<Passenger> Passengers { get; set; }
}
