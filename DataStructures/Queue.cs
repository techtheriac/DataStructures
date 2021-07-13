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
        // Operations allowable
        // IsEmpty() returns true if the queue is empty or converse DONE
        // Enqueue(T item) adds an item to the tail of the queue - (addFirst) addtorear
        // Dequeue(T item) removes and return the item at the head of the queue
        // Size() shows the number of items currently in the queue DONE

        private int _count;
        private QNode<T> _firstNode { get; set; }
        private QNode<T> _lastNode { get; set; }

        public QNode<T> Tail => _lastNode;
        public int Size => _count;

        public bool IsEmpty()
        {
            return (Size == 0 || _firstNode == null);
        }

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

        public T Dequeue()
        {
            T deleted = default(T);
            var previous = GetPrevious(_lastNode);
            deleted = previous.Next.Data;

            _lastNode = previous;
            _lastNode.Next = null;

            return deleted;

        }


        // Gets QNode before the last node
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
    }
}
