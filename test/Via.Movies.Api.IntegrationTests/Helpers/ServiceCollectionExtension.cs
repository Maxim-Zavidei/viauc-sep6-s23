using Microsoft.Extensions.DependencyInjection;

namespace Via.Movies.Api.IntegrationTests.Helpers;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection Remove<TService>(this IServiceCollection services)
    {
        var descriptor = services.SingleOrDefault(e => e.ServiceType == typeof(TService));

        if (descriptor != null)
        {
            services.Remove(descriptor);
        }

        return services;
    }
}
