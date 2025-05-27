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

        services.AddSingleton<ICsvSerializer<VatRegistrationCommand>, VatRegistrationCsvSerializer>();
        services.AddSingleton<IXmlSerializer<VatRegistrationCommand>, XmlSerializer<VatRegistrationCommand>>();
        return services;
    }
}
