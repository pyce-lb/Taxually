namespace Taxually.TechnicalTest.Application;

public interface ITaxuallyHttpClient
{
    public Task PostAsync<TRequest>(string url, TRequest request, CancellationToken cancellationToken = default);
}
