using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
//using Utilities;

namespace DataStructures
{
    public class Stack<T> /*: IEnumerable<T> where T : IComparable<T>*/
    {
        // Operations allowable
        // IsEmpty() returns true if the stack is empty or converse
        // Push(T item) add an item at the tail of the stack
        // Pop() removes and return the last item at the tail of the stack
        // Peek() returns the last item added to the stack
        // Size() shows the number of items in the stack

        private T[] _collection { get; set; }
        private int _top;
        private int _max;
        Index top = ^1;
        //public int Size { get { return _collection.Count;  } }


        public Stack (int size)
        {
            _top = -1;
            _max = size;
            _collection = new T[size];
        }

        public void Push(T item)
        {
            if(_top == _max -1)
            {
                return;
            } else
            {
                _collection[++_top] = item;
            }
        }

        public T Pop()
        {
            if(_top == -1)
            {
                throw new IndexOutOfRangeException("List is empty.");

            } else
            {
                return _collection[_top--];
            }
        }

        public T Peek()
        {
            if(_top == -1)
            {
                throw new IndexOutOfRangeException("List is empty.");
            } else
            {
                return _collection[top];
            }
        }
    }
}
