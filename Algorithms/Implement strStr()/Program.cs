using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace Algorithms
{
    internal delegate int StrStrFunc(string haystack, string needle);

    internal class Program
    {
        public static void ShowTestsFunc(params StrStrFunc[] funcs)
        {
            var stopwatch = new Stopwatch();

            var testData = new Dictionary<string, string>()
            {
                {"bbaa","aab"}
            };

            foreach (KeyValuePair<string, string> data in testData)
            {
                Console.WriteLine($"Test data: {data}\n");

                foreach (StrStrFunc func in funcs)
                {
                    stopwatch.Restart();
                    Console.Write($"{func.Method.Name,-25} |Result: {func(data.Key, data.Value),-10} ");
                    stopwatch.Stop();
                    Console.WriteLine("|ElapseTicks: " + stopwatch.ElapsedTicks);
                }
                Console.WriteLine(new string('-', 65));
            }
        }

        public static int StrStr(string haystack, string needle)//TODO: make the correct exit condition
        {
            int haystLimit = needle.Length == 1 ? haystack.Length : haystack.Length - 1;

            if (needle.Length == 0)
            {
                return 0;
            }

            for (int i = 0; i < haystLimit; i++)
            {
                int j;
                for (j = 0; j < needle.Length && haystack[i] == needle[j]; j++)
                {
                    i++;
                }
                if (j == needle.Length)
                {
                    return i - needle.Length;
                }
            }

            return -1;
        }

        //public int StrStr(string haystack, string needle)//Slowly working method
        //{
        //    int lenOfneedle = needle.Length;

        //    if (haystack.Length < lenOfneedle || lenOfneedle == 0)
        //    {
        //        return lenOfneedle == 0 ? 0 : -1;
        //    }

        //    for (int i = 0; i < haystack.Length; i++)
        //    {
        //        if (haystack[i] == needle[0] && (i + lenOfneedle) <= haystack.Length)
        //        {
        //            if (haystack.Substring(i, lenOfneedle) == needle)
        //            {
        //                return i;
        //            }
        //        }
        //    }
        //    return -1;
        //}
        private static void Main()
        {
            ShowTestsFunc(StrStr);
        }
    }
}