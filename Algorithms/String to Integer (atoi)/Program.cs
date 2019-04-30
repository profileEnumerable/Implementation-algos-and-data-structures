using System;

namespace Algorithms
{
    internal class Program
    {
        public static int MyAtoi(string str)
        {
            str = str.TrimStart();//remove all leading spaces

            int stIndex = str != "" && (str[0] == '-' || str[0] == '+') ? 1 : 0;

            while (stIndex < str.Length && char.IsDigit(str[stIndex]))//count the first digits
            {
                stIndex++;
            }

            string numberStr = str.Substring(0, stIndex);//extract potential number as string

            if (!int.TryParse(numberStr, out int res) && stIndex > 1)//check for overflow
            {
                return numberStr[0] == '-' ? int.MinValue : int.MaxValue;
            }

            return res;
        }

        private static void Main()
        {
            string[] testData = new[]
            {
              "42",
              "   -42",
              "4193 with words",
              "words and 987",              
              "-91283472332",
              "+91283472332"
            };

            foreach (string str in testData)
            {
                Console.WriteLine($"Input: \"{str + "\"",-20} | Output: {MyAtoi(str)}");
            }
        }
    }
}