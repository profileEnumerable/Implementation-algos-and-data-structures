using System;
using System.Collections.Generic;

namespace Algorithms_and_data_structures
{
    internal class Program
    {
        private static void Main()
        {
            var doubleLinkedList = new DoubleLinkedList<string>();


            var linkedList = new LinkedList<int>();

            linkedList.AddFirst(12);

            Console.WriteLine(string.Join(" ",linkedList));
        }
    }
}   