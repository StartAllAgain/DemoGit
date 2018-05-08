using ServiceInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ABC
{
    public class Class1 : BaseInterface
    {
        Log log = new Log();
        public void Execute()
        {
            log.WriteLine("运行时间A3【运行后A3模块停止1分钟，运行下一个】：" + DateTime.Now.ToShortDateString());
        }

    }
}
