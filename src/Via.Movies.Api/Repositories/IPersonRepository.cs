using Via.Movies.Api.Models;

namespace Via.Movies.Api.Repositories;

public interface IPersonRepository
{
	Task<IEnumerable<Person>> GetAllPeopleAsync();
	Task<Person> CreatePersonAsync(Person person);
	Task<Person?> UpdatePersonAsync(Person person);
}
