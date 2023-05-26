using Microsoft.AspNetCore.Mvc;
using Via.Movies.Api.Models;
using Via.Movies.Api.Repositories;

namespace Via.Movies.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RatingController : ControllerBase
{
	private IRatingRepository ratingRepository;

	public RatingController(IRatingRepository ratingRepository)
	{
		this.ratingRepository = ratingRepository;
	}

	[HttpGet]
	public async Task<ActionResult<IEnumerable<Rating>>> GetAllRatingsAsync()
	{
		return Ok(await ratingRepository.GetAllRatingsAsync());
	}
}
