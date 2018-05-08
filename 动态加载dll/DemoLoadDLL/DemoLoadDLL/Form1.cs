using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Threading;
using ServiceInterface;
namespace DemoLoadDLL
{
    public partial class Form1 : Form, BaseInterface
    {
        public Form1()
        {
            InitializeComponent();
        }
        public List<Modules> AllModules = new List<Modules>();
        // public Assembly Assem = null;
        private delegate void SetTBMethodInvoke(object state);
        private void button1_Click(object sender, EventArgs e)
        {
            string Url = System.Environment.CurrentDirectory;
            DirectoryInfo folder = new DirectoryInfo(Url + "\\dll模块");
            foreach (FileInfo file in folder.GetFiles("*.dll"))
            {
                Assembly Assem = Assembly.LoadFrom(Url + "\\dll模块\\" + file.Name);
                Type[] typebyte = Assem.GetTypes();
                if (typebyte != null)
                {
                    string Namespace = typebyte[0].FullName;
                    Type type = Assem.GetType(Namespace);
                    Object obj = Activator.CreateInstance(type);
                    MethodInfo fun = type.GetMethod("Main");
                    if (fun != null)
                    {
                        fun.Invoke(obj, null);
                    }
                }
            }
        }

        public void timer()
        {
            AllModules = new List<Modules>();
            string Url = System.Environment.CurrentDirectory;
            DirectoryInfo folder = new DirectoryInfo(Url + "\\dll模块");
            foreach (FileInfo file in folder.GetFiles("*.dll"))
            {   //获取执行的dll模块的方法。
                Modules modules = new Modules();
                modules.timer = new System.Threading.Timer(new TimerCallback(SetTB), modules, 0, 3000);
                modules.Assembly = Assembly.LoadFrom(Url + "\\dll模块\\" + file.Name);
                AllModules.Add(modules);
            }
        }

        public void SetTB(object value)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new SetTBMethodInvoke(SetTB), value);
            }
            else
            {
                Modules Modul = value as Modules;
                if (Modul.Assembly != null)
                {
                    Type[] typebyte = Modul.Assembly.GetTypes();
                    string sss = Modul.Assembly.FullName;
                    if (typebyte != null)
                    {
                        string Namespace = typebyte[1].FullName;
                        Type type = Modul.Assembly.GetType(Namespace);
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
        Log log = new Log();

        private void button2_Click(object sender, EventArgs e)
        {
            timer();
            if (AllModules != null && AllModules.Count > 0)
            {
                foreach (Modules a in AllModules)
                {
                    // a.timer.Change(0, 3000);//开启计时器
                    // a.timer.Change(Timeout.Infinite, 3000);//关闭计时器
                }
            }
        }


        public void Execute()
        {
            throw new NotImplementedException();
        }
    }
}
