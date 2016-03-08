using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Methods
{
    public class Calculations
    {
        public static double CalcTriangleArea(double a, double b, double c)
        {
            if (a <= 0 || b <= 0 || c <= 0)
            {
                throw new IndexOutOfRangeException("The side cannot be negative or null.");
            }
            double s = (a + b + c) / 2;
            double area = Math.Sqrt(s * (s - a) * (s - b) * (s - c));
            return area;
        }
     public   static int FindMaxElement(params int[] elements)
        {
            if (elements == null || elements.Length == 0)
            {
                throw new ArgumentException("The element cannot be null.");
            }

            for (int i = 1; i < elements.Length; i++)
            {
                if (elements[i] > elements[0])
                {
                    elements[0] = elements[i];
                }
            }
            return elements[0];
        }

        public static double CalcDistance(double x1, double y1, double x2, double y2)
        {

            double distance = Math.Sqrt((x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1));
            return distance;
        }
        public static bool isHorizontal(double y1, double y2)
        {
            return y1 == y2;
        }
        public static bool isVertical(double x1, double x2)
        {
            return x1 == x2;
        }
    }
}
