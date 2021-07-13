using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures
{
    public class SLinkedListNode<T> : IComparable<SLinkedListNode<T>> where T : IComparable<T>
    {
        private T _data;
        private SLinkedListNode<T> _next;

        // Constructor
        public SLinkedListNode()
        {
            Next = null;
            Data = default(T);
        }

        // Constructor
        public SLinkedListNode(T dataItem)
        {
            Next = null;
            Data = dataItem;
        }

        public T Data
        {
            get { return this._data; }
            set { this._data = value; }
        }

        public SLinkedListNode<T> Next
        {
            get { return this._next; }
            set { this._next = value; }
        }

        // Implements CompareTo as required by the IComparable interface
        public int CompareTo(SLinkedListNode<T> other)
        {
            if (other == null) return -1;

            return this.Data.CompareTo(other.Data);
        }
    }
    public class SinglyLinkedList<T> : IEnumerable<T> where T : IComparable<T>
    {
        private int _count;
        private SLinkedListNode<T> _firstNode { get; set; }
        private SLinkedListNode<T> _lastNode { get; set; }

        public int Count => _count;

        // Virtual - allows for possibility of being overriden by a derived class
        public virtual SLinkedListNode<T> Head => this._firstNode;

        //Constructor
        public SinglyLinkedList()
        {
            _firstNode = null;
            _lastNode = null;
            _count = 0;
        }

        // Returns the first element of the list
        public T First => _firstNode == null ? default(T) : _firstNode.Data;

        //Adds an item at the tail of the list and returns the count
        public int Add(T dataItem)
        {
            SLinkedListNode<T> newNode = new SLinkedListNode<T>(dataItem);
            if (_firstNode == null)
            {
                // _firstNode and _lastNode are essentially the same 
                //  as only one item is added so far i.e the list was empty prior
                _firstNode = _lastNode = newNode;
            }
            else
            {
                var currentNode = _lastNode;
                currentNode.Next = newNode;
                _lastNode = newNode;
            }

            // Increment count
            _count++;

            return _count;
        }

        // Removes the first occurrence of an item in the LinkedList
        // returns true if said item is found and removes: false otherwise
        public bool Remove(T dataItem)
        { 
            return false;
        }

        // Checks if an item is in the list
        public bool Check(T dataItem)
        {
            return Index(dataItem) != -1;
        }

        // Returns the index of an item
        public int Index(T dataItem)
        {
            int index = 0;
            var current = _firstNode;
            while(current != null)
            {
                if (current.Data == dataItem) return index;
                current = current.Next;
                index++;
            }

            return -1;
        }

        /********************************************************************************/

        public IEnumerator<T> GetEnumerator()
        {
            return new SLinkedListEnumerator(this);
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return new SLinkedListEnumerator(this);
        }

        /********************************************************************************/

        internal class SLinkedListEnumerator : IEnumerator<T>
        {
            private SLinkedListNode<T> _current;
            private SinglyLinkedList<T> _doublyLinkedList;

            public SLinkedListEnumerator(SinglyLinkedList<T> list)
            {
                this._doublyLinkedList = list;
                this._current = list.Head;
            }

            public T Current
            {
                get { return this._current.Data; }
            }

            object System.Collections.IEnumerator.Current
            {
                get { return Current; }
            }

            public bool MoveNext()
            {
                _current = _current.Next;

                return (this._current != null);
            }

            public void Reset()
            {
                _current = _doublyLinkedList.Head;
            }

            public void Dispose()
            {
                _current = null;
                _doublyLinkedList = null;
            }
        }


    }
}
