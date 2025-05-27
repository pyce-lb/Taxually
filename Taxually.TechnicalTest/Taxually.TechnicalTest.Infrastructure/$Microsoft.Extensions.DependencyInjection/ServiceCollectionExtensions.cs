using Taxually.TechnicalTest.Application;
using Taxually.TechnicalTest.Application.VatRegistration;
using Taxually.TechnicalTest.Infrastructure;

namespace Microsoft.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddSingleton<ITaxuallyHttpClient, TaxuallyHttpClient>();
        services.AddSingleton<ITaxuallyQueueClient, TaxuallyQueueClient>();

        services.AddKeyedSingleton<ISerializer<VatRegistrationCommand>, VatRegistrationCsvSerializer>(ISerializer.CsvKey);
        services.AddKeyedSingleton<ISerializer<VatRegistrationCommand>, XmlSerializer<VatRegistrationCommand>>(ISerializer.XmlKey);
        return services;
    }
}
