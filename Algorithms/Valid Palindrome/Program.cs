using System;

namespace Algorithms
{
    internal class Program
    {
        public static bool IsPalindrome(string s)
        {
            s = s.ToLower();

            int st = 0;
            int end = s.Length - 1;

            while (st < end)
            {
                if (s[st] != s[end])
                {
                    if (!char.IsLetterOrDigit(s[st]))
                    {
                        st++;
                        continue;
                    }
                    if (!char.IsLetterOrDigit(s[end]))
                    {
                        end--;
                        continue;
                    }
                    return false;
                }
                st++;
                end--;
            }
            return true;
        }

        private static void Main()
        {
            string[] testData = new string[]
            {
                "a.",
                "0P",
                "race a car",
                "0:u`bVbu`:0",
                "`l;`` 1o1 ??;l`",
            };

            foreach (string str in testData)
            {
                Console.WriteLine($"Input: |{str + "|",-20} Output: {IsPalindrome(str)}");
            }
        }
    }
}