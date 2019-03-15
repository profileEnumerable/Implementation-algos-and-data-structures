using System;

namespace Algorithms
{
    internal class Program
    {
        public static void ReverseString(char[] s)
        {
            for (int i = 0; i < s.Length / 2; i++)
            {
                s[i] = (char)(s[i] + s[s.Length - i - 1]);
                s[s.Length - i - 1] = (char)(s[i] - s[s.Length - i - 1]);
                s[i] = (char)(s[i] - s[s.Length - i - 1]);
            }
        }

        private static void Main()
        {
            char[] testString = new char[] { 'h', 'e', 'l', 'l', 'o' };

            Console.WriteLine($"Input: ['{ string.Join("' '", testString)}']");
            ReverseString(testString);
            Console.WriteLine($"Output: ['{ string.Join("' '", testString)}']");
            Console.ReadKey();
        }
    }
}