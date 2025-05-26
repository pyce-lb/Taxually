namespace Taxually.TechnicalTest
{
    public class TaxuallyHttpClient
    {
        public Task PostAsync<TRequest>(string url, TRequest request, CancellationToken cancellationToken = default)
        {
            // Actual HTTP call removed for purposes of this exercise
            return Task.CompletedTask;
        }
    }
}
