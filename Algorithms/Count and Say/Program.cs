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

            int[] testData = new int[] { 1, 2, 3, 4 };

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

        public static string CountAndSay(int n)
        {
            var term = new StringBuilder("1");

            if (n < 1 || n > 30)
            {
                return string.Empty;
            }

            int seriesLength;
            for (int i = 1; i < n; i++)
            {
                char comparable = term[0];
                var newTerm = new StringBuilder();
                seriesLength = -1;

                for (int j = 0; j <= term.Length; j++)
                {
                    seriesLength++;

                    if (j == term.Length || comparable != term[j])
                    {
                        newTerm.Append($"{seriesLength}{comparable}");
                        comparable = j == term.Length ? '#' : term[j];

                        seriesLength = 0;
                    }
                }
                term = newTerm;
            }
            return term.ToString();
        }

        private static void Main()
        {
            ShowTestsFunc(CountAndSay);
        }
    }
}