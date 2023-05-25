// using System.Net.Mime;
// using Microsoft.AspNetCore.Mvc;
// using Via.Movies.Api.Dtos;
// using Via.Movies.Api.Models;
// using Via.Movies.Api.Repositories;

// namespace Via.Movies.Api.Controllers;

// [ApiController]
// [Route("api/[controller]")]
// public class StarController : ControllerBase
// {
// 	private IStarRepository starRepository;

// 	public StarController(IStarRepository starRepository)
// 	{
// 		this.starRepository = starRepository;
// 	}

// 	[HttpGet]
// 	public async Task<ActionResult<IEnumerable<Star>>> GetAllStarsAsync()
// 	{
// 		return Ok(await starRepository.GetAllStarsAsync());
// 	}

// 	[HttpPut]
//     [Consumes(MediaTypeNames.Application.Json)]
//     public async Task<ActionResult<Star>> AddStarAsync([FromBody] AddStarRequest request)
//     {
// 		var star = await starRepository.CreateStarAsync(new Star
// 		{
// 			MovieId = request.MovieId,
// 			PersonId = request.PersonId
// 		});

// 		if (star == null)
//         {
//             return BadRequest("A person with the provided person id does not exist or a movie with the provided movie id does not exist.");
//         }
//         return Ok(star);
//     }
// }
