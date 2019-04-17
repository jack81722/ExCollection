using Demo.SortedSetDemo;
using System;

namespace Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            AddRemoveDemo demo1 = new AddRemoveDemo();
            demo1.Start();
            SearchDemo demo2 = new SearchDemo();
            demo2.Start();
            UnionDemo demo3 = new UnionDemo();
            demo3.Start();
            ExceptDemo demo4 = new ExceptDemo();
            demo4.Start();
            IntersectDemo demo5 = new IntersectDemo();
            demo5.Start();

            Console.ReadLine();
        }
    }
}
