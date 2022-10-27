using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ParkingCar3.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ParkingCar3.Repositrorys
{
    public class ParkingRepository : IParkingRepository
    {
        public readonly ParkingCarContext _Context;

        public ParkingRepository(ParkingCarContext context)
        {
            _Context=context;
        }

        public async Task<Parking> Create(Parking parking)
        {
            _Context.Parkings.Add(parking);
            await _Context.SaveChangesAsync();
            return parking;
        }

        public async Task Delete(int id)
        {
            var toDelete = await _Context.Parkings.FindAsync(id);
            _Context.Parkings.Remove(toDelete);
            await _Context.SaveChangesAsync();

        }

        public async Task<Parking> Get(int id)
        {
            return await _Context.Parkings.FindAsync(id);
        }

        public async Task<IEnumerable<Parking>> List()
        {
            return await _Context.Parkings.ToListAsync();   

        }

        
    }
}