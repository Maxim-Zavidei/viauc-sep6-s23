using Microsoft.EntityFrameworkCore;
using Npgsql.Internal.TypeHandlers;
using Via.Movies.Api.Data;
using Via.Movies.Api.Models;

namespace Via.Movies.Api.Repositories;

public class RatingRepository : IRatingRepository
{
	private ViaMoviesDbContext dbContext { get; set; }

	public RatingRepository(ViaMoviesDbContext dbContext)
	{
		this.dbContext = dbContext;
	}

	public async Task<IEnumerable<Rating>> GetAllRatingsAsync()
	{
		return await dbContext.Ratings.ToListAsync();
	}

	public async Task<double> GetAverageRatingOfMovie(long movieId)
	{
		var rating = await dbContext.Ratings.Where(e => e.MovieId == movieId).FirstOrDefaultAsync();

		if (rating == null)
		{
			return 0;
		}
		else
		{
			return rating.RatingValue;
		}
	}
}
