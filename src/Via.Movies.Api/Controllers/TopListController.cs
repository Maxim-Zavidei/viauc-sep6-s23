using Microsoft.AspNetCore.Mvc;
using Via.Movies.Api.Dtos;
using Via.Movies.Api.Models;
using Via.Movies.Api.Repositories;

namespace Via.TopLists.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TopListController : ControllerBase
{
    private ITopListRepository topListRepository;
	private IDirectorRepository directorRepository;
	private IRatingRepository ratingRepository;

    public TopListController(ITopListRepository topListRepository, IDirectorRepository directorRepository, IRatingRepository ratingRepository)
    {
        this.topListRepository = topListRepository;
		this.directorRepository = directorRepository;
		this.ratingRepository = ratingRepository;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<GetTopListMovieRequest>>> GetAllTopListsOfUserAsync([FromQuery] string email)
    {
		var movies = await topListRepository.GetAllTopListMoviesOfUser(email);

		List<GetTopListMovieRequest> response = new List<GetTopListMovieRequest>();

		foreach (Movie movie in movies)
		{
			var personDirector = await directorRepository.GetDirectorOfMovie(movie.Id);

			var averageRating = await ratingRepository.GetAverageRatingOfMovie(movie.Id);
			response.Add(new GetTopListMovieRequest
			{
				Id = movie.Id,
				Title = movie.Title,
				Year = movie.Year,
				AverageRating = averageRating,
				DirectorId = personDirector == null ? null : personDirector.Id,
				DirectorName = personDirector == null ? null : personDirector.Name,
				DirectorBirth = personDirector == null ? null : personDirector.Birth,
				isFavorite = true
			});
		}
        return Ok(response);
    }

    [HttpPost]
    public async Task<ActionResult<bool>> ToggleMovieToUserTopList([FromBody] AddTopListMovieRequest request)
    {
        var added = await topListRepository.ToggleMovieToUserTopList(request.UserEmail, request.MovieId);
		return Ok(added);
    }
}
