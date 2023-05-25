using Via.Movies.Api.Models;

namespace Via.Movies.Api.Repositories;

public interface IRatingRepository
{
	Task<IEnumerable<Rating>> GetAllRatingsAsync();
	Task<double> GetAverageRatingOfMovie(long movieId);
}
