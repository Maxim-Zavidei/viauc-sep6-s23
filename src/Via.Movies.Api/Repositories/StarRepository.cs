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

	public async Task<Star> CreateStarAsync(Star star)
	{
		if ((await dbContext.People.AnyAsync(e => e.Id == star.PersonId)))
		{
			return null;
		}
		if ((await dbContext.Movies.AnyAsync(e => e.Id == star.MovieId)))
		{
			return null;
		}
		var newStar = await dbContext.Stars.AddAsync(star);
		await dbContext.SaveChangesAsync();
		return newStar.Entity;
	}
}
