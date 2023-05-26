namespace Via.Movies.Api.Models;

public class Rating
{
	public required long MovieId { get; set; }
	public required double RatingValue { get; set; }
	public required long Votes { get; set; }

	public required virtual Movie Movie { get; set; }
}
