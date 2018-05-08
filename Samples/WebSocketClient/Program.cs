using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebSocketSharp;

namespace WebSocketClient
{
    class Program
    {
        static void Main(string[] args)
        {
            MyWebSocket ws = new MyWebSocket("ws://10.0.2.54:10001/home");
            ws.Name = "client1";
            ws.OnMessage += ws_OnMessage;
            ws.Connect();
            ws.Send("a:hello");
            while (true)
            {
                string input = Console.ReadLine();
                ws.Send(input);
                Console.ReadLine();
            }
         
        }

        static void ws_OnMessage(object sender, MessageEventArgs e)
        {
            Console.WriteLine("Client received: " + e.Data);
        }
    }

    class MyWebSocket : WebSocket
    {
        public string Name { get; set; }
        public MyWebSocket(string url)
            : base(url)
        {

        }
    }

}
