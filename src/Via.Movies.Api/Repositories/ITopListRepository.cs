using Via.Movies.Api.Models;

namespace Via.Movies.Api.Repositories;

public interface ITopListRepository
{
	Task<IEnumerable<Movie>> GetAllTopListMoviesOfUser(string email);
	Task<bool> ToggleMovieToUserTopList(string email, long movieId);
}
