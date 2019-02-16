using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Text;

namespace RabbitSender
{
    class HelloSender
    {
        public void Greet(string msg)
        {
            var factory = new ConnectionFactory { HostName = "192.168.40.129", UserName = "test", Password = "123456" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare("Mima.Hops", false, false, false, null);
                channel.BasicPublish("", "Mima.Hops", null, Encoding.UTF8.GetBytes(msg));
                Console.WriteLine($"Sent message: {msg}");

                Console.ReadLine();
            }
        }
    }
}
