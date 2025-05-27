namespace Taxually.TechnicalTest.Application;

public interface ITaxuallyQueueClient
{
    public Task EnqueueAsync<TPayload>(string queueName, TPayload payload, CancellationToken cancellationToken = default);
}
