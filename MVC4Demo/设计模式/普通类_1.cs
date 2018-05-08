using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 设计模式
{
    public class 普通类_1 : 抽象类
    {
        public override int Sum()
        {
            Random d = new Random();

            return 1 + 1;
        }
        public override int add()
        {
            return 5;
        }
    }
}
