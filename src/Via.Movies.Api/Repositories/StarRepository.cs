using Microsoft.EntityFrameworkCore;
using Via.Movies.Api.Data;
using Via.Movies.Api.Models;

namespace Via.Movies.Api.Repositories;

public class StarRepository : IStarRepository
{
	private ViaMoviesDbContext dbContext { get; set; }

	public StarRepository(ViaMoviesDbContext dbContext)
	{
		this.dbContext = dbContext;
	}
	public async Task<IEnumerable<Star>> GetAllStarsAsync()
	{
		return await dbContext.Stars.ToListAsync();
	}

	public async Task<IEnumerable<Star>> GetStarsForMovieAsync(long movieId)
	{
		return await dbContext.Stars.Include(e => e.Person).Where(e => e.MovieId == movieId).ToListAsync();
	}
}
