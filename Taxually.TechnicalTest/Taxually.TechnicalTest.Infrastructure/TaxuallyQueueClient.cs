using System.Threading;

namespace Taxually.TechnicalTest
{
    public class TaxuallyQueueClient
    {
        public Task EnqueueAsync<TPayload>(string queueName, TPayload payload, CancellationToken cancellationToken = default)
        {
            // Code to send to message queue removed for brevity
            return Task.CompletedTask;
        }
    }
}
