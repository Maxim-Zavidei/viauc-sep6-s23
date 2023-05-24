using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Via.Movies.Api.Data;

namespace Via.Movies.Api.IntegrationTests.Helpers;

public class CustomWebApplicationFactory : WebApplicationFactory<Program>
{
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.UseEnvironment("Development");
        builder.ConfigureServices(services =>
        {
            // "Hijack" the real DbContext in DI container and replace it with an in-memory database for testing during runtime.
            services
                .Remove<DbContextOptions<ViaMoviesDbContext>>()
                .AddDbContext<ViaMoviesDbContext>(opt =>
                {
                    opt.UseInMemoryDatabase($"{this.GetHashCode()}");
                });
        });
    }
}
