
namespace MatricesMulitiplier
{
    using System;

    public class MatricesMulitiplierRowByColumn
    {
        static void Main()
        {
            var firstMatrix = new double[,] { { 1, 3 }, { 5, 7 } };
            var secondMatrix = new double[,] { { 4, 2 }, { 1, 5 } };

            var resultMatrix = Multiply(firstMatrix, secondMatrix);

            PrintMatrix(resultMatrix);

        }

        private static void PrintMatrix(double[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int column = 0; column < matrix.GetLength(1); column++)
                {
                    Console.Write(matrix[row, column] + " ");
                }
                Console.WriteLine();
            }
        }

        static double[,] Multiply(double[,] firstMatrix, double[,] secondMatrix)
        {
            if (firstMatrix.GetLength(1) != secondMatrix.GetLength(0))
            {
                throw new Exception("Rows and Columns of the matrices must be the same size!");
            }

            var firstMatrixColumns = firstMatrix.GetLength(1);
            var multipliedMatrix = new double[firstMatrix.GetLength(0), secondMatrix.GetLength(1)];

            for (int row = 0; row < multipliedMatrix.GetLength(0); row++)
            {
                for (int column = 0; column < multipliedMatrix.GetLength(1); column++)
                {
                    for (int firstMatrixColumn = 0; firstMatrixColumn < firstMatrixColumns; firstMatrixColumn++)
                    {
                        multipliedMatrix[row, column] += firstMatrix[row, firstMatrixColumn] * secondMatrix[firstMatrixColumn, column];
                    }
                }
            }
            return multipliedMatrix;
        }
    }
}