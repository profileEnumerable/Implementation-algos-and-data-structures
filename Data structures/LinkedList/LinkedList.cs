
using System.Collections;
using System.Collections.Generic;

namespace Algorithms_and_data_structures
{
    public class LinkedList<T> : IEnumerable<T>
    {
        private LinkedListNode<T> _head;
        private LinkedListNode<T> _tail;

        public int Count { get; private set; } //total number of items

        #region Add value to list

        public void Add(T value)
        {
            var newNode = new LinkedListNode<T>(value);

            if (_head == null)
            {
                _head = _tail = newNode;
            }
            else
            {
                _tail.Next = newNode;
                _tail = newNode;
            }

            Count++;
        }

        #endregion

        #region Remove value from the list

        public bool Remove(T value)
        {
            LinkedListNode<T> previous = null;
            var current = _head;

            while (current != null)
            {
                if (current.Value.Equals(value))
                {
                    if (previous == null)
                    {                        
                        _head = _head.Next;

                        if (_head == null) _tail = null;
                    }
                    else
                    {
                        previous.Next = current.Next;

                        if (previous.Next == null) _tail = previous;
                    }

                    Count--;
                    return true;
                }

                previous = current;
                current = current.Next;
            }

            return false;
        }

        #endregion

        #region Checking for an item in the list 

        public bool Contains(T value)
        {
            var current = _head;

            while (current != null)
            {
                if (current.Value.Equals(value))
                    return true;
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

            while (index >= 0 && index < array.Length && current != null)
            {
                array[index++] = current.Value;
                current = current.Next;
            }
        }

        #endregion

        #region Adding a range of items to the list

        public void AddRange(IEnumerable<T> collection)
        {
            foreach (var item in collection)
            {
                Add(item);
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
            return ((IEnumerable<T>) this).GetEnumerator();
        }

        #endregion
    }
}