
using DroneService.Util;
using DroneService.Constants;

namespace DroneService.Models
{
    public class Drone
    {
        public string Uid {get; set; }
        public Vector StartPoint {get; set;}
        public Vector EndPoint {get; set;}
        public Vector ActualVelocity {get; set; }
        public Vector Position {get; set; }
        public Vector DesiredVelocity {get; set; }
        public Status CurrentStatus {get; set; }

        public void Update(Drone droneData) {
            ActualVelocity = droneData.ActualVelocity;
            
            Position = droneData.Position;
            
            CurrentStatus = droneData.CurrentStatus;
            
            
            DesiredVelocity = new Util.Vector(0,0,0);
            DesiredVelocity.X = System.Math.Min(EndPoint.X - Position.X, Constants.Constants.MaxSpeed);

            DesiredVelocity.Y = System.Math.Min(EndPoint.Y - Position.Y, Constants.Constants.MaxSpeed);
            DesiredVelocity.Z = System.Math.Min(EndPoint.Z - Position.Z, Constants.Constants.MaxSpeed);

        }
        
        public void Tick() {
            System.Console.WriteLine("Tick");
            if (CurrentStatus == Status.Move) {
                move();
            }
        }

        

        private void move() {
            System.Console.WriteLine("Move");
            Position.add(ActualVelocity);
        }



        // Check data validity. 
        public bool checkRegister() {
            if (this.StartPoint == null) {
                System.Console.WriteLine("Startpoint not specified");
                return false;
            } 
            if (this.EndPoint == null) {
                System.Console.WriteLine("Endpoint not specified");
                return false;
            }
            if (this.Uid == null) {
                System.Console.WriteLine("Uid not specified");
                return false;
            } 
            return true;
        }

        public bool checkUpdate() {
            if (this.ActualVelocity == null) {
                System.Console.WriteLine("ActualVelocity not specified");
                return false;              

            }
            if (this.Position == null) {
                System.Console.WriteLine("Position not specified");
                return false;           
            }
            return true;
        }       

    }




}