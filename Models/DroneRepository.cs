

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

        public Drone Find(string uid)
        {
            Drone drone;
            _drones.TryGetValue(uid, out drone);
            return drone;
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

        }

        public void Reset() {
            _drones = new ConcurrentDictionary<string, Drone>();
        }
    }
}