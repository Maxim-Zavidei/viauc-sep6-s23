using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using Via.Movies.Api.Dtos;
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

	[HttpPost]
    [Consumes(MediaTypeNames.Application.Json)]
    public async Task<ActionResult<Rating>> UpdateRatingAsync(UpdateRatingRequest request)
    {
        var rating = await ratingRepository.UpdateRatingAsync(new Rating
		{
			MovieId = request.MovieId,
			Rating1 = request.Rating1,
			Votes = request.Votes
		});

        if (rating == null)
        {
            return BadRequest("Rating can not be negative.");
        }
        return Ok(rating);
    }
}
