using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using Via.Movies.Api.Dtos;
using Via.Movies.Api.Models;
using Via.Movies.Api.Repositories;

namespace Via.Movies.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StarController : ControllerBase
{
	private IStarRepository starRepository;

	public StarController(IStarRepository starRepository)
	{
		this.starRepository = starRepository;
	}

	[HttpGet]
	public async Task<ActionResult<IEnumerable<Star>>> GetAllStarsAsync()
	{
		return Ok(await starRepository.GetAllStarsAsync());
	}

    [HttpGet("{movieId}")]
    public async Task<IEnumerable<Star>> GetStarsForMovieAsync(long movieId)
    {
        return await starRepository.GetStarsForMovieAsync(movieId);
    }

}
