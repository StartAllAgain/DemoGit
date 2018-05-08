using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Timers;
using System.IO;
using System.Reflection;

namespace RandModuleService
{
    class ControlModuleRun
    {
        private Timer timer = new Timer();

        public ControlModuleRun()
        {
            string RunTime = ConfigurationManager.ConnectionStrings["RunTime"].ConnectionString;

            if (RunTime != "")
            {
                timer.Interval = int.Parse(RunTime) * 1000;
            }
            else
            {
                timer.Interval = 300 * 1000;
            }

            timer.Elapsed += new System.Timers.ElapsedEventHandler(timer_Tick);
            timer.Enabled = true;
        }
        public void Stop()
        {
            timer.Stop();
        }
        public void Start()
        {
            timer.Start();
        }
        private static readonly object obj = new object();
        private void timer_Tick(object sender, EventArgs e)
        {
            lock (obj)
            {
                string Url = System.Environment.CurrentDirectory;
                DirectoryInfo folder = new DirectoryInfo(Url + "\\dll模块");
                foreach (FileInfo file in folder.GetFiles("*.dll"))
                {   //获取执行的dll模块的方法。
                    Assembly Assem = Assembly.LoadFrom(Url + "\\dll模块\\" + file.Name);
                    Type[] typebyte = Assem.GetTypes();
                    if (typebyte != null)
                    {
                        string Namespace = typebyte[0].FullName;
                        Type type = Assem.GetType(Namespace);
                        Object objFun = Activator.CreateInstance(type);
                        MethodInfo fun = type.GetMethod("Main");
                        if (fun != null)
                        {
                            fun.Invoke(objFun, null);
                        }
                    }
                }

            }
        }
    }
}
