using System;
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

        public void ReverseOutput()
        {
            var current = _tail;

            while (current != null)
            {
                Console.WriteLine(current.Value);
                current = current.Previous;
            }
        }

        #region Removing the "specified" element from the list

        public bool Remove(T value)
        {
            var current = _head;
            LinkedListNode<T> previous = null;

            while (current != null)
            {
                if (current.Value.Equals(value))
                {
                    if (previous == null)
                    {
                        RemoveFirst();
                    }
                    else
                    {
                        previous.Next = current.Next;

                        if (previous.Next == null)
                        {
                            _tail = previous;
                        }
                        else
                        {
                            var nextNode = current.Next;
                            nextNode.Previous = previous;
                        }

                        Count--;
                    }

                    return true;
                }

                previous = current;
                current = current.Next;
            }

            return false;
        }

        #endregion

        #region Remove the "first" element from the list

        public void RemoveFirst()
        {
            if (Count == 0) return;

            _head = _head.Next;

            if (_head == null)
                _tail = null;
            else
                _head.Previous = null;

            Count--;
        }

        #endregion

        #region Remove the "last" element from the list 

        public void RemoveLast()
        {
            switch (Count)
            {
                case 0:
                    return;
                case 1:
                    _head = _tail = null;
                    break;
                default:
                    _tail.Previous.Next = null;
                    _tail = _tail.Previous;
                    break;
            }

            Count--;
        }

        #endregion

        #region Adding a new element to the "end" of the list

        public LinkedListNode<T> AddLast(T value)
        {
            var newNode = new LinkedListNode<T>(value);

            if (_head == null)
            {
                _head = newNode;
            }
            else
            {
                _tail.Next = newNode;
                newNode.Previous = _tail;
            }

            _tail = newNode;

            Count++;

            return newNode;
        }

        #endregion

        #region Addind a new element to the "beginning" of the list

        public LinkedListNode<T> AddFirst(T value)
        {
            var newNode = new LinkedListNode<T>(value);

            if (_head == null)
            {
                _tail = newNode;
            }
            else
            {
                newNode.Next = _head;
                _head.Previous = newNode;
            }

            _head = newNode;

            Count++;

            return newNode;
        }

        #endregion

        #region Adding a new element after specifaed index

        public void AddAfter(T item, int index)
        {
            var newNode = new LinkedListNode<T>(item);
            var current = _head;

            var i = 0;
            while (current != null && i != index)
            {
                i++;
                current = current.Next;
            }

            LinkedListNode<T> temp = current.Next;

            current.Next = newNode;
            newNode.Next = temp;
            newNode.Previous = current;
            temp.Previous = newNode;
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