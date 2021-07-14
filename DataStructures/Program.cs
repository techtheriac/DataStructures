using System;

namespace DataStructures
{
    class Program
    {
        static void Main(string[] args)
        {
            var Container = new Stack<int>();
            Container.Push(2);
            Container.Push(34);
            Container.Push(44);
            Container.Push(6);
            Container.Push(3);
            Container.Pop();
            Container.Push(99);


            foreach (var item in Container)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine(Container.Peek());
        }
    }
}
