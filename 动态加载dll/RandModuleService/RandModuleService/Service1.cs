using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;

namespace RandModuleService
{
    public partial class Service1 : ServiceBase
    {
        ControlModuleRun threaTime = new ControlModuleRun();
        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            threaTime.Start();
        }

        protected override void OnStop()
        {
            threaTime.Stop();
        }
    }
}
