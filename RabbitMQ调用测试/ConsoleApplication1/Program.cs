using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ConsoleApplication1
{
    class Program
    {
        delegate int a(int a, int b);
        static void Main(string[] args)
        {
            Func<int, int, int> method2 = (z, x) => { return 1; };

            a method = delegate(int a, int b)
            {
                Console.WriteLine(a + b);
                return a + b;
            };
            method += delegate(int a, int b)
            {
                Console.WriteLine(a - b);
                return a + b;
            };
            method(1, 2);
            int d = method2(1,3);

            Console.WriteLine("开始");
            ThreadPool.QueueUserWorkItem(StartCode);
            ThreadPool.QueueUserWorkItem(StartCode1);
            Console.WriteLine("主线程运行到此");
            Console.Read();

            //MQReceiveManager();
            //MQSendManager();
        }
        public static void StartCode(object i)
        {

            Console.WriteLine("开始执行子线程...{0}", 1);
            Thread.Sleep(1000);
        }
        public static void StartCode1(object i)
        {
            Console.WriteLine("开始执行子1线程...{0}", "2");
            Thread.Sleep(1000);
        }

        public static void MQReceiveManager()
        {
            try
            {
                var factory = new ConnectionFactory() { HostName = "139.217.17.153" };
                using (var connection = factory.CreateConnection())
                {
                    using (var channel = connection.CreateModel())
                    {
                        //定义队列（hello为队列名）
                        //  channel.QueueDeclare("qytj.queue", false, false, false, null);

                        var consumer = new QueueingBasicConsumer(channel);
                        channel.BasicConsume("qytj.queue", true, consumer);
                        channel.QueueBind("qytj.queue", "peis.topic", "getFeeItemSub");

                        while (true)
                        {
                            //接受客户端发送的消息并打印出来
                            var ea = (BasicDeliverEventArgs)consumer.Queue.Dequeue();

                            var body = ea.Body;
                            var message = Encoding.UTF8.GetString(body);
                            Console.WriteLine(" [x] Received {0}", message);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                string st = ex.Message;
            }
        }

        public static void MQSendManager()
        {
            try
            {
                var factory = new ConnectionFactory() { HostName = "139.217.17.153" };
                using (var connection = factory.CreateConnection())
                {
                    using (var channel = connection.CreateModel())
                    {
                        //定义队列（hello为队列名）
                        //   channel.QueueDeclare("hello", false, false, false, null);
                        //发送到队列的消息，包含时间戳
                        List<LisFeeItemSub> list = new DataAccess().getLisFeeItemSub();
                        string Json = Logic.ObjectToJson(list);

                        string message = Json;
                        var body = Encoding.UTF8.GetBytes(message);
                        channel.BasicPublish("peis.topic", "getFeeItemSub", null, body);
                        //channel.BasicPublish("rhis.qytj", "getFeeItemSub", null, body);
                    }
                }
            }
            catch (Exception ex)
            {
                string str = ex.Message;
            }
        }

    }
}
