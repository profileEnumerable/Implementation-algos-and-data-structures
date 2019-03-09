namespace Algorithms_and_data_structures
{
    internal class LinkedListNode<T>
    {
        public LinkedListNode(T value)
        {
            Value = value;
        }

        public T Value { get; set; }

        public LinkedListNode<T> Previous { get; internal set; }
        public LinkedListNode<T> Next { get; internal set; }
    }
}