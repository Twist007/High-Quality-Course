using System;

namespace Methods
{
    class Methods
    {
        static double CalcTriangleArea(double sideA, double sideB, double sideC)
        {
            if (sideA <= 0 || sideB <= 0 || sideC <= 0)
            {
                throw new ArgumentOutOfRangeException("Sides should be positive.");
            }

            double semiPerimeter = (sideA + sideB + sideC) / 2;
            double triangleArea = Math.Sqrt(semiPerimeter 
                * (semiPerimeter - sideA) 
                * (semiPerimeter - sideB) 
                * (semiPerimeter - sideC));

            return triangleArea;
        }

        static string ConvertNumberToWord(int number)
        {
            switch (number)
            {
                case 0: return "zero";
                case 1: return "one";
                case 2: return "two";
                case 3: return "three";
                case 4: return "four";
                case 5: return "five";
                case 6: return "six";
                case 7: return "seven";
                case 8: return "eight";
                case 9: return "nine";
            }

            return "Invalid number!";
        }

        static int FindMaxNumber(params int[] elements)
        {
            if (elements == null || elements.Length == 0)
            {
                throw new ArgumentException("Input cannot be empty.");
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

        static void PrintNumberInFormat(object number, string format)
        {
            if (format == "f")
            {
                Console.WriteLine("{0:f2}", number);
            }
            if (format == "%")
            {
                Console.WriteLine("{0:p0}", number);
            }
            if (format == "r")
            {
                Console.WriteLine("{0,8}", number);
            }
        }


        static double CalcDistance(double x1, double y1, double x2, double y2, 
            out bool isHorizontal, out bool isVertical)
        {
            isHorizontal = (y1 == y2);
            isVertical = (x1 == x2);

            double distance = Math.Sqrt((x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1));
            return distance;
        }

        static void Main()
        {
            Console.WriteLine(CalcTriangleArea(3, 4, 5));
            
            Console.WriteLine(ConvertNumberToWord(5));
            
            Console.WriteLine(FindMaxNumber(5, -1, 3, 2, 14, 2, 3));
            
            PrintNumberInFormat(1.3, "f");
            PrintNumberInFormat(0.75, "%");
            PrintNumberInFormat(2.30, "r");

            bool horizontal, vertical;
            Console.WriteLine(CalcDistance(3, -1, 3, 2.5, out horizontal, out vertical));
            Console.WriteLine("Horizontal? " + horizontal);
            Console.WriteLine("Vertical? " + vertical);

            Student peter = new Student
            {
                FirstName = "Peter",
                LastName = "Ivanov",
                OtherInfo = "From Sofia, born at 17.03.1992"
            };

            Student stella = new Student
            {
                FirstName = "Stella",
                LastName = "Markova",
                OtherInfo = "From Vidin, gamer, high results, born at 03.11.1993"
            };

            Console.WriteLine("{0} older than {1} -> {2}",
                peter.FirstName, stella.FirstName, peter.IsOlderThan(stella));
        }
    }
}
