using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace RabbitConsumer
{
    class HelloReceiver
    {
        public void Listen()
        {
            var factory = new ConnectionFactory { HostName = "192.168.40.129", UserName = "test", Password = "123456" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare("Mima.Hops", false, false, false, null);
                Console.WriteLine("Waiting for message...");

                var consumer = new EventingBasicConsumer(channel);
                consumer.Received += Consumer_Received;
                channel.BasicConsume("Mima.Hops", true, consumer);

                Console.ReadLine();
            }
        }

        private void Consumer_Received(object sender, BasicDeliverEventArgs e)
        {
            var msg = Encoding.UTF8.GetString(e.Body);
            Console.WriteLine($"Received message: {msg}");
        }
    }
}
