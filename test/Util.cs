using DroneService.Models;
using DroneService.Util;
namespace DroneTests
{
    class Util {
        public static Drone TestDrone() {
    		Drone drone = new Drone();
        	drone.StartPoint = new Vector(1,2,3);
        	drone.EndPoint =  new Vector(1,2,3);
        	drone.Position = new Vector(1,2,3);
        	drone.Velocity = new Vector(1,2,3);
        	drone.CurrentStatus = Status.Hover;
        	drone.Uid = "1";
        	return drone;
    	}
    }
}