using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Text;

namespace RabbitSender
{
    class Broadcaster
    {
        public void Publish(string message)
        {
            var factory = new ConnectionFactory { HostName = "192.168.40.129", UserName = "admin", Password = "123456" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.ExchangeDeclare(exchange: "logs", type: "fanout");

                var body = Encoding.UTF8.GetBytes(message);
                channel.BasicPublish(exchange: "logs",
                                     routingKey: "",
                                     basicProperties: null,
                                     body: body);
                Console.WriteLine(" [x] Sent {0}", message);
            }
        }
    }
}
