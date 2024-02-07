namespace MassTransitIntro.Contracts
{
    public interface SubmitOrder
    {
        public Guid OrderId { get; }

        public DateTime Timestamp { get; }

        public string CustomerNumber { get; }

    }
}