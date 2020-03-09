using System;
using System.Reflection;

public sealed class Test
{
    public static string LongestCommonPrefix(string[] strs)
    {
        int currCharPosition = 0;
        string prefix = string.Empty;


        while (true)
        {
            if (currCharPosition < strs[0].Length)
            {
                prefix += strs[0][currCharPosition];
            }

            for (int i = 1; i < strs.Length; i++)
            {
                if (currCharPosition < strs[i].Length && strs[i][currCharPosition] != prefix[currCharPosition])
                {
                    Console.WriteLine(prefix);
                }
            }

            currCharPosition++;
        }
    }

    private static void Main()
    {
        LongestCommonPrefix(new[] {"flower", "flow", "flight"});
    }
}