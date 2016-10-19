using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DroneService.Models;

namespace DroneService.Controllers
{
    [Route("api/[controller]")]
    public class TestController : Controller
    {


        public TestController(IDroneRepository dronesRepo) {
            DronesRepo = dronesRepo;
        }

        public IDroneRepository DronesRepo {get; set;} 

        
        [HttpGet]
        public IActionResult tick()
        {
      
                // Does nothing yet
                // DronesRepo.Tick();
                return Ok();
        }
    }
}
