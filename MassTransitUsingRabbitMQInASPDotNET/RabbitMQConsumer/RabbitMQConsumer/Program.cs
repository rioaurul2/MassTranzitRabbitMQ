using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using RabbitMQConsumer;
using System.Text;

namespace RabbitMQ.Consumer
{
    static class Program
    {
        static void Main(string[] args)
        {
            var factory = new ConnectionFactory
            {
                Uri = new Uri("amqp://guest:guest@localhost:5672")
            };

            using var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();

            //DirecteExchangeConsumer.Consume(channel);
            //TopicExchangeConsumer.Consume(channel);
            //HeaderExchangeConsumer.Consume(channel);
            FanoutExchangeConsumer.Consume(channel);
            FanoutExchangeConsumer2.Consume(channel);
        }
    }
}