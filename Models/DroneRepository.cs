

using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using DroneService.Util;


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
            Drone cartDrone = drone.ToCartesian();
            Util.Vector difference = Util.Vector.Subtract(cartDrone.EndPoint, cartDrone.StartPoint);
            if (Util.Vector.Norm(difference) < Constants.Constants.LandThreshold) {
                cartDrone.CurrentStatus = Status.Land;
            }
            Util.Vector velocity = Util.Vector.ConstMultiply(Util.Vector.Normalize(difference), 
                                                             Constants.Constants.MaxSpeed);
            _drones.AddOrUpdate(cartDrone.Uid, drone, (key, oldvalue) => cartDrone);


        }

        public Drone Get(string id) {
            Drone drone;
            _drones.TryGetValue(id, out drone);
            Drone llaDrone = drone.ToLLA();
            return llaDrone;
        }

    
    }
}