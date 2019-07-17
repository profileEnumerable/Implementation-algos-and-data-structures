using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Algorithms
{
    internal class Program
    {
        #region Test funcs on time

        public static void ShowTestsFunc(Action<int[]> sortFunc)
        {
            var stopwatch = new Stopwatch();

            var testData = new Dictionary<int[], string>()
            {
                { new[] { 1, 3, 2, 0, -1, 10, 4, 456 },"O(n log n)"},
                { new[] { 1, 2, 3, 4,  5,  6, 7,   8},"O(n log n)" },
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

        public static void Merge(int[] array, int[] left, int[] right)
        {
            int leftIndex = 0;
            int rightIndex = 0;
            int currentIndex = 0;

            int remaining = left.Length + right.Length;//total length

            while (remaining > 0)
            {
                if (leftIndex >= left.Length)
                {
                    array[currentIndex] = right[rightIndex++];
                }
                else if (rightIndex >= right.Length)
                {
                    array[currentIndex] = left[leftIndex++];
                }
                else if (left[leftIndex] < right[rightIndex])
                {
                    array[currentIndex] = left[leftIndex++];
                }
                else
                {
                    array[currentIndex] = right[rightIndex++];
                }

                currentIndex++;
                remaining--;
            }
        }

        public static void MergeSort(int[] array)
        {
            if (array.Length <= 1)
            {
                return;
            }

            int leftSize = array.Length / 2;//calculate size of left arr
            int rightSize = array.Length - leftSize;//calculate size of right arr

            int[] left = new int[leftSize];
            int[] right = new int[rightSize];

            Array.Copy(array, 0, left, 0, leftSize);
            //copy first part of arr to left

            Array.Copy(array, leftSize, right, 0, rightSize);
            //copy second part of arr to right

            MergeSort(left);
            MergeSort(right);

            Merge(array, left, right);
        }

        private static void Main()
        {
            ShowTestsFunc(MergeSort);
        }
    }
}