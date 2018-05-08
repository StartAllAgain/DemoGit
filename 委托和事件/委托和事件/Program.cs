using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Net;
using System.IO;
using System.Threading;

namespace 委托和事件
{
    class Program
    {
        public delegate void DelegateFun();
        private static delegateClass delegateClass = new delegateClass();
        //  delegateClass c = A;

        protected delegate void UpdateDisplayDelegate(string text);
        Thread thread = new Thread(new ThreadStart(D));

        static void Main(string[] args)
        {
            thread.Start();
            //System.Diagnostics.Process pr1 = System.Diagnostics.Process.Start("cmd", "/c net start RendIdCardService");
            string d = ConfigurationManager.ConnectionStrings["1"].ConnectionString;
            //DelegateFun FunName = new DelegateFun(A);
            //FunName();
            //d.Event += new Program.DelegateFun(A);
            //d.Event += new Program.DelegateFun(B);
            //delegateClass();
            C();
            D();
            delegateClass.EventName += A;
            delegateClass.delegateFunction(1, 2);
            Console.ReadLine();
        }


        public static void A(int a)
        {

            Console.WriteLine("abc");
        }
        public static void B()
        {
            Console.WriteLine("123");
        }
        public static void C()
        {
            TcpClient tcpClient = new TcpClient();

            NetworkStream str = tcpClient.GetStream();
            byte[] by = new byte[800];
            str.Read(by, 0, by.Length);

            Console.WriteLine("456");
        }
        public void D()
        {
            Socket listener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            listener.Bind(new IPEndPoint(IPAddress.Any, 9999));

            listener.Listen(0);

            Socket socket = listener.Accept();
            Stream netStream = new NetworkStream(socket);
            StreamReader reader = new StreamReader(netStream);

            string result = reader.ReadToEnd();
            Invoke(new UpdateDisplayDelegate(UpdateDisplay), new object[] { result });

            socket.Close();
            listener.Close();
        }
        public void UpdateDisplay(string text)
        {
            Console.WriteLine(text);
        }
    }
}
