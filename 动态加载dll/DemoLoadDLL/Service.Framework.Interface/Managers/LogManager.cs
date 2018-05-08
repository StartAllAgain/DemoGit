using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Service.Framework.Interface
{
    public delegate void LogMessageHandle(string message);
    public class LogManager
    {
        //\bSend\b[^ReadData]*\bSend\b
        public Control thisParent = null;
        public bool Debug { get; set; }
        public event LogMessageHandle OnLogMessage;
        static BackgroundWorker backgroundWorker = new BackgroundWorker();
        public LogManager()
        {
            this.Debug = false;
        }

        private void Write(string message)
        {
            try
            {
                IAsyncResult asyncResult = thisParent.BeginInvoke(new LogMessageHandle(OnLogMessage), message);
                thisParent.EndInvoke(asyncResult);
            }
            catch { }

            int loopCount = 1;
            string fileName = "";
            if (IsIP(message.Split('|')[1]))
            {
                loopCount = 2;
                fileName = DateTime.Now.ToString("yyyyMMdd") + "IP" + message.Split('|')[1].Trim() + ".txt";
                ;
            }
            for (int i = 1; i <= loopCount; i++)
            {
                if (i == 2)
                    fileName = "";
                string MutexName = DateTime.Now.ToString("yyyyMMdd");
                //进程互斥
                Mutex M = new Mutex(false, MutexName);
                try
                {
                    M.WaitOne();
                    string filePath = System.AppDomain.CurrentDomain.BaseDirectory + @"\log\";
                    if (!Directory.Exists(filePath))
                    {
                        Directory.CreateDirectory(filePath);
                    }
                    if (fileName == "")
                        fileName = DateTime.Now.ToString("yyyyMMdd") + ".txt";
                    string fileFullName = filePath + fileName;
                    using (FileStream FS = File.Open(fileFullName, FileMode.Append, FileAccess.Write, FileShare.Read))
                    {

                        Encoding encode = Encoding.UTF8;
                        byte[] MessageByte = encode.GetBytes(message);
                        FS.Write(MessageByte, 0, (int)MessageByte.Length);
                    }

                }
                finally
                {
                    M.ReleaseMutex();
                }
            }


        }


        public void WriteLine(string message)
        {
            try
            {
                Write(Environment.NewLine + DateTime.Now.ToString("HH:mm:ss.fff|") + message);
            }
            catch
            { }
        }

        public void WriteLine1(string typeStr, string message)
        {
            if (Debug)
                typeStr = "Debug:" + typeStr;
            typeStr = typeStr.PadRight(27);
            WriteLine(typeStr + "|" + message);
        }


        public void WriteLine(string levelStr, string typeStr, string message)
        {
            if (Debug)
                typeStr = "Debug:" + typeStr;
            levelStr = levelStr.PadRight(15);
            typeStr = typeStr.PadRight(20);
            WriteLine(levelStr + "|" + typeStr + "|" + message);
        }

        public bool IsIP(string ip)
        {
            string pattrn = @"(\d{1,2}|1\d\d|2[0-4]\d|25[0-5])\.(\d{1,2}|1\d\d|2[0-4]\d|25[0-5])\.(\d{1,2}|1\d\d|2[0-4]\d|25[0-5])\.(\d{1,2}|1\d\d|2[0-4]\d|25[0-5])";
            if (System.Text.RegularExpressions.Regex.IsMatch(ip, pattrn))
            {
                return true;
            }
            else
            {
                return false;

            }
        }
    }

}
