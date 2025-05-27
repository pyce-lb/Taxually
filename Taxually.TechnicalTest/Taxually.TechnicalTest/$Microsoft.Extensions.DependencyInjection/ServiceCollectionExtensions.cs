using Taxually.TechnicalTest.Mappings;

namespace Microsoft.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApi(this IServiceCollection services)
    {
        services.AddSingleton<VatRegistrationRequestMapper>();
        return services;
    }
}
