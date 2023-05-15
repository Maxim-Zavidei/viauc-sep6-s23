using Via.Movies.Api.Models;

namespace Via.Movies.Api.Repositories;

public interface IRatingRepository
{
	Task<IEnumerable<Rating>> GetAllRatingsAsync();
	Task<Rating?> UpdateRatingAsync(Rating Rating);
}
