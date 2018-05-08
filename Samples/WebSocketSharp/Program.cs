using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using WebSocketSharp;
using WebSocketSharp.Server;

namespace WebSocketSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            WebSocketServer wss = new WebSocketServer(10001);
            wss.AddWebSocketService<MyWebSocketBehavior>("/home");
            wss.Start();

            Console.ReadLine();
        }
    }

    class MyWebSocketServer : WebSocketServer
    {

    }

    class MyWebSocket : WebSocket
    {
        public string Name { get; set; }
        public MyWebSocket(string url)
            : base(url)
        {

        }
    }

    class MyWebSocketBehavior : WebSocketBehavior
    {
        protected override void OnOpen()
        {
            this.Sessions.Broadcast("new");
        }
        protected override void OnMessage(MessageEventArgs e)
        {

            string sss = this.Context.Host;
            Console.WriteLine("Server received: " + e.Data);
            this.Send("hello too");
        }
    }
}
