using Microsoft.AspNetCore.Mvc;
using ParkingCar3.Models;
using ParkingCar3.Repositrorys;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ParkingCar3.Controllers
{
    [Route("api/test")]
    [ApiController]
    public class TestController : ControllerBase
    {
        public TestController()
        {
        }

        [HttpGet()]
        public async Task<ActionResult> Get()
        {
            return Ok("testado");
        }  
    }
}
