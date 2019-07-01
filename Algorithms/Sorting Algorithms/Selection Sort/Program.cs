using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Algorithms
{
    internal delegate void SortFunc(int[] items);

    internal class Program
    {
        #region Test funcs on time

        public static void ShowTestsFunc(SortFunc sortFunc)
        {
            var stopwatch = new Stopwatch();

            var testData = new Dictionary<int[], string>()
            {
                { new[] { 1, 3, 2, 0, -1, 10, 4, 456 },"O(n^2)"},
                { new[] { 1, 2, 3, 4,  5,  6, 7,   8},"O(n)" },
            };

            foreach (KeyValuePair<int[], string> data in testData)
            {
                Console.WriteLine($"Time complexity: {data.Value}");
                Console.WriteLine($"Before sorting : {string.Join(" ", data.Key)}");

                stopwatch.Restart();
                sortFunc(data.Key);
                stopwatch.Stop();
                Console.Write($"{sortFunc.Method.Name,-25} |After sorting: {string.Join(" ", data.Key),-10} ");
                Console.WriteLine("|ElapseTicks: " + stopwatch.ElapsedTicks);
            }

            Console.WriteLine(new string('-', 65));

        }
        #endregion

        public static void Swap(int[] array, int left, int right)
        {
            if (left != right)
            {
                int temp = array[left];
                array[left] = array[right];
                array[right] = temp;
            }
        }

        public static int GetIndexOfSmallestItem(int[] array, int startIndex)
        {
            int minItem = array[startIndex];
            int minIndex = startIndex;

            for (int i = minIndex + 1; i < array.Length; i++)
            {
                if (minItem > array[i])
                {
                    minItem = array[i];
                    minIndex = i;
                }
            }
            return minIndex;
        }

        public static void SelectionSort(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                int indexOfSmItem = GetIndexOfSmallestItem(array, i);
                Swap(array, i, indexOfSmItem);
            }
        }

        private static void Main()
        {
            ShowTestsFunc(SelectionSort);
        }
    }
}