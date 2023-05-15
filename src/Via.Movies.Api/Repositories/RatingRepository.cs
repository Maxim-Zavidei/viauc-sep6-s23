using Microsoft.EntityFrameworkCore;
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

	public async Task<Rating?> UpdateRatingAsync(Rating rating)
	{
		if (rating.Rating1 < 0) return null;


		Rating? foundRating = await dbContext.Ratings.FirstOrDefaultAsync(e => e.MovieId == rating.MovieId && e.Rating1 == rating.Rating1);
		Rating updatedRating;
		if (foundRating != null)
		{
			updatedRating = dbContext.Update(new Rating
			{
				MovieId = foundRating.MovieId,
				Rating1 = foundRating.Rating1,
				Votes = foundRating.Votes + 1
			}).Entity;
		}
		else
		{
			await dbContext.AddAsync(new Rating
			{
				MovieId = foundRating.MovieId,
				Rating1 = foundRating.Rating1,
				Votes = foundRating.Votes + 1
			});
			updatedRating = rating;
		}
		return updatedRating;
	}
}
