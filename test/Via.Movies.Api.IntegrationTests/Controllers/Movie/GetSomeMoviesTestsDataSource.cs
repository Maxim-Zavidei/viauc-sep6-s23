using Via.Movies.Api.Data;
using Via.Movies.Api.Models;
using Xunit;

namespace Via.Movies.Api.IntegrationTests.Controllers;

public class MovieControllerTestsDataSource
{
    public static Movie[] MovieDataSet() {
        return new Movie[] {
            new() {
                Id = 1,
				Title = "Test Movie 1",
				Year = 2003
            },
            new() {
                Id = 2,
				Title = "Test Movie 2",
				Year = 1998
            },
			new() {
                Id = 3,
				Title = "Test Movie 3",
				Year = 2000
            },
			new() {
                Id = 4,
				Title = "Test Movie 4",
				Year = 2001
            }
        };
    }

    public static TheoryData<string, Action<ViaMoviesDbContext>> GetSomeMoviesShouldRespondExpectedJson => new()
    {
        {
            """[{"id":1,"title":"Test Movie 1","year":2003,"averageRating":0,"directorId":null,"directorName":null,"directorBirth":null},{"id":2,"title":"Test Movie 2","year":1998,"averageRating":0,"directorId":null,"directorName":null,"directorBirth":null},{"id":3,"title":"Test Movie 3","year":2000,"averageRating":0,"directorId":null,"directorName":null,"directorBirth":null},{"id":4,"title":"Test Movie 4","year":2001,"averageRating":0,"directorId":null,"directorName":null,"directorBirth":null}]""",
            (ViaMoviesDbContext context) => {
                context.Movies.AddRange(MovieDataSet());
                context.SaveChanges();
            }
        },
        {
           """[{"id":1,"title":"Test Movie 1","year":2003,"averageRating":0,"directorId":null,"directorName":null,"directorBirth":null},{"id":2,"title":"Test Movie 2","year":1998,"averageRating":0,"directorId":null,"directorName":null,"directorBirth":null},{"id":3,"title":"Test Movie 3","year":2000,"averageRating":0,"directorId":null,"directorName":null,"directorBirth":null},{"id":4,"title":"Test Movie 4","year":2001,"averageRating":0,"directorId":null,"directorName":null,"directorBirth":null}]""",
            (ViaMoviesDbContext context) => {
                context.Movies.AddRange(MovieDataSet());
                context.SaveChanges();
            }
        }
    };
}
