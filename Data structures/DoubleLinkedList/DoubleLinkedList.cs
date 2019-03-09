using System.Collections;
using System.Collections.Generic;

namespace Algorithms_and_data_structures
{
    internal class DoubleLinkedList<T> : IEnumerable<T>
    {
        private LinkedListNode<T> _head;
        private LinkedListNode<T> _tail;

        public int Count { get; internal set; }

        public DoubleLinkedList()
        {
        }

        public DoubleLinkedList(IEnumerable<T> collection)
        {
        }

        #region Addind a new element to the beginning of the array

        public void AddFirst(T value)
        {
            var newNode = new LinkedListNode<T>(value);

        }
       
        #endregion

        #region Checking for an item in the list 
        public bool Contains(T value)
        {
            var current = _head;

            while (current != null)
            {
                if (current.Value.Equals(value)) return true;
                current = current.Next;
            }

            return false;
        }
        #endregion

        #region Clear the list

        public void Clear()
        {
            _head = _tail = null;
            Count = 0;
        }

        #endregion

        #region Copy the list to an array

        public void CopyTo(T[] array, int index)
        {
            var current = _head;

            while (current != null && index >= 0 && index < array.Length)
            {
                array[index++] = current.Value;
                current = current.Next;
            }
        }

        #endregion

        #region Enumerators

        public IEnumerator<T> GetEnumerator()
        {
            var current = _head;

            while (current != null)
            {
                yield return current.Value;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<T>)this).GetEnumerator();
        }
        

        #endregion
    }
}