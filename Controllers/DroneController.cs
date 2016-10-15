using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DroneService.Models;

namespace DroneService.Controllers
{
    [Route("api/[controller]")]
    public class DroneController : Controller
    {


        public DroneController(IDroneRepository dronesRepo) {
            DronesRepo = dronesRepo;
        }

        public IDroneRepository DronesRepo {get; set;} 

        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<Drone> drones = DronesRepo.GetAll();
            return Json(drones);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            Drone drone = DronesRepo.Find(id);
            if(drone != null) {
                return Json(drone);
            } else {
                return NotFound();
            }
        }

        // POST api/
        [HttpPost]
        public IActionResult Post([FromBody]Drone drone)
        {
            if (drone.checkRegister()) {
                System.Console.WriteLine("Drone added.");
                DronesRepo.Add(drone);
                return Ok();
            } else
            {
                return BadRequest("Not all required field specified.");
            }
            

            
            
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(string id, [FromBody]Drone droneData)
        {
            droneData.checkUpdate();
            
            Drone drone = DronesRepo.Find(id);
            if (drone == null) {
                return NotFound();
            }
            System.Console.WriteLine(drone);
            drone.Update(droneData);
            return Ok();

        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        private bool checkRegister() {
            return true;
        }
    }
}
