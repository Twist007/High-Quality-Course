using System;

namespace MultiplyingMatrixByAnotherMatrix
{
    class MultiplyingMatrix
    {
        static void Main()
        {
            double[,] firstMatrix = new double[,]
            {
                { 1, 3 },
                { 5, 7 }
            };
            double[,] secondMatrix = new double[,]
            {
                { 4, 2 },
                { 1, 5 }
            };

            double[,] multiplyMatrix = MultiplyingTwoMatrix(firstMatrix, secondMatrix);

            PrintMatrix(multiplyMatrix);

        }

        private static double[,] MultiplyingTwoMatrix(double[,] firstMatrix, double[,] secMatrix)
        {
            if (firstMatrix.GetLength(1) != secMatrix.GetLength(0))
            {
                throw new ArgumentOutOfRangeException(nameof(firstMatrix), "The number of columns on first matrix must be equal to number of rows on second matrix.");
            }

            int firstMatrixColLenght = firstMatrix.GetLength(1);
            double[,] resultMatrix = new double[firstMatrix.GetLength(0), secMatrix.GetLength(1)];
            for (int row = 0; row < resultMatrix.GetLength(0); row++)
            {
                for (int col = 0; col < resultMatrix.GetLength(1); col++)
                {
                    for (int mulNum = 0; mulNum < firstMatrixColLenght; mulNum++)
                    {
                        resultMatrix[row, col] += firstMatrix[row, mulNum] * secMatrix[mulNum, col];
                    }
                }
            }
            return resultMatrix;
        }

        private static void PrintMatrix(double[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}