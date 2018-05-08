using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;

namespace Service.Framework.Interface.Modules
{
    public class DispatchManager
    {
        public Timer timer { get; set; }

        public Assembly assembly { get; set; }

    }
}
