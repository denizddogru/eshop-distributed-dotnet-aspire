namespace ServiceDefaults.Messaging.Events;
public class IntegrationEvent
{
    public Guid EventId => Guid.NewGuid();
    public DateTime OccurredOn => DateTime.UtcNow;
    public string EventType => GetType().Name;
}
