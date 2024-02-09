using MassTransit;
using MassTransitIntro.Contracts;
using Microsoft.Extensions.Logging;

namespace MassTransitIntro.Components.Consumers
{
    public class SubmitOrderConsumer : IConsumer<SubmitOrder>
    {
        readonly ILogger<SubmitOrderConsumer> _logger;

        public SubmitOrderConsumer(ILogger<SubmitOrderConsumer> logger)
        {
                _logger = logger;
        }

        public async Task Consume(ConsumeContext<SubmitOrder> context)
        {
            _logger.LogInformation("SubmitOrderConsumer:{CustomNumber}", context.Message.CustomerNumber);

            if (context.Message.CustomerNumber.ToLower().Contains("Test".ToLower()))
            {
                await context.RespondAsync<OrderSubmissionRejected>(new
                {
                    InVar.Timestamp,
                    context.Message.CustomerNumber,
                    context.Message.OrderId,
                    Reason = $"Test Customer cannot submit orders: {context.Message.CustomerNumber}"
                });

                return;
            }

            await context.RespondAsync<OrderSubmissionAccepted>(new
            {
                InVar.Timestamp,
                context.Message.CustomerNumber,
                context.Message.OrderId
            });
        }
    }
}
