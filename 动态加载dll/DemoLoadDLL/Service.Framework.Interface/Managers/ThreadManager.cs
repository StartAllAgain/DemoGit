using Service.Framework.Interface.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Service.Framework.Interface.Managers
{//操作线程类
    public class ThreadManager
    {
        public void Start(DispatchManager Dispatch, ModulesManager Modules)
        {
            Dispatch.timer.Change(0, 3000);//设置线程开始，并设置运行周期
        }
        public void Stop(DispatchManager Dispatch, ModulesManager Modules)
        {
            Dispatch.timer.Change(Timeout.Infinite, 3000);//设置线程结束
        }

    }
}
