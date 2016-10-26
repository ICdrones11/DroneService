

using System;
using System.Collections.Generic;
using System.Collections.Concurrent;

namespace DroneService.Models
{
    public class DroneRepository : IDroneRepository
    {
        private static ConcurrentDictionary<string, Drone> _drones =
              new ConcurrentDictionary<string, Drone>();

        public IEnumerable<Drone> GetAll()
        {
            return _drones.Values;
        }

        public void Add(Drone drone)
        {
            _drones[drone.Uid] = drone;
        }



        public Drone Remove(string uid)
        {
            Drone drone;
            _drones.TryRemove(uid, out drone);
            return drone;
        }

        public void Update(Drone drone)
        {
            _drones[drone.Uid] = drone;
        }

        public void Tick() {
            System.Console.WriteLine("Repo tick");
            foreach (Drone drone in _drones.Values) {
                drone.Tick();
            }

            // Collision detection
        }

        public int Length() {
            return _drones.Count;
        }



        public void Reset() {
            _drones = new ConcurrentDictionary<string, Drone>();
        }


        // API methods
        public void Put(Drone drone) {
            drone.checkData();
            
            _drones.AddOrUpdate(drone.Uid, drone, (key, oldvalue) => drone);

        }

        public Drone Get(string id) {
            Drone drone;
            _drones.TryGetValue(id, out drone);
            return drone;
        }

    
    }
}