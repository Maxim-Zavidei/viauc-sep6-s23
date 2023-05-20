using Microsoft.EntityFrameworkCore;
using Via.Movies.Api.Data;
using Via.Movies.Api.Models;

namespace Via.Movies.Api.Repositories;

public class MovieRepository : IMovieRepository
{
    private ViaMoviesDbContext _context { get; set; }

    public MovieRepository(ViaMoviesDbContext context)
    {
        _context = context;
    }
	public async Task<Movie> CreateMovieAsync(Movie movie)
	{
		var result = await _context.Movies.AddAsync(movie);
        await _context.SaveChangesAsync();
        return result.Entity;
	}

	public async Task DeleteMovieAsync(int id)
	{
		var movie = await _context.Movies.FirstOrDefaultAsync(e => e.Id == id);
        if (movie == null)
        {
            throw new Exception("Movie not found");
        }
        _context.Movies.Remove(movie);
        await _context.SaveChangesAsync();
	}

	public async Task<IEnumerable<Movie>> GetSomeMoviesAsync(int number)
	{
		var rand = new Random();
		var skip = (int)(rand.NextDouble() * (_context.Movies.Count() - number));
		return await _context.Movies.OrderBy(e => e.Id).Skip(skip).Take(number).ToListAsync();
	}

	public async Task<Movie?> GetMovieAsync(int id)
	{
		return await _context.Movies.FirstOrDefaultAsync(e => e.Id == id);
	}

	public  Task<IEnumerable<Movie?>> SearchForMovieByPeople(string name)
	{
		throw new NotImplementedException();
	}

	public async Task<IEnumerable<Movie?>> SearchForMovieByTitle(string title)
	{
		return await _context.Movies.Where(m => m.Title.Contains(title)).ToListAsync();
	}

	public async Task<Movie?> UpdateMovieAsync(Movie movie)
	{
		if (!(await _context.Movies.AnyAsync(m => m.Id == movie.Id)))
        {
            throw new Exception("Movie not found");
        }
        _context.Movies.Update(movie);
        await _context.SaveChangesAsync();
        return movie;
	}
}
