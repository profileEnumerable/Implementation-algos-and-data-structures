using System;
using System.Collections.Generic;
using System.Diagnostics;


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
                {"hello","ll"},
                {"aaaaa","bba" }
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

        public static int StrStr(string haystack, string needle)
        {
            if (needle.Length == 0)
            {
                return 0;
            }

            int neeIndex = 0;
            int heyIndex = 0;

            for (int i = 0; heyIndex < haystack.Length;)
            {
                if (haystack[heyIndex++] == needle[neeIndex++])
                {                    
                    if (neeIndex == needle.Length)
                    {
                        return i;
                    }
                }
                else
                {
                    neeIndex = 0;
                    heyIndex = ++i;               
                }
            }

            return -1;
        }

        public static int StrStrUseSubstr(string haystack, string needle)
        {
            int lenOfneedle = needle.Length;

            if (haystack.Length < lenOfneedle || lenOfneedle == 0)
            {
                return lenOfneedle == 0 ? 0 : -1;
            }

            for (int i = 0; i < haystack.Length; i++)
            {
                if (haystack[i] == needle[0] && (i + lenOfneedle) <= haystack.Length)
                {
                    if (haystack.Substring(i, lenOfneedle) == needle)
                    {
                        return i;
                    }
                }
            }
            return -1;
        }
        private static void Main()
        {
            ShowTestsFunc(StrStr, StrStrUseSubstr);
        }
    }
}