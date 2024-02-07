using MassTransit;
using MassTransitIntro.Contracts;

namespace MassTransitIntro.Components.Consumers
{
    public class SubmitOrderConsumer : IConsumer<SubmitOrder>
    {
        public async Task Consume(ConsumeContext<SubmitOrder> context)
        {
            await context.RespondAsync<OrderSubmissionAccepted>(new {InVar.Timestamp});
        }
    }
}
