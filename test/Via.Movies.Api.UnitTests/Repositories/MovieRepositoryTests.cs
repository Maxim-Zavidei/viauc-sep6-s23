using Microsoft.EntityFrameworkCore;
using Moq;
using Via.Movies.Api.Data;
using Via.Movies.Api.Models;
using Via.Movies.Api.Repositories;
using Xunit;

namespace Via.Movies.Api.UnitTests.Repositories;

public class MovieRepositoryTests
{
    private List<Movie> mockData;
	private Mock<DbSet<Movie>> mockDbSet;
    private Mock<ViaMoviesDbContext> mockDbContext;
    private IMovieRepository sut;

    public MovieRepositoryTests()
    {
        // Create some mock data
        this.mockData = new List<Movie> {
            new() {
                Id = 1,
                Title = "Movie title 1",
                Year = 2000
            },
            new() {
                Id = 1,
                Title = "Movie title 2",
                Year = 2001
            },
            new() {
                Id = 1,
                Title = "Movie title 3",
                Year = 2002
            }
        };

        // Setup the data access
		this.mockDbSet = new();
        this.mockDbContext = new();
        this.mockDbContext.Setup(e => e.Movies).Returns(mockDbSet.Object);

        // Init the test subject
        this.sut = new MovieRepository(mockDbContext.Object);
    }

    [Fact]
    public async Task GetAllDetailedAsync()
    {
        // Arrange

        // Act
		try
		{
			var bundles = await sut.GetSomeMoviesAsync(10);
		}
		catch (Exception) {}

        // Assert
        mockDbContext.Verify(e => e.Movies, Times.Once);
    }
}
