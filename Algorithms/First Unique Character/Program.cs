using System;

namespace Algorithms
{
    internal class Program
    {
        public static int FirstUniqChar(string s)
        {
            int j;
            for (int i = 0; i < s.Length; i++)
            {
                for (j = 0; j < s.Length; j++)
                {
                    if (s[i] == s[j] && i != j)
                        break;
                }

                if (j == s.Length)
                    return i;
            }
            return -1;
        }

        private static void Main()
        {
            string[] testArr = new string[]
            {
                "substitute",
                "scaffolding",
                "eliminate",
                "absentabsent"
            };

            foreach (var str in testArr)
            {
                Console.WriteLine($"Input str: {str,-15} | Output: {FirstUniqChar(str)}");
            }
        }
    }
}