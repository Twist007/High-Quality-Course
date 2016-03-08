namespace _01.ManipulateTwoDimensionalArrays
{
    using System;
    
    public class ManipulateTwoDimensionalArraysProgram
    {
        public static void Main()
        {
            var firstMatrix = new double[,] { { 1, 3 }, { 5, 7 } };
            var secondMatrix = new double[,] { { 4, 2 }, { 1, 5 } };
            var manipulatedArray = ManipulateArrays(firstMatrix, secondMatrix);

            for (int row = 0; row < manipulatedArray.GetLength(0); row++)
            {
                for (int col = 0; col < manipulatedArray.GetLength(1); col++)
                {
                    Console.Write(manipulatedArray[row, col] + " ");
                }

                Console.WriteLine();
            }
        }

        public static double[,] ManipulateArrays(double[,] firstArray, double[,] secondArray)
        {
            if (firstArray.GetLength(1) != secondArray.GetLength(0))
            {
                throw new IncompatibleArraysException("First array's number of columns is different than second array's number of rows");
            }

            var firstArrayCols = firstArray.GetLength(1);
            var result = new double[firstArray.GetLength(0), secondArray.GetLength(1)];
            for (int row = 0; row < result.GetLength(0); row++)
            {
                for (int col = 0; col < result.GetLength(1); col++)
                {
                    for (int firstArrayCol = 0; firstArrayCol < firstArrayCols; firstArrayCol++)
                    {
                        result[row, col] += firstArray[row, firstArrayCol] * secondArray[firstArrayCol, col];
                    }
                }
            }

            return result;
        }
    }
}