using Microsoft.AspNetCore.Mvc;
using ParkingCar3.Models;
using ParkingCar3.Repositrorys;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ParkingCar3.Controllers
{
    [Route("api/parking")]
    [ApiController]


    public class ParkingController:ControllerBase
    {
        private readonly IParkingRepository _ParkingRepository;

        public ParkingController(IParkingRepository parkingRepository)
        {
            _ParkingRepository=parkingRepository;
        }

        [HttpGet("list")]
        public async Task<IEnumerable<Parking>> List()
        {
            return await _ParkingRepository.List();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Parking>> Get(int id)
        {
            return await _ParkingRepository.Get(id);
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<Parking>> Delete(int id)
        {
            var toDelete = _ParkingRepository.Get(id);
            if (toDelete == null)
                return BadRequest("erro");
            await _ParkingRepository.Delete(toDelete.Id);
            return Ok(toDelete);

        }


        [HttpPost]
        public async Task<ActionResult<Parking>> Create([FromBody]Parking parking)
        {
            var newParking = await _ParkingRepository.Create(parking);
            return CreatedAtAction(nameof(Get), new { id = newParking.Id}, newParking);
        }
    }
}
