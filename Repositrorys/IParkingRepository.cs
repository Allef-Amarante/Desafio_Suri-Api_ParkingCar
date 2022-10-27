using ParkingCar3.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ParkingCar3.Repositrorys
{
    public interface IParkingRepository
    {
        Task<IEnumerable<Parking>> List();

        Task<Parking> Get(int id);

        Task<Parking> Create(Parking parking);

        Task Delete(int id);
    }
}
