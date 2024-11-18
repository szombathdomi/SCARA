using System;

class Program
{
    static double DegreesToRadians(double degrees)
    {
        return degrees * (Math.PI / 180);
    }
    static void Direkt_Kinematika(double turn1, double turn2, int l1, int l2, int di)
    {
        double a = l1 * Math.Cos(DegreesToRadians(turn1));
        double b = l1 * Math.Sin(DegreesToRadians(turn1));
        double c = di + (l1 * Math.Cos(DegreesToRadians(turn2)));
        double d = l1 * Math.Sin(DegreesToRadians(turn2));

        //Console.WriteLine("c: {0}", c);
        //Console.WriteLine("d: {0}", d);

        double k1 = c - a;
        double k2 = d - b;
        double k3 = c + a;
        double k4 = d + b;

        double j1 = Math.Pow(c, 2) + Math.Pow(d, 2);
        double j2 = Math.Pow(a, 2) + Math.Pow(b, 2);

        double db = Math.Sqrt(Math.Pow(k1, 2) + Math.Pow(k2, 2));

        double phi = Math.Acos(db / (2 * l2));
        double phi1 = Math.Acos((Math.Pow(db, 2) + Math.Pow(l1, 2) - j1) / (2 * db * l1));

        double s = Math.Pow(l1, 2) - 2 * l1 * l2 * Math.Cos(phi + phi1) + ((j1 + j2) / 2);

        double y = (2 * k1 * s - (k3 * (j1 - j2))) / (2 * (k1 * k4 - k2 * k3));
        double x = (j1 - j2 - 2 * k2 * y) / (2 * k1);

        Console.WriteLine("\tx: {0}", x);
        Console.WriteLine("\ty: {0}", y);
    }
    static void Inverz_Kinematika(double coordx, double coordy, int l1, int l2, int di)
    {
        double c = Math.Sqrt(Math.Pow(coordx, 2) + Math.Pow(coordy, 2));
        double e = Math.Sqrt(Math.Pow(di - coordx, 2) + Math.Pow(coordy, 2));

        double t1 = Math.Atan(coordy / coordx) + Math.Acos((Math.Pow(l1, 2) + Math.Pow(c, 2) - Math.Pow(l2, 2)) / (2 * l1 * c));
        double t2 = Math.Atan(coordy / (di - coordx)) + Math.Acos((Math.Pow(l1, 2) + Math.Pow(e, 2) - Math.Pow(l2, 2)) / (2 * l1 * e));
        Console.WriteLine("\t" + t1 * (180 / Math.PI)+ "°");
        Console.WriteLine("\t" + (180 - (t2 * (180 / Math.PI)))+ "°");
    }
    static void Main()
    {
        Console.WriteLine("Végszerszám koordinátái:");
        Direkt_Kinematika(120, 60, 10, 13, 10);

        Console.WriteLine("Motor elfordulási szögek:");

        Inverz_Kinematika(5.000000000000002, 16.966877900762466,10,13,10);
        Console.ReadKey();
    }
}