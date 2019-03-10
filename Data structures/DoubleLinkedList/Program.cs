using System;
using System.Collections.Generic;

namespace Algorithms_and_data_structures
{
    internal class Program
    {
        private static void Main()
        {
            var doubleLinkedList = new DoubleLinkedList<int>();

            doubleLinkedList.AddLast(1);
            doubleLinkedList.AddLast(2);
            doubleLinkedList.AddLast(3);
            doubleLinkedList.AddLast(4);

            doubleLinkedList.AddAfter(25, 1);

            foreach (var item in doubleLinkedList)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine();
            doubleLinkedList.ReverseOutput();
        }
    }
}