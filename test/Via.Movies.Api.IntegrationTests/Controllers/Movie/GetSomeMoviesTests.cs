using Microsoft.Extensions.DependencyInjection;
using Via.Movies.Api.Data;
using Via.Movies.Api.IntegrationTests.Helpers;
using Xunit;

namespace Via.Movies.Api.IntegrationTests.Controllers;

// One class is named the same as class under test.
public class MovieControllerTests : IClassFixture<CustomWebApplicationFactory>
{
    private protected readonly CustomWebApplicationFactory applicationFactory;
    private protected readonly HttpClient httpClient;

    public MovieControllerTests(CustomWebApplicationFactory applicationFactory)
    {
        this.applicationFactory = applicationFactory;
        this.httpClient = applicationFactory.CreateClient();
    }

    // One nested test class per method to test from the class under test.
    public class GetAllDetailedAsyncTests : MovieControllerTests
    {
        public GetAllDetailedAsyncTests(CustomWebApplicationFactory applicationFactory) : base(applicationFactory)
        {
        }

        // One test method per test case of the method under test.
        [Theory]
        [MemberData(nameof(MovieControllerTestsDataSource.GetSomeMoviesShouldRespondExpectedJson), MemberType = typeof(MovieControllerTestsDataSource))]
        public async Task ShouldRespondExpectedJson(string expected, Action<ViaMoviesDbContext> seedTestingDatabase)
        {
            // Arrange
            using (var scope = applicationFactory.Services.CreateScope())
            {
                var scopedServices = scope.ServiceProvider;
                var context = scopedServices.GetRequiredService<ViaMoviesDbContext>();

                context.Database.EnsureDeleted();
                seedTestingDatabase(context);
            }

            // Act
            var response = await httpClient.GetAsync("api/movie");

            // Assert
            response.EnsureSuccessStatusCode();
            string actualJson = await response.Content.ReadAsStringAsync();
            Assert.Equal("application/json; charset=utf-8", response.Content.Headers.ContentType!.ToString());
            Assert.Equal(expected, actualJson);
        }
    }
}
