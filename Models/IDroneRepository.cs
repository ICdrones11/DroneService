using System.Collections.Generic;

namespace DroneService.Models
{
    public interface IDroneRepository
    {
        void Add(Drone drone);
        IEnumerable<Drone> GetAll();
        Drone Find(string uid);
        Drone Remove(string uid);
        void Update(Drone drone);
        void Tick();
    }
}