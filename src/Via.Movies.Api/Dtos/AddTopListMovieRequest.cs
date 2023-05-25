namespace Via.Movies.Api.Dtos;

public class AddTopListMovieRequest
{
	public required string UserEmail { get; set; }
	public required long MovieId { get; set; }
}
