using System;
using System.Reflection;

public sealed class Test
{
    public static string LongestCommonPrefix(string[] strs)
    {
        int currCharPosition = 0;
        string prefix = string.Empty;
        string prevPrefix = string.Empty;

        while (true)
        {
            if (strs.Length != 0 && currCharPosition < strs[0].Length)
            {
                prevPrefix = prefix;
                prefix += strs[0][currCharPosition];
            }
            else
            {
                return prefix;
            }

            for (int i = 1; i < strs.Length; i++)
            {
                if (currCharPosition < strs[i].Length && strs[i][currCharPosition] != prefix[currCharPosition])
                {
                    return prevPrefix;
                }
            }

            currCharPosition++;
        }
    }

    private static void Main()
    {
        Console.WriteLine(LongestCommonPrefix(new string[] {"aa", "a"}));
    }
}