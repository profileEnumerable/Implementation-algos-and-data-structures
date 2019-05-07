using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Algorithms
{
    internal delegate bool AnagramFunc(string s, string t);

    internal class Program
    {
        public static void ShowTestsFunc(params AnagramFunc[] funcs)
        {
            var stopwatch = new Stopwatch();

            var testData = new Dictionary<string, string>()
            {
                { "anagram","nagaram" },
                { "rat","car" }
            };

            foreach (KeyValuePair<string, string> data in testData)
            {
                Console.WriteLine($"Test data: {data}\n");

                foreach (AnagramFunc func in funcs)
                {
                    stopwatch.Restart();
                    Console.Write($"{func.Method.Name,-25} |Result: {func(data.Key, data.Value),-10} ");
                    stopwatch.Stop();
                    Console.WriteLine("|ElapseTicks: " + stopwatch.ElapsedTicks);
                }
                Console.WriteLine(new string('-', 65));
            }
        }

        //-----------------Time limit exceeded-------------//
        public static bool IsAnagramDeletingElem(string s, string t)
        {
            int charIndex = 0;

            if (s.Length == t.Length)
            {
                int foundIndex;
                while (charIndex < s.Length && (foundIndex = t.IndexOf(s[charIndex])) != -1)
                {
                    t = t.Remove(foundIndex, 1);
                    charIndex++;
                }
                return t.Length == 0;
            }
            return false;
        }

        public static bool IsAnagramManualSort(string s, string t)
        {
            int foundIndex;
            char[] tArr = t.ToCharArray();

            if (s.Length != t.Length)
            {
                return false;
            }

            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] != tArr[i])
                {
                    if ((foundIndex = Array.IndexOf(tArr, s[i], i + 1)) == -1)
                    {
                        return false;
                    }

                    char temp = tArr[i];
                    tArr[i] = tArr[foundIndex];
                    tArr[foundIndex] = temp;
                }
            }
            return true;
        }

        public static bool IsAnagramBothStrSort(string s, string t)
        {
            char[] sArray = s.ToCharArray();
            char[] tArray = t.ToCharArray();

            Array.Sort(sArray);
            Array.Sort(tArray);

            return sArray.SequenceEqual(tArray);
        }

        private static void Main()
        {
            ShowTestsFunc(IsAnagramDeletingElem, IsAnagramManualSort, IsAnagramBothStrSort);
        }
    }
}