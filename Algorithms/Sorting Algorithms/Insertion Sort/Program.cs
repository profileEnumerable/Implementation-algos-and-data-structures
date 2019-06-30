using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Algorithms
{
    internal delegate void SortFunc(int[] items);

    internal class Program
    {
        #region Test funcs on time

        public static void ShowTestsFunc(SortFunc sortFuncs)
        {
            var stopwatch = new Stopwatch();

            var testData = new Dictionary<int[], string>()
            {
                { new[] { 31,10,1,2},"O(n^2)" },
                //{ new[] { 1, 2, 3, 4, 5, 6,  7 },"O(n)"   },
            };

            foreach (KeyValuePair<int[], string> data in testData)
            {
                Console.WriteLine($"Time complexity: {data.Value}");
                Console.WriteLine($"Before sorting : {string.Join(" ", data.Key)}");

                stopwatch.Restart();
                sortFuncs(data.Key);
                stopwatch.Stop();

                Console.Write($"{sortFuncs.Method.Name,-25} |After sorting: {string.Join(" ", data.Key),-10} ");
                Console.WriteLine("|ElapseTicks: " + stopwatch.ElapsedTicks);

                Console.WriteLine(new string('-', 65));
            }
        }
        #endregion

        public static int FindIndexForInsert(int[] array, int currIndex)
        {
            for (int i = currIndex - 1; i >= 0; i--)
            {
                if (array[currIndex] > array[i])
                {
                    return i + 1;
                }
            }
            return 0;
        }

        public static void InsertionSort(int[] array)
        {
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i - 1] > array[i])
                {
                    int tempIndex = i;
                    int temp = array[i];

                    while (tempIndex != 0 && temp < array[tempIndex - 1])
                    {
                        array[tempIndex] = array[tempIndex - 1];
                        tempIndex--;
                    }

                    array[tempIndex] = temp;
                }
            }
        }

        private static void Main()
        {
            ShowTestsFunc(InsertionSort);
        }
    }
}