using ParkingCar3.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ParkingCar3.Repositrorys
{
    public interface ICarRepository
    {
        Task<IEnumerable<Car>> List(int parkingId);

        Task<Car> Get(int id);

        Task<Car> Create(Car car);  

        Task Delete(int id);

    }
}
