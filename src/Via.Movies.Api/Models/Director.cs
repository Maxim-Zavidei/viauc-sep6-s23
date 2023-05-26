namespace Via.Movies.Api.Models;

public class Director
{
	public required long MovieId { get; set; }
	public required long PersonId { get; set; }

	public required virtual Movie Movie { get; set; }
	public required virtual Person Person { get; set; }
}
