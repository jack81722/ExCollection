using ExCollection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.DropoutStackDemo
{
    public class AddDemo
    {
        public void Start()
        {
            Console.WriteLine("===========DropoutStack Demo==========");
            int stackCapacity = 5;
            int inputCount = 4;
            DropoutStack<int> stack = new DropoutStack<int>(stackCapacity);
            for(int i = 0; i < inputCount; i++)
            {
                stack.Push(i);
            }
            while(stack.Count > 0)
            {
                Console.WriteLine(stack.Pop());
            }
        }
    }
}
