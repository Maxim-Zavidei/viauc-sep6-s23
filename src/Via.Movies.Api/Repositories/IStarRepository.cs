using Via.Movies.Api.Models;

namespace Via.Movies.Api.Repositories;

public interface IStarRepository
{
	Task<IEnumerable<Star>> GetAllStarsAsync();
	Task<Star> CreateStarAsync(Star star);
}
