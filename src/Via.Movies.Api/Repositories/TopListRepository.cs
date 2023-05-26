using Microsoft.EntityFrameworkCore;
using Via.Movies.Api.Data;
using Via.Movies.Api.Models;

namespace Via.Movies.Api.Repositories;

public class TopListRepository : ITopListRepository
{
	private ViaMoviesDbContext dbContext { get; set; }

	public TopListRepository(ViaMoviesDbContext dbContext)
	{
		this.dbContext = dbContext;
	}

	public async Task<IEnumerable<Movie>> GetAllTopListMoviesOfUser(string email)
	{
		var topLists = await dbContext.TopListMovies.Include(e => e.Movie).Where(e => e.UserEmail == email).ToListAsync();
		return topLists.Select(e => e.Movie);
	}

	public async Task<bool> ToggleMovieToUserTopList(string email, long movieId)
	{
		var exists = await dbContext.Movies.AnyAsync(e => e.Id == movieId);
		if (!exists) return false;

		exists = await dbContext.TopListMovies.AnyAsync(e => e.MovieId == movieId && e.UserEmail == email);
		if (exists)
		{
			var topListMovie = await dbContext.TopListMovies.FirstOrDefaultAsync(e => e.MovieId == movieId && e.UserEmail == email);
			if (topListMovie == null) return false;

			dbContext.TopListMovies.Remove(topListMovie);
			await dbContext.SaveChangesAsync();
			return true;
		}

		await dbContext.TopListMovies.AddAsync(new TopListMovie
		{
			UserEmail = email,
			MovieId = movieId
		});
		await dbContext.SaveChangesAsync();
		return true;
	}
}
