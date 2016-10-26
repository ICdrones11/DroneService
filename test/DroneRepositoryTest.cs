using Xunit;
using DroneService.Models;
using DroneService.Util;

namespace DroneTests
{
    public class DroneRepositoryTest
    {
        [Fact]
        public void PutNewSavesDrone()
        {
        	Drone drone = Util.TestDrone();
        	DroneRepository repo = new DroneRepository();
        	repo.Put(drone);
        	Assert.Equal(1, repo.Length());
        }

        [Fact]
        public void PutOldUpdatesDrone()
        {
        	Drone drone1 = Util.TestDrone();
        	Drone drone2 = Util.TestDrone();
        	drone2.CurrentStatus = Status.Move;
        	DroneRepository repo = new DroneRepository();
        	repo.Put(drone1);
			repo.Put(drone2);
        	Assert.Equal(1, repo.Length());
        	// Check if the drone actually got updated.
        	Assert.Equal(repo.Get(drone2.Uid).CurrentStatus, drone2.CurrentStatus);
        }

        [Fact]
        public void GetReturnsDrone()
        {
        	Drone drone = Util.TestDrone();
        	DroneRepository repo = new DroneRepository();
        	repo.Put(drone);
        	Assert.Equal(drone.Uid, repo.Get(drone.Uid).Uid);
        }
    }


}