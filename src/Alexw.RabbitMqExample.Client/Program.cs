using System;
using System.Collections.Generic;
using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using RabbitMQ.Client.MessagePatterns;

namespace Alexw.RabbitMqExample.Client
{
    class Program
    {
        public static class Settings
        {
            public static List<string> Hosts = new List<string> { "localhost" };
            public static string ExchangeName = "my.exchange.name";
            public static string RoutingKey = "";
            public static string QueueName = "my.queue.name";
        }

        static int Main()
        {
            var factory = new ConnectionFactory();
            factory.UserName = "guest";
            factory.Password = "guest";

            var connection = factory.CreateConnection(Settings.Hosts);
            var model = connection.CreateModel();

            model.ExchangeDeclare(Settings.ExchangeName, ExchangeType.Fanout);
            model.QueueDeclare(Settings.QueueName, false, false, false, null);
            model.QueueBind(Settings.QueueName, Settings.ExchangeName, Settings.RoutingKey, null);

            var subscription = new Subscription(connection.CreateModel(), Settings.QueueName);
            foreach(BasicDeliverEventArgs e in subscription)
            {
                Console.WriteLine("Received Message: {0}", Encoding.UTF8.GetString(e.Body));
                subscription.Ack(e);
            }

            return 0;
        }
    }
}
