using System;

namespace Methods
{
    class Methods
    {
        static void Main()
        {
            Console.WriteLine(Calculations.CalcTriangleArea(3, 4, 5));

            Console.WriteLine(Formating.ConvertNumbersIntoWords(5));

            Console.WriteLine(Calculations.FindMaxElement(5, -1, 3, 2, 14, 2, 3));

            Formating.PrintAsNumber(1.3, "f");
            Formating.PrintAsNumber(0.75, "%");
            Formating.PrintAsNumber(2.30, "r");

            Console.WriteLine(Calculations.CalcDistance(3, -1, 3, 2.5));
            Console.WriteLine("Horizontal? " + Calculations.isHorizontal(2,1.2));
            Console.WriteLine("Vertical? " + Calculations.isVertical(1,4.5));

            Student peter = new Student() { FirstName = "Peter", LastName = "Ivanov" };
            peter.OtherInfo = "From Sofia, born at 17.03.1992";

            Student stella = new Student() { FirstName = "Stella", LastName = "Markova" };
            stella.OtherInfo = "From Vidin, gamer, high results, born at 03.11.1993";

            Console.WriteLine("{0} older than {1} -> {2}",
                peter.FirstName, stella.FirstName, peter.IsOlderThan(stella));
        }
    }
}
