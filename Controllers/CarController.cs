using Microsoft.AspNetCore.Mvc;
using ParkingCar3.Models;
using ParkingCar3.Repositrorys;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ParkingCar3.Controllers
{
    [Route("api/car")]
    [ApiController]


    public class CarController:ControllerBase
    {
        private readonly ICarRepository _CarRepository;

        public CarController(ICarRepository carRepository)
        {
            _CarRepository=carRepository;
        }

        [HttpGet("list/{parkingId}")]
        public async Task<ActionResult<IEnumerable<Car>>> List(int parkingId)
        {
            try
            {
                return Ok(await _CarRepository.List(parkingId));
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Car>> Get(int id)
        {
            var car = await _CarRepository.Get(id);
            if (car == null)
                return BadRequest("Erro");
            return Ok(car);
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<Car>> Delete(int id)
        {
            var toDelete = _CarRepository.Get(id);
            if (toDelete == null)
                return NotFound();
             await _CarRepository.Delete(toDelete.Id);
            return Ok(toDelete);
        }


        [HttpPost]
        public async Task<ActionResult<Car>> Create([FromBody]Car car)
        {
            try
            {
                var newCar = await _CarRepository.Create(car);
                return CreatedAtAction(nameof(Get), new { id = newCar.Id }, newCar);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }



        }
    }
}

