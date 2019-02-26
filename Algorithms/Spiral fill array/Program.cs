using System;

namespace Test_Examples
{
    internal class Program
    {
        public static void SpiralFillArray(int[,] array)
        {
            var counter = 1;
            int i = 0, j = 0;
            var leftLimit = 0;
            var rightLimit = array.GetLength(0) - 1;
            var isDecrementIter = false;

            while (leftLimit < rightLimit)
            {
                while ((i != j || !isDecrementIter) && counter <= array.GetLength(0) * array.GetLength(1))
                {
                    array[i, j] = counter;

                    if ((i == rightLimit && j == rightLimit))
                    {
                        isDecrementIter = true;
                        j--;
                        counter++;
                        continue;
                    }

                    if (j == rightLimit || (isDecrementIter && j == leftLimit))
                        i = !isDecrementIter ? i + 1 : i - 1;
                    else
                        j = !isDecrementIter ? j + 1 : j - 1;

                    counter++;
                }
                isDecrementIter = false;
                rightLimit--;
                leftLimit++;
                i = j = leftLimit;
            }
        }

        private static void Main()
        {
            EnterMatrixOrder:
            Console.Write("Enter the matrix order: ");
            var order = Console.ReadLine();

            if (!int.TryParse(order, out int result))
                goto EnterMatrixOrder;

            var arr = new int[result, result];

            SpiralFillArray(arr);

            for (var k = 0; k < arr.GetLength(0); k++)
            {
                for (var l = 0; l < arr.GetLength(1); l++)
                {
                    Console.Write($"{arr[k, l],4}");
                }
                Console.WriteLine();
            }
        }
    }
}