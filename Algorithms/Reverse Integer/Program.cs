using System;

namespace Test_Examples
{
    internal class Program
    {
        public static int Reverse(int x)
        {
            int result = 0;

            try
            {
                checked
                {
                    while (true)
                    {
                        result = (result + x % 10);

                        if ((x /= 10) == 0)
                            return result;

                        result *= 10;
                    }
                }
            }
            catch (Exception)
            {
                return 0;
            }
        }

        private static void Main()
        {
            int[] testArr = new[] { 123, -123, 120, -2147483412, 2147483647 };

            foreach (var num in testArr)
            {
                Console.WriteLine($"Input: {num,-15}|Output: {Reverse(num)}");
            }
        }
    }
}