using System;
using System.Collections.Generic;
using System.Diagnostics;


namespace Algorithms
{
    internal delegate void StrStrFunc(int[] items);

    internal class Program
    {
        #region Test funcs on time

        public static void ShowTestsFunc(params StrStrFunc[] funcs)
        {
            var stopwatch = new Stopwatch();

            var testData = new Dictionary<int[], string>()
            {
                { new[] { 7, 1, 2, 0, 3, 9, -3 },"O(n^2)" },
                { new[] { 1, 2, 3, 4, 5, 6,  7 },"O(n)"   }
            };


            foreach (KeyValuePair<int[], string> data in testData)
            {
                Console.WriteLine($"Time complexity: {data.Value}");
                Console.WriteLine($"Before sorting : {string.Join(" ", data.Key)}");

                foreach (StrStrFunc func in funcs)
                {
                    int[] copyArr = new int[data.Key.Length];
                    data.Key.CopyTo(copyArr, 0);

                    stopwatch.Restart();
                    func(copyArr);
                    stopwatch.Stop();

                    Console.Write($"{func.Method.Name,-25} |After sorting: {string.Join(" ", copyArr),-10} ");
                    Console.WriteLine("|ElapseTicks: " + stopwatch.ElapsedTicks);
                }
                Console.WriteLine(new string('-', 65));
            }
        }
        #endregion

        public static void Swap(int[] items, int left, int right)
        {
            if (left != right)
            {
                int temp = items[left];
                items[left] = items[right];
                items[right] = temp;
            }
        }

        public static void BubbleSort(int[] items)
        {
            bool isSwapped;

            do
            {
                isSwapped = false;

                for (int i = 1; i < items.Length; i++)
                {
                    if (items[i - 1].CompareTo(items[i]) > 0)
                    {
                        Swap(items, i - 1, i);

                        isSwapped = true;
                    }
                }

            } while (isSwapped);
        }

        private static void Main()
        {
            ShowTestsFunc(BubbleSort, BubbleSort);
        }
    }
}