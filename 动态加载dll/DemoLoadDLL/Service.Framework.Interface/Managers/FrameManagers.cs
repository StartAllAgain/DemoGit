using Service.Framework.Interface.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Service.Framework.Interface.Managers
{
    public class FrameManagers
    {
        public static FrameManagers Instance { get; set; }
        private LogManager logManager = new LogManager();
        public static void Initialize(DispatchManager Dispatch, ModulesManager Modules)
        {
            Instance = new FrameManagers(Dispatch, Modules);
        }

        public FrameManagers(DispatchManager Dispatch, ModulesManager Modules)
        {

        }
        //日志
        public void Log(string message)
        {
            logManager.WriteLine(message);
        }
    }
}
