using System;
using System.Linq;
using System.Text;
using RabbitMQ.Client;

namespace RabbitSender
{
    class Program
    {
        static void Main(string[] args)
        {
            //var hello = new HelloSender();
            //hello.Greet("Brand New World!");

            //var message = "";
            //var producer = new Producer();
            //var broadcaster = new Broadcaster();
            //var direct = new DirectSender();
            //var topic = new TopicSetter();

            //Console.WriteLine("Write [exit] to end");
            //while (message != "exit")
            //{
            //    message = Console.ReadLine();

            //    //producer.Produce(message);

            //    //broadcaster.Publish(message);

            //    //var parts = message.Split(' ');
            //    //direct.Send(string.Join(" ", parts.Skip(1)), parts[0]);

            //    topic.Send(message);
            //}

            var client = new RpcClient();
            var input = 0;
            while(true)
            {
                var raw = Console.ReadLine();
                if (!int.TryParse(raw, out input))
                    break;

                Console.WriteLine($" [x] Requesting fib({raw})");
                var response = client.Call(raw);
                Console.WriteLine(" [.] Got '{0}'", response);
            }
            client.Close();
        }
    }
}
