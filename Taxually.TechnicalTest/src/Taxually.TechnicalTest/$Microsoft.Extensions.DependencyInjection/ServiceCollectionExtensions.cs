using Taxually.TechnicalTest.Mappings;

namespace Microsoft.Extensions.DependencyInjection;
/// <summary>
/// API layer related extension methods for <see cref="IServiceCollection"/>.
/// </summary>
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Adds API layer services.
    /// </summary>
    /// <param name="services">The <see cref="IServiceCollection"/> to register services to.</param>
    /// <returns>The <see cref="IServiceCollection"/> so that additional calls can be chained.</returns>
    public static IServiceCollection AddApi(this IServiceCollection services)
    {
        services.AddSingleton<VatRegistrationRequestMapper>();
        return services;
    }
}
