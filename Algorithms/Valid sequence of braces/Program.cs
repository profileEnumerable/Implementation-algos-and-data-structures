using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Algorithms
{
    internal class Program
    {
        #region Test funcs on time

        public static void ShowTestsFunc(Func<string, bool> func)
        {
            var stopwatch = new Stopwatch();

            var testData = new List<string>
            {
                "(){}<>[]"
                ,"[(())<<{}>>]"
                ,""
                ,null
            };

            foreach (string data in testData)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine($"Test data: {data}");
                Console.ResetColor();

                stopwatch.Restart();
                Console.Write($"{func.Method.Name,-25} | Output: {func(data),-10} ");
                stopwatch.Stop();
                Console.WriteLine("|ElapseTicks: " + stopwatch.ElapsedTicks);

                Console.WriteLine(new string('-', 65));
            }
        }
        #endregion

        public static bool IsValidSequence(string braces)
        {
            if (string.IsNullOrEmpty(braces))
            {
                return false;
            }

            var stackBraces = new Stack<char>();

            for (int i = 0; i < braces.Length; i++)
            {
                if (stackBraces.Count != 0)
                {
                    int difference = stackBraces.Peek() - braces[i];

                    if (difference == -1 || difference == -2)
                    {
                        stackBraces.Pop();
                        continue;
                    }
                }
                stackBraces.Push(braces[i]);
            }

            return stackBraces.Count == 0;
        }

        private static void Main()
        {
            ShowTestsFunc(IsValidSequence);
        }
    }
}