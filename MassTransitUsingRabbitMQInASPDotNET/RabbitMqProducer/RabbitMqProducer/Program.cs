using RabbitMQ.Client;
using RabbitMqProducer;

namespace RabbitMq.Producer
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

            //DirectExchangePublisher.Publish(channel);
            //TopicExchangePublisher.Publish(channel);
            //HeaderExchangePublisher.Publish(channel);
            FanoutExchangePublisher.Publish(channel);
            FanoutExchangePublisher2.Publish(channel);

        }
    }
}