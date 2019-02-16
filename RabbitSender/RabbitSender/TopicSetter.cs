using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Text;

namespace RabbitSender
{
    class TopicSetter
    {
        static string[] Colors = { "black", "red", "blue" };
        static string[] Animals = { "dog", "cat", "snake" };

        public void Send(string message)
        {
            var factory = new ConnectionFactory { HostName = "192.168.40.129", UserName = "test", Password = "123456" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.ExchangeDeclare(exchange: "topic_logs",
                                        type: "topic");

                var body = Encoding.UTF8.GetBytes(message);
                var rand = new Random();
                var topic = $"{Colors[rand.Next() % 3]}.{Animals[rand.Next() % 3]}";

                channel.BasicPublish(exchange: "topic_logs",
                                     routingKey: topic,
                                     basicProperties: null,
                                     body: body);
                Console.WriteLine(" [x] Sent '{0}':'{1}'", topic, message);
            }
        }
    }
}
