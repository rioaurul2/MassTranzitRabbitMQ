using MassTransit;
using MassTranzitT4_GTaylor_API.Models;

namespace MassTranzitT4_GTaylor_API.Consumers
{
    public class TestConsumer : IConsumer<ExampleClass>
    {
        readonly ILogger<TestConsumer> _logger;

        public TestConsumer(ILogger<TestConsumer> logger)
        {
            _logger = logger;
        }

        public Task Consume(ConsumeContext<ExampleClass> context)
        {
            _logger.LogInformation($"The received message is {context.Message.Value}");

            return Task.CompletedTask;
        }
    }
}
