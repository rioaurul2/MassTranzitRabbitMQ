using RabbitMQ.Client.Events;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQConsumer
{
    public static class FanoutExchangeConsumer2
    {
        public static void Consume(IModel channel)
        {
            channel.ExchangeDeclare("demo-fanout-exchange", ExchangeType.Fanout);
            channel.QueueDeclare("demo-fanout2-queue",
              durable: true,
              exclusive: false,
              autoDelete: false,
              arguments: null);
            channel.QueueBind("demo-fanout2-queue", "demo-fanout-exchange", string.Empty);
            channel.BasicQos(0, 10, false);

            var consumer = new EventingBasicConsumer(channel);

            consumer.Received += (sender, e) =>
            {
                var body = e.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);

                Console.WriteLine(message);
            };

            channel.BasicConsume("demo-fanout2-queue", true, consumer);
            Console.WriteLine("Fanout2 Consumer started");
            Console.ReadLine();
        }
    }
}
