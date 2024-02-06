using MassTransit;
using MassTransit.Mediator;

namespace MassTransitMediator
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            IMediator mediator = Bus.Factory.CreateMediator(config =>
            {
                config.Consumer<SubmitOrderConsumer>();
                config.Consumer<OrderStatusConsumer>();

                //var handle = mediator.ConnectConsumer<SubmitOrderConsumer>();
            });

            Guid orderId = NewId.NextGuid();

            await mediator.Send<SubmitOrder>(new { OrderId = orderId });

            var client = mediator.CreateRequestClient<GetOrderStatus>();

            var response = await client.GetResponse<OrderStatus>(new { OrderId = orderId });

            Console.WriteLine($"Order status {0}", response.Message.Status);
        }
    }

    public interface GetOrderStatus
    {
        Guid OrderId { get; }
    }

    public interface SubmitOrder
    {
        Guid OrderId { get; }
    }

    public interface OrderStatus
    {
        Guid OrderId { get; }
        string Status { get; }
    }

    class OrderStatusConsumer : IConsumer<GetOrderStatus>
    {
        public async Task Consume(ConsumeContext<GetOrderStatus> context)
        {
            await context.RespondAsync<OrderStatus>(new
            {
                context.Message.OrderId,
                Status = "Pending"
            });
        }
    }

    class SubmitOrderConsumer : IConsumer<SubmitOrder>
    {
        public async Task Consume(ConsumeContext<SubmitOrder> context)
        {
            await context.RespondAsync<SubmitOrder>(new
            {
                context.Message.OrderId
            });
        }
    }
}