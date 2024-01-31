using MassTransit;

public class SimpleConsumer : IConsumer<SimpleMessage>
{
    readonly ILogger<SimpleConsumer> _logger;

    public SimpleConsumer( ILogger<SimpleConsumer> logger)
    {
        _logger = logger;
    }

    public Task Consume(ConsumeContext<SimpleMessage> context)
    {
        _logger.LogInformation("Consumed");

        return Task.CompletedTask;
    }
}