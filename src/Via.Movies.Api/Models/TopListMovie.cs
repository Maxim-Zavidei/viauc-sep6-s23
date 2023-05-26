namespace Via.Movies.Api.Models;

public class TopListMovie
{
	public required string UserEmail { get; set; }
	public required long MovieId { get; set; }

	public virtual Movie Movie { get; set; } = null!;
}
