namespace DroneService.Util
{
    public enum Status
    {
        Hover, 
        Move,
        Land,
        Lost,
        Dead
    }

    public class Vector {
        public double X {get; set; }
        public double Y {get; set; }
        public double Z {get; set; }
        public Vector(double x, double y, double z) {
            X = x;
            Y = y;
            Z = z;
        }
        public void add(Vector other) {
            X = X + other.X;
            Y = Y + other.Y;
            Z = Z + other.Z;
        }
    }
}