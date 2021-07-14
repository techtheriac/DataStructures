using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures
{
    public class QNode<T>
    {
        private T _data;
        private QNode<T> _next;

        // Constructor
        public QNode()
        {
            Next = null;
            Data = default(T);
        }

        // Constructor
        public QNode(T dataItem)
        {
            Next = null;
            Data = dataItem;
        }

        public T Data
        {
            get { return this._data; }
            set { this._data = value; }
        }

        public QNode<T> Next
        {
            get { return this._next; }
            set { this._next = value; }
        }
    }
    public class Queue<T>
    {

        private int _count;
        private QNode<T> _firstNode { get; set; }
        private QNode<T> _lastNode { get; set; }

        public QNode<T> Tail => _lastNode;
        public int Size => _count;

        public bool IsEmpty()
        {
            return (Size == 0 || _firstNode == null);
        }

        /// <summary>
        /// Adds Item to Queue's head
        /// </summary>
        public void Enqueue(T dataItem)
        {
            QNode<T> newNode = new QNode<T>(dataItem);

            if (IsEmpty())
            {
              _firstNode = _lastNode = newNode;
            }
            else
            {
                newNode.Next = _firstNode;
                _firstNode = newNode;
            }

            // Increment count
            _count++;
        }

        /// <summary>
        /// removes item from Queue's end
        /// </summary>
        /// <returns>Deleted item</returns>
        public T Dequeue()
        {
            T deleted = default(T);
            var previous = GetPrevious(_lastNode);
            deleted = previous.Next.Data;

            _lastNode = previous;
            _lastNode.Next = null;

            // Decrease count by 1 after dequeue
            _count--;

            return deleted;

        }

        /// <summary>
        /// Gets QNode before the last
        /// <summary>
        private QNode<T> GetPrevious(QNode<T> node)
        {
            var current = _firstNode;
            while(current != null)
            {
                if (current.Next == node) return current;
                current = current.Next;
            }
            return null;
        }

        public IEnumerator<T> GetEnumerator()
        {
            QNode<T> current = _firstNode;

            while (current != null)
            {

                if (current == null) break;
                yield return current.Data;

                current = current.Next;
            }
        }
    }
}
