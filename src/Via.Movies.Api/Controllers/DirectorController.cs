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
}
