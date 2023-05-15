using Via.Movies.Api.Models;

namespace Via.Movies.Api.Repositories
{
    public interface IMovieRepository
    {
        Task<IEnumerable<Movie>> GetAllMoviesAsync();
        Task<Movie?> GetMovieAsync(int id);
        Task<IEnumerable<Movie?>> SearchForMovieByTitle(string title);
        Task<IEnumerable<Movie?>> SearchForMovieByPeople(string name);
        Task<Movie> CreateMovieAsync(Movie movie);
        Task<Movie?> UpdateMovieAsync(Movie movie);
        Task DeleteMovieAsync(int id);
    }
}