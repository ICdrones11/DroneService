using System;
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

        public static Vector ToCartesian(Vector lla) {
           
            double lonRad = lla.X * Math.PI / 180;
            double latRad = lla.Y * Math.PI / 180;
            double h = Constants.Constants.EarthRadius + lla.Z;
            double x = h * Math.Sin(latRad) * Math.Cos(lonRad);
            double y = h * Math.Sin(latRad) * Math.Sin(lonRad);
            double z = h * Math.Cos(latRad);
            return new Vector(x, y, z);
        }

        public static Vector ToLLA(Vector v) {
            double r = Norm(v);
            double numerator = Math.Sqrt(Math.Pow(v.X, 2) + Math.Pow(v.Y, 2));
            double lat = Math.Atan2(numerator, v.Z) * (180 / Math.PI);
            double lon = Math.Atan2(v.Y, v.X) * (180 / Math.PI);
            double alt = r - Constants.Constants.EarthRadius;
            return new Vector(lat, lon, alt);

        }
        public static Vector Add(Vector a, Vector b) {
            return new Vector(a.X + b.X, a.Y + b.Y, a.Z + b.Z);
        }

        public static Vector Subtract(Vector a, Vector b) {
            return new Vector(a.X - b.X, a.Y - b.Y, a.Z - b.Z);
        }

        public static double Norm(Vector v) {
            return System.Math.Sqrt(Math.Pow(v.X, 2) + Math.Pow(v.Y, 2) + Math.Pow(v.Z, 2));
        }

        public static Vector ConstMultiply(Vector v, double c) {
            return new Vector(v.X * c, v.Y * c, v.Z * c);
            
        }

        public static Vector Normalize(Vector v) {
            return ConstMultiply(v, (1.0 / Norm(v)));
        }
    }
}