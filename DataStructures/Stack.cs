using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using Utilities;

namespace DataStructures
{
    // A type constraint `IComparable` is applied to `T`
    public class Stack<T> : IEnumerable<T> where T : IComparable<T>
    {
        // Operations allowable
        // IsEmpty() returns true if the stack is empty or converse
        // Push(T item) add an item at the tail of the stack
        // Pop() removes and return the last item at the tail of the stack
        // Peek() returns the last item added to the stack
        // Size() shows the number of items in the stack

        private ArrayList<T> _collection { get; set; }
        public int Size { get { return _collection.Count; } }   

        public Stack()
        {
            //Stack Collection implemented as an array based list
            _collection = new ArrayList<T>();
        }

        //Allows for specification of size on construction
        public Stack(int initialCapacity)
        {
            if (initialCapacity < 0)
            {
                throw new ArgumentOutOfRangeException();
            }


            _collection = new ArrayList<T>(initialCapacity);
        }

        public bool IsEmpty
        {
            get
            {
                return _collection.IsEmpty;
            }
        }

        public void Push(T item)
        {
            _collection.Add(item);
        }

        public T Pop()
        {
            if(Size > 0)
            {
                var top = Top;
                _collection.RemoveAt(_collection.Count - 1);
                return top;
            }

            throw new Exception("Stack is empty");

        }

        public T Peek() => Top;

        public T Top
        {
            get
            {
                try
                {
                    return _collection[_collection.Count - 1];
                }
                catch (Exception)
                {
                    throw new Exception("Stack is empty.");
                }
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = _collection.Count - 1; i >= 0; --i)
                yield return _collection[i];
        }

        // Because IEnumerable<T> inherits from IEnumerable,
        // we must implement both generic and non generic version of GetEnumerator
        // see Chapter 7 C# 9 in a nutshell
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
