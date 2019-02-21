using System;
using System.Collections.Generic;

namespace Algorithms_and_data_structures
{
    internal class Program
    {
        private static void Main()
        {
            var linkedList = new LinkedList<int>();

            #region Method: Add

            Console.WriteLine("Method Add: ");

            for (var i = 1; i <= 5; i++)
            {
                linkedList.Add(i);
            }

            Console.WriteLine(string.Join(" ", linkedList));

            #endregion

            #region Method: Remove

            Console.WriteLine("\nMethod Remove: ");
            Console.Write("Enter value for delete: ");

            if (int.TryParse(Console.ReadLine(), out int value))
            {
                linkedList.Remove(value);
            }

            Console.WriteLine(string.Join(" ", linkedList));

            #endregion

            #region Method: Contains

            Console.WriteLine("\nMethod: Contains");
            Console.Write("Enter value to check availability: ");

            if (int.TryParse(Console.ReadLine(), out value))
            {
                Console.WriteLine($"Element is present: {linkedList.Contains(value)}");
            }

            #endregion

            #region Method: CopyTo

            Console.WriteLine("\nMethod CopyTo: ");
            var array = new int[10];

            linkedList.CopyTo(array, 0);

            Console.WriteLine($"Array length: {array.Length} | Elemtnts {string.Join(" ", array)}");
            #endregion

            #region Method: AddRange

            var range = new List<int>();

            Console.WriteLine("\nMethod AddRange: ");
            Console.WriteLine("Enter a space to complete entry");

            while (int.TryParse(Console.ReadLine(), out value))
            {
                range.Add(value);
            }

            linkedList.AddRange(range);

            Console.WriteLine(string.Join(" ", linkedList));

            #endregion

            #region Method: Clear

            Console.WriteLine("\nMethod Clear: ");
            Console.WriteLine("Press any key for clear the list");
            Console.ReadKey();

            linkedList.Clear();

            Console.WriteLine($"Elements: {string.Join(" ", linkedList)}");
            Console.WriteLine($"Count: {linkedList.Count}");
            #endregion            
        }
    }
}
