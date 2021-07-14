using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures
{
    public class SNode<T>
    {
        private T _data;
        private SNode<T> _next;

        public SNode()
        {
            Next = null;
            Data = default(T);
        }

        public SNode(T dataItem)
        {
            Data = dataItem;
            _next = null;
        }

        public T Data
        {
            get { return this._data; }
            set { this._data = value; }
        }

        public SNode<T> Next
        {
            get { return this._next;  }
            set { this._next = value;  }
        }


    }

    class Stack<T>
    {

        private int _count;
        SNode<T> _firstNode { get; set; }
        SNode<T> _lastNode { get; set; }

        public int Size => _count;


        public Stack()
        {
            _firstNode = null;
            _lastNode = null;
            _count = 0;
        }

        public bool IsEmpty()
        {
            return Size == 0 || _firstNode == null;
        }
        
        /// <summary>
        /// Adds item to tail of stack
        /// </summary>
        public void Push(T dataItem)
        {
            SNode<T> newNode = new SNode<T>(dataItem);
            if(_firstNode == null)
            {
                _firstNode = _lastNode = newNode;
            }
            else
            {
                var currentNode = _lastNode;
                currentNode.Next = newNode;
                _lastNode = newNode;
            }

            _count++;
        }
        
        /// <summary>
        /// Removes Item from tail of stack
        /// </summary>
        /// <returns>Deleted Item</returns>
        public T Pop()
        {
            if (Size == 0)
                throw new InvalidOperationException("Collection contains no element");

            T deleted = default(T);
            var previous = GetPrevious(_lastNode);
            deleted = previous.Next.Data;

            _lastNode = previous;
            _lastNode.Next = null;

            _count--;

            return deleted;
        }

        /// <summary>
        /// Gets Node before the last node
        /// </summary>
        private SNode<T> GetPrevious(SNode<T> node)
        {
            var current = _firstNode;
            while (current != null)
            {
                if (current.Next == node) return current;
                current = current.Next;
            }
            return null;
        }

        /// <summary>
        /// Returns the last 
        /// </summary>
        public T Peek()
        {
            if (Size == 0)
                Console.WriteLine("Stack is empty");

            return GetPrevious(_lastNode).Next.Data;
        }

        public IEnumerator<T> GetEnumerator()
        {
            SNode<T> current = _firstNode;

            while (current != null)
            {

                if (current == null) break;
                yield return current.Data;

                current = current.Next;
            }
        }

    }
}
