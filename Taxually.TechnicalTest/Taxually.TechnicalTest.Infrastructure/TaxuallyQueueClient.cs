using Taxually.TechnicalTest.Application;

namespace Taxually.TechnicalTest.Infrastructure
{
    public sealed class TaxuallyQueueClient : ITaxuallyQueueClient
    {
        public Task EnqueueAsync<TPayload>(string queueName, TPayload payload, CancellationToken cancellationToken = default)
        {
            // Code to send to message queue removed for brevity
            return Task.CompletedTask;
        }
    }
}
