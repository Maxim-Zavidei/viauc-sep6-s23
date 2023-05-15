using Via.Movies.Api.Models;

namespace Via.Movies.Api.Repositories;

public interface IDirectorRepository
{
	Task<IEnumerable<Director>> GetAllDirectorsAsync();
	Task<Director> CreateDirectorAsync(Director director);
}
