using Microsoft.EntityFrameworkCore;
using Via.Movies.Api.Data;
using Via.Movies.Api.Models;

namespace Via.Movies.Api.Repositories;

public class PersonRepository : IPersonRepository
{
	private ViaMoviesDbContext dbContext { get; set; }

	public PersonRepository(ViaMoviesDbContext dbContext)
	{
		this.dbContext = dbContext;
	}

	public async Task<IEnumerable<Person>> GetAllPeopleAsync()
	{
		return await dbContext.People.ToListAsync();
	}

	public async Task<Person> CreatePersonAsync(Person person)
	{
		var newPerson = await dbContext.People.AddAsync(person);
		await dbContext.SaveChangesAsync();
		return newPerson.Entity;
	}

	public async Task<Person?> UpdatePersonAsync(Person person)
	{
		if (!(await dbContext.People.AnyAsync(e => e.Id == person.Id)))
		{
			return null;
		}
		Person updatedPerson = dbContext.Update(person).Entity;
		return updatedPerson;
	}
}
