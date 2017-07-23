using System;
using System.Collections.Generic;
using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Framing;

namespace Alexw.RabbitMqExample.Publisher
{
    public static class Program
    {
        public static class Settings
        {
            public static List<string> Hosts = new List<string> { "localhost" };
            public static string ExchangeName = "my.exchange.name";
            public static string RoutingKey = "";
        }

        public static void Main()
        {
            var factory = new ConnectionFactory();
            var connection = factory.CreateConnection(Settings.Hosts);

            var model = connection.CreateModel();

            var body = Encoding.UTF8.GetBytes("hello world");
            model.BasicPublish(Settings.ExchangeName, Settings.RoutingKey, true, new BasicProperties(), body);

            Console.WriteLine("Message sent");
            Console.ReadLine();
        }
    }
}
