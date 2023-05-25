namespace Via.Movies.Api.Models;

public class Movie
{
	public required long Id { get; set; }
	public required string Title { get; set; }
	public required int Year { get; set; }
}
