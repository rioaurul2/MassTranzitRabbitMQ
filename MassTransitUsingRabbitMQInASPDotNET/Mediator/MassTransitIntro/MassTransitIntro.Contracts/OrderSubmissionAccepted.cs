namespace MassTransitIntro.Contracts
{
    public interface OrderSubmissionAccepted
    {
        string CustomerNumber { get; }
        Guid OrderId { get; }
        DateTime Timestamp { get; }
    }
}