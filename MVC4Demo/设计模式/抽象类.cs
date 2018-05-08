using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 设计模式
{
    public abstract class 抽象类
    {
        public int Sum(int a, int b)
        {
            return a + b;
        }
        public abstract int Sum();

        public abstract int add();
    }
}
