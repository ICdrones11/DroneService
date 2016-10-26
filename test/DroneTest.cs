using Xunit;
using DroneService.Models;

namespace DroneTests
{
    public class DroneTest
    {


        [Fact]
        public void CheckCorrectReturnsTrue()
        {
        	Drone drone = Util.TestDrone();

        	Assert.True(drone.checkData());
        }

        [Fact]
        public void CheckInCorrectReturnsFalse()
        {
        	Drone drone = new Drone();

        	Assert.False(drone.checkData());
        }
    }
}