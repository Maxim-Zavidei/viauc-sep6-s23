using Via.Movies.Api.Models;

namespace Via.Movies.Api.Repositories
{
    public interface IMovieRepository
    {
        Task<IEnumerable<Movie>> GetSomeMoviesAsync(int number);
        Task<Movie?> GetMovieAsync(int id);
        Task<List<Movie>> SearchForMovie(string query);
        Task<Movie> CreateMovieAsync(Movie movie);
        Task<Movie?> UpdateMovieAsync(Movie movie);
        Task DeleteMovieAsync(int id);
    }
}
