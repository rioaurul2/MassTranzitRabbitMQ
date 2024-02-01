using MassTransit;
using Model;

public class OrderConsumer : IConsumer<Order>
{
    readonly ILogger<OrderConsumer> _logger;

    public OrderConsumer(ILogger<OrderConsumer> logger)
    {
        _logger = logger;
    }

    public async Task Consume(ConsumeContext<Order> context)
    {
        _logger.LogInformation("Consumer Order Started");

        await Console.Out.WriteLineAsync(context.Message.Name);

        _logger.LogInformation("Consumer Order Ended");
    }
}