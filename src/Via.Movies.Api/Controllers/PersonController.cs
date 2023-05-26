using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using Via.Movies.Api.Dtos;
using Via.Movies.Api.Models;
using Via.Movies.Api.Repositories;

namespace Via.Movies.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PersonController : ControllerBase
{
	private IPersonRepository personRepository;

	public PersonController(IPersonRepository personRepository)
	{
		this.personRepository = personRepository;
	}

	[HttpGet]
	public async Task<ActionResult<IEnumerable<Person>>> GetAllPeopleAsync()
	{
		return Ok(await personRepository.GetAllPeopleAsync());
	}

	[HttpPut]
    [Consumes(MediaTypeNames.Application.Json)]
    public async Task<ActionResult<Person>> AddPersonAsync([FromBody] AddPersonRequest request)
    {
		var person = await personRepository.CreatePersonAsync(new Person
		{
			Id = -1,
			Name = request.Name,
			Birth = (int?)request.Birth
		});
        return Ok(request);
    }

	[HttpPost]
    [Consumes(MediaTypeNames.Application.Json)]
    public async Task<ActionResult<Person>> UpdatePersonAsync(UpdatePersonRequest request)
    {
        var person = await personRepository.UpdatePersonAsync(new Person
		{
			Id = request.Id,
			Name = request.Name,
			Birth = (int?)request.Birth
		});

        if (person == null)
        {
            return BadRequest("A person with the provided person id does not exist.");
        }
        return Ok(person);
    }
}
