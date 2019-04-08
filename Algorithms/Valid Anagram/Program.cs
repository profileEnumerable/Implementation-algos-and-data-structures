using System;

namespace Algorithms
{
    internal class Program
    {
        //-----------------Time limit exceeded-------------//
        //public static bool IsAnagram(string s, string t)
        //{
        //    int charIndex = 0, foundIndex = 0;

        //    if (s.Length == t.Length)
        //    {
        //        while (charIndex < s.Length && (foundIndex = t.IndexOf(s[charIndex])) != -1)
        //        {
        //            t = t.Remove(foundIndex, 1);                    
        //            charIndex++;
        //        }
        //        return t.Length == 0;
        //    }
        //    return false;
        //}

        public static bool IsAnagram(string s, string t)
        {
            int foundIndex = 0;

            if (s.Length == t.Length)
            {
                for (int i = 0; i < s.Length; i++)
                {
                    if (s[i] != t[i] && (foundIndex = t.IndexOf(s[i], i + 1)) == -1)//optimaze find with start index 
                        break;

                    else if (s[i] != t[i])
                    {
                        //TODO:Swap the symbols                        
                    }
                }
            }
            return false;
        }

        private static void Main()
        {
            Console.WriteLine(IsAnagram("anagram", "nagaram"));
        }
    }
}