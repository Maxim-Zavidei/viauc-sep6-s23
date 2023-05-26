using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using Via.Movies.Api.Dtos;
using Via.Movies.Api.Models;
using Via.Movies.Api.Repositories;

namespace Via.Movies.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MovieController : ControllerBase
{
    private IMovieRepository movieRepository;
	private IDirectorRepository directorRepository;
	private IRatingRepository ratingRepository;
    private IStarRepository starRepository;

    public MovieController(IMovieRepository movieRepository, IDirectorRepository directorRepository, IRatingRepository ratingRepository, IStarRepository starRepository)
    {
        this.movieRepository = movieRepository;
		this.directorRepository = directorRepository;
		this.ratingRepository = ratingRepository;
        this.starRepository = starRepository;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<GetMovieRequest>>> GetSomeMoviesAsync([FromQuery] int? number)
    {
		if (number == null) number = 25;
		var movies = await movieRepository.GetSomeMoviesAsync(number.Value);

		List<GetMovieRequest> response = new List<GetMovieRequest>();

		foreach (Movie movie in movies)
		{
			var personDirector = await directorRepository.GetDirectorOfMovie(movie.Id);

			var averageRating = await ratingRepository.GetAverageRatingOfMovie(movie.Id);
			response.Add(new GetMovieRequest
			{
				Id = movie.Id,
				Title = movie.Title,
				Year = movie.Year,
				AverageRating = averageRating,
				DirectorId = personDirector == null ? null : personDirector.Id,
				DirectorName = personDirector == null ? null : personDirector.Name,
				DirectorBirth = personDirector == null ? null : personDirector.Birth
			});
		}
        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetMovieRequest>> GetMovieAsync(int id)
    {
        var movie = await movieRepository.GetMovieAsync(id);
        if (movie == null)
        {
            return NotFound();
        }

		var personDirector = await directorRepository.GetDirectorOfMovie(id);

			var averageRating = await ratingRepository.GetAverageRatingOfMovie(id);
            List<GetStarRequest> stars = new List<GetStarRequest>();
			return new GetMovieRequest
			{
				Id = movie.Id,
				Title = movie.Title,
				Year = movie.Year,
				AverageRating = averageRating,
				DirectorId = personDirector == null ? null : personDirector.Id,
				DirectorName = personDirector == null ? null : personDirector.Name,
				DirectorBirth = personDirector == null ? null : personDirector.Birth,
                
			};
    }

    [HttpGet("search")]
    public async Task<ActionResult<IEnumerable<GetMovieRequest>>> SearchForMovieAsync([FromQuery] string query)
    {
		var movies = await movieRepository.SearchForMovie(query);

		List<GetMovieRequest> response = new List<GetMovieRequest>();

		foreach (Movie movie in movies)
		{
			var personDirector = await directorRepository.GetDirectorOfMovie(movie.Id);

			var averageRating = await ratingRepository.GetAverageRatingOfMovie(movie.Id);
			response.Add(new GetMovieRequest
			{
				Id = movie.Id,
				Title = movie.Title,
				Year = movie.Year,
				AverageRating = averageRating,
				DirectorId = personDirector == null ? null : personDirector.Id,
				DirectorName = personDirector == null ? null : personDirector.Name,
				DirectorBirth = personDirector == null ? null : personDirector.Birth
			});
		}
        return Ok(response);
    }

    [HttpPut]
    [Consumes(MediaTypeNames.Application.Json)]
    public async Task<ActionResult<Movie>> CreateMovieAsync([FromBody] Movie movie)
    {
        var movieNew = await movieRepository.CreateMovieAsync(new Movie
        {
            Id = -1,
            Title = movie.Title,
            Year = movie.Year
        });
        return Ok(movieNew);
    }

    [HttpPost]
    [Consumes(MediaTypeNames.Application.Json)]
    public async Task<ActionResult<Movie>> UpdateMovieAsync([FromBody] Movie movie)
    {
        var movieUpdated = await movieRepository.UpdateMovieAsync(movie);
        if (movieUpdated == null)
        {
            return NotFound();
        }
        return Ok(movieUpdated);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteMovieAsync(int id)
    {
        await movieRepository.DeleteMovieAsync(id);
        return Ok();
    }
}
