using System;
using System.Collections.Generic;

namespace DataStructures
{
    public class SLinkedListNode<T>
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
            Data = dataItem;
            Next = null;
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
    }
    public class SinglyLinkedList<T>
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

        public bool IsEmpty()
        {
            return (Count == 0);
        }

        // Returns the first element of the list
        public T First => _firstNode == null ? default(T) : _firstNode.Data;

        /// <summary>
        /// Adds an item at the tail of the list
        /// </summary>
        /// <param name="dataItem"></param>
        /// <returns>Count of total items in the list</returns>
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
        // https://www.geeksforgeeks.org/linked-list-set-3-deleting-node/
        public bool Remove(T dataItem)
        { 

            if(Check(dataItem) == false)
            {
                //throw new InvalidOperationException("Collection contains no element");
                return false;
            }


            SLinkedListNode<T> current = _firstNode, previous = null;

            //If firstNode (i.e head) itself holds the dataItem to be deleted
            if(current != null && current.Data.Equals(dataItem))
            {
                _firstNode = current.Next;
                return true;
            }

            while (current != null && current.Data.Equals(dataItem) == false)
            {
                previous = current;
                current = current.Next;
            }

            if (current == null) return false;

            //Unlink node from the linked list
            previous.Next = current.Next;
            return true;
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
                if (current.Data.Equals(dataItem)) return index;
                current = current.Next;
                index++;
            }

            return -1;
        }

        public IEnumerator<T> GetEnumerator()
        {
            SLinkedListNode<T> current = _firstNode;

            while(current != null)
            {

                if (current == null) break;
                yield return current.Data;

                current = current.Next;
            }
        }
    }
}
