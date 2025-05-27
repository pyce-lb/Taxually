using Taxually.TechnicalTest.Application;
using Taxually.TechnicalTest.Application.VatRegistration;
using Taxually.TechnicalTest.Infrastructure;

namespace Microsoft.Extensions.DependencyInjection;

/// <summary>
/// Infrastructure layer related extension methods for <see cref="IServiceCollection"/>.
/// </summary>
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Adds Infrastructure layer services.
    /// </summary>
    /// <param name="services">The <see cref="IServiceCollection"/> to register services to.</param>
    /// <returns>The <see cref="IServiceCollection"/> so that additional calls can be chained.</returns>
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddSingleton<ITaxuallyHttpClient, TaxuallyHttpClient>();
        services.AddSingleton<ITaxuallyQueueClient, TaxuallyQueueClient>();

        services.AddSingleton<ICsvSerializer<VatRegistrationCommand>, VatRegistrationCsvSerializer>();
        services.AddSingleton<IXmlSerializer<VatRegistrationCommand>, XmlSerializer<VatRegistrationCommand>>();
        return services;
    }
}
