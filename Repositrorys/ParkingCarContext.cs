using Microsoft.EntityFrameworkCore;
using ParkingCar3.Models;

namespace ParkingCar3.Repositrorys
{
    public class ParkingCarContext:DbContext
    {
        public ParkingCarContext(DbContextOptions<ParkingCarContext> options):base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Car> Cars { get; set; }

        public DbSet<Parking> Parkings { get; set; }

    }
}
