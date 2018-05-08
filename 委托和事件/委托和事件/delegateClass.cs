using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 委托和事件
{
    public class delegateClass
    {
        public delegate void delegageDemo1(int a);
        public event delegageDemo1 EventName;

        public void delegateFunction(int a, int b)
        {
            EventName(a);
            Console.WriteLine("aaa");
        }
    }
}
