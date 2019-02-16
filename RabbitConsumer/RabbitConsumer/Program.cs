using System;
using System.Linq;
using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace RabbitConsumer
{
    class Program
    {
        static void Main(string[] args)
        {
            //var receiver = new HelloReceiver();
            //receiver.Listen();

            //var worker = new Worker();
            //worker.Work();

            //var subscriber = new MassSubscriber();
            //subscriber.Subscribe();

            //var selective = new SelectiveSubscriber();
            //selective.Subscribe(new[] { "warning", "error"});

            //var topicListener = new TopicListener();
            //topicListener.Subscribe(new[] { "red.#", "*.dog" });

            var server = new RpcServer();
            server.Listen();
        }
    }
}
