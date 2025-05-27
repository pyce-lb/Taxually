using Taxually.TechnicalTest.Application.VatRegistration;

namespace Microsoft.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddSingleton<VatRegistrationCommandHandlerFactory>();
        return services;
    }
}
