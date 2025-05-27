using Taxually.TechnicalTest.Application.VatRegistration;

namespace Microsoft.Extensions.DependencyInjection;

/// <summary>
/// Application layer related extension methods for <see cref="IServiceCollection"/>.
/// </summary>
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Adds Application layer services.
    /// </summary>
    /// <param name="services">The <see cref="IServiceCollection"/> to register services to.</param>
    /// <returns>The <see cref="IServiceCollection"/> so that additional calls can be chained.</returns>
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddSingleton<VatRegistrationCommandHandlerFactory>();
        return services;
    }
}
