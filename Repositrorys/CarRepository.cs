using Microsoft.EntityFrameworkCore;
using ParkingCar3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkingCar3.Repositrorys
{
    public class CarRepository:ICarRepository
    {
        public readonly ParkingCarContext _Context;

        public CarRepository(ParkingCarContext context)
        {
            _Context=context;
        }

        public async Task<Car> Create(Car car)
        {
            var parkinId = _Context.Parkings.FirstOrDefault(o => o.Id == car.ParkingId);
            if (parkinId == null)
                throw new Exception("Estacionamento inexistente ");

            _Context.Cars.Add(car);
            await _Context.SaveChangesAsync();
            return car;
        }

        public async Task Delete(int id)
        {
            var toDelete = await _Context.Cars.FindAsync(id);
            _Context.Cars.Remove(toDelete);
            await _Context.SaveChangesAsync();
            
        }

        public async Task<Car> Get(int id)
        {
            return await _Context.Cars.FindAsync(id);
        }

        public async Task<IEnumerable<Car>> List(int parkingId)
        {
            var parking = _Context.Parkings.FirstOrDefault(o => o.Id ==parkingId);
            if (parking == null)
                throw new Exception("Estacionamento inexistente");

            return await _Context.Cars.Where(o => o.ParkingId == parkingId).ToListAsync();
        }
    }
}
