using System;

namespace LabWork2
{
    class Program
    {
        static void Main(string[] args)
        {


            try
            {
                Console.WriteLine("1.1");
                double[] array1 = enterArray();
                Console.WriteLine("Avg : " + findAvg(array1));

                Console.WriteLine("1.2");
                double[] vector1 = enterArray();
                double[] vector2 = enterArray();
                Console.WriteLine("Sum : ");
                printArray(vectorSum(vector1, vector2));

                Console.WriteLine("1.3");
                double[] array3 = enterArray();
                Console.WriteLine("Array : ");
                printArray(array3);
                insertSort(array3);
                Console.WriteLine("Sorted : ");
                printArray(array3);

                Console.WriteLine("2.1");
                int[][] matrix1 = enterMatrix();
                printMatrix(matrix1);
                sortMatrix(matrix1);
                Console.WriteLine("Sorted :");
                printMatrix(matrix1);

                Console.WriteLine("2.2");
                int[][] matrix2 = enterMatrix();
                printMatrix(matrix2);
                Console.WriteLine(countNonZeroRows(matrix2));

                Console.WriteLine("2.3");
                int[][] matrix3 = enterMatrix();
                printMatrix(matrix3);
                Console.WriteLine(findMaxRepeatedNumber(matrix3));

            }
            catch (Exception exception)
            {
                Console.WriteLine("Error : " + exception.Message);
            }

        }

        static void printArray(double[] array)
        {
            foreach (double item in array)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine("");
        }

        static double[] enterArray()
        {
            Console.WriteLine("Enter N :");
            int n = Convert.ToInt32(Console.ReadLine());
            double[] result = new double[n];
            Console.WriteLine("Enter numbers :");
            for (int i = 0; i < n; i++)
            {
                result[i] = Convert.ToDouble(Console.ReadLine());
            }
            return result;
        }

        static int[][] enterMatrix()
        {
            Random random = new Random();

            Console.Write("Enter number of rows: ");
            int n = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter number of columns: ");
            int m = Convert.ToInt32(Console.ReadLine());

            int[][] result = new int[n][];
            for (int i = 0; i < n; i++)
            {
                result[i] = new int[m];
                for (int j = 0; j < m; j++)
                {
                    result[i][j] = random.Next(0, 10);
                }
            }

            return result;
        }
        static double findAvg(double[] array)
        {
            double sum = 0;

            for (int i = 0; i < array.Length; i++)
            {
                sum += array[i];
            }

            double average = sum / array.Length;
            return average;
        }

        static double[] vectorSum(double[] vector1, double[] vector2)
        {
            double[] result = new double[vector1.Length];

            for (int i = 0; i < vector1.Length; i++)
            {
                result[i] = vector1[i] + vector2[i];
            }

            return result;
        }

        static void insertSort(double[] arr)
        {
            int n = arr.Length;
            for (int i = 1; i < n; ++i)
            {
                double key = arr[i];
                int j = i - 1;

                while (j >= 0 && arr[j] > key)
                {
                    arr[j + 1] = arr[j];
                    j = j - 1;
                }
                arr[j + 1] = key;
            }
        }

        static void sortMatrix(int[][] matrix)
        {
            for (int i = 0; i < matrix.Length; i += 2)
            {
                Array.Sort(matrix[i]);
            }
        }

        static void printMatrix(int[][] matrix)
        {
            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    Console.Write(matrix[i][j] + "  ");
                }
                Console.WriteLine();
            }
        }

        static int countNonZeroRows(int[][] matrix)
        {
            int count = 0;

            for (int i = 0; i < matrix.Length; i++)
            {
                bool hasZero = false;

                for (int j = 0; j < matrix[i].Length; j++)
                {
                    if (matrix[i][j] == 0)
                    {
                        hasZero = true;
                        break;
                    }
                }

                if (!hasZero)
                {
                    count++;
                }
            }

            return count;
        }

        
        static int findMaxRepeatedNumber(int[][] matrix)
        {
            int maxRepeatedNumber = 0;

            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    int currentNumber = matrix[i][j];

                    for (int k = 0; k < matrix.Length; k++)
                    {
                        for (int l = 0; l < matrix[k].Length; l++)
                        {
                            if (matrix[k][l] == currentNumber && (i != k || j != l))
                            {
                                if (currentNumber > maxRepeatedNumber)
                                {
                                    maxRepeatedNumber = currentNumber;
                                }
                            }
                        }
                    }
                }
            }

            return maxRepeatedNumber;
        }

    }

}

