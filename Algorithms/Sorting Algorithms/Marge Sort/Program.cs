using System;
using System.Diagnostics;
 using System.Text;

namespace Algorithms
{
    internal class Program
    {
        #region Test funcs on time

        public static void ShowTestsFunc(Func<int, string> func)
        {
            var stopwatch = new Stopwatch();

            int[] testData = { 1, 2, 3, 4 };

            foreach (int data in testData)
            {
                stopwatch.Restart();
                Console.Write($"{func.Method.Name,-25} | Output: {func(data),-10} ");
                stopwatch.Stop();
                Console.WriteLine("|ElapseTicks: " + stopwatch.ElapsedTicks);

                Console.WriteLine(new string('-', 65));
            }
        }
        #endregion

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

        }

        private static void Main()
        {
            int[] array = { 7, 4, 3, 9, 1, 0 };

            MergeSort(array);

        }
    }
}