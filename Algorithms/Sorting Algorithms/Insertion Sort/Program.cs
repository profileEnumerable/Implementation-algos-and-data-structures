using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Algorithms
{
    internal delegate void SortFunc(int[] items);

    internal class Program
    {
        #region Test funcs on time

        public static void ShowTestsFunc(params SortFunc[] sortFuncs)
        {
            var stopwatch = new Stopwatch();

            var testData = new Dictionary<int[], string>()
            {
                { new[] { 1, 3, 2, 0, -1, 10, 4, 456 },"O(n^2)" },
                { new[] { 1, 2, 3, 4,  5,  6, 7,   8},"O(n)" },
            };

            foreach (KeyValuePair<int[], string> data in testData)
            {
                Console.WriteLine($"Time complexity: {data.Value}");
                Console.WriteLine($"Before sorting : {string.Join(" ", data.Key)}");

                foreach (SortFunc sortFunc in sortFuncs)
                {
                    int[] cloneArr = data.Key.Clone() as int[];

                    stopwatch.Restart();
                    sortFunc(cloneArr);
                    stopwatch.Stop();
                    Console.Write($"{sortFunc.Method.Name,-25} |After sorting: {string.Join(" ", cloneArr),-10} ");
                    Console.WriteLine("|ElapseTicks: " + stopwatch.ElapsedTicks);
                }

                Console.WriteLine(new string('-', 65));
            }
        }
        #endregion

        //---------Own implementation of the sorting algorithm-------//
        public static void InsertionSortOwnImplem(int[] array)
        {
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i - 1] > array[i])
                {
                    int insertionInd = i;//save current index
                    int insertionElem = array[i];//save insertion item

                    while (insertionInd != 0 && insertionElem < array[insertionInd - 1])
                    {
                        array[insertionInd] = array[insertionInd - 1];//offset the items
                        insertionInd--;
                    }

                    array[insertionInd] = insertionElem;
                }
            }
        }

        //---------Optimized algorithm from ITVDN examples----------//
        public static int FindIndexForInsert(int[] array, int insertionElem)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (insertionElem < array[i])
                {
                    return i;
                }
            }
            return -1;
        }

        public static void Insert(int[] array, int insertTo, int insertFrom)
        {
            int temp = array[insertTo];//save the future right side item
            array[insertTo] = array[insertFrom];

            for (int i = insertFrom; i > insertTo + 1; i--)
            {
                array[i] = array[i - 1];//offset the items
            }

            array[insertTo + 1] = temp;//restore the right side item
        }

        public static void InsertionSort(int[] array)
        {
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i - 1] > array[i])
                {
                    int insertTo = FindIndexForInsert(array, array[i]);
                    Insert(array, insertTo, i);
                }
            }
        }

        private static void Main()
        {
            ShowTestsFunc(InsertionSort, InsertionSortOwnImplem);
        }
    }
}