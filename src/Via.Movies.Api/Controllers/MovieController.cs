using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using Via.Movies.Api.Models;
using Via.Movies.Api.Repositories;

namespace Via.Movies.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MovieController : ControllerBase
{
    private IMovieRepository movieRepository;

    public MovieController(IMovieRepository movieRepository)
    {
        this.movieRepository = movieRepository;
    }
    
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Movie>>> GetAllMoviesAsync()
    {
        return Ok(await movieRepository.GetAllMoviesAsync());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Movie>> GetMovieAsync(int id)
    {
        var movie = await movieRepository.GetMovieAsync(id);
        if (movie == null)
        {
            return NotFound();
        }
        return Ok(movie);
    }

    [HttpGet("search")]
    public async Task<ActionResult<IEnumerable<Movie>>> SearchForMovieAsync([FromQuery] string? title, [FromQuery] string? name)
    {
        if (title != null)
        {
            return Ok(await movieRepository.SearchForMovieByTitle(title));
        }
        else if (name != null)
        {
            return Ok(await movieRepository.SearchForMovieByPeople(name));
        }
        else
        {
            return BadRequest("You must provide a title or a name to search for.");
        }
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