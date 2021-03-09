using System;
using System.Collections.Generic;
using System.Text;

namespace Fei
{
    public class ExtraMath
    {
        public static bool QuadraticEquation(double a, double b, double c, out double? x1, out double? x2)
        {
            double disk = b * b - 4 * a * c;
            if (disk == 0)
            {
                x1 = (-b) / (2 * a);
                x2 = x1;
                return true;
            }
            else if (disk > 0)
            {
                x1 = (-b + Math.Sqrt(disk)) / (2 * a);
                x2 = (-b - Math.Sqrt(disk)) / (2 * a);
                return false;
            }
            x1 = null;
            x2 = null;
            return false;
        }
        public static double genedateRandom(Random random, int min, int max)
        {
            return random.NextDouble() * (max - min) + min;
        }
    }
}
