using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using Via.Movies.Api.Dtos;
using Via.Movies.Api.Models;
using Via.Movies.Api.Repositories;

namespace Via.Movies.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DirectorController : ControllerBase
{
	private IDirectorRepository directorRepository;

	public DirectorController(IDirectorRepository directorRepository)
	{
		this.directorRepository = directorRepository;
	}

	[HttpGet]
	public async Task<ActionResult<IEnumerable<Director>>> GetAllDirectorsAsync()
	{
		return Ok(await directorRepository.GetAllDirectorsAsync());
	}

	[HttpPut]
    [Consumes(MediaTypeNames.Application.Json)]
    public async Task<ActionResult<Director>> AddDirectorAsync([FromBody] AddDirectorRequest request)
    {
		var director = await directorRepository.CreateDirectorAsync(new Director
		{
			MovieId = request.MovieId,
			PersonId = request.PersonId
		});

		if (director == null)
        {
            return BadRequest("A person with the provided person id does not exist or a movie with the provided movie id does not exist.");
        }
        return Ok(director);
    }
}
