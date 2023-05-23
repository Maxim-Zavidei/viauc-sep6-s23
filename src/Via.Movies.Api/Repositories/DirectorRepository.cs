using Microsoft.EntityFrameworkCore;
using Via.Movies.Api.Data;
using Via.Movies.Api.Models;

namespace Via.Movies.Api.Repositories;

public class DirectorRepository : IDirectorRepository
{
	private ViaMoviesDbContext dbContext { get; set; }

	public DirectorRepository(ViaMoviesDbContext dbContext)
	{
		this.dbContext = dbContext;
	}
	public async Task<IEnumerable<Director>> GetAllDirectorsAsync()
	{
		return await dbContext.Directors.ToListAsync();
	}

	public async Task<Person?> GetDirectorOfMovie(int movieId)
	{
		var director = await dbContext.Directors.FirstOrDefaultAsync(e => e.MovieId == movieId);

		if (director == null) return null;
		var personDirector = await dbContext.People.FirstOrDefaultAsync(e => e.Id == director.PersonId);
		return personDirector;
	}

	public async Task<Director> CreateDirectorAsync(Director director)
	{
		if ((await dbContext.People.AnyAsync(e => e.Id == director.PersonId)))
		{
			return null;
		}
		if ((await dbContext.Movies.AnyAsync(e => e.Id == director.MovieId)))
		{
			return null;
		}
		var newDirector = await dbContext.Directors.AddAsync(director);
		await dbContext.SaveChangesAsync();
		return newDirector.Entity;
	}
}
