namespace Via.Movies.Api.Dtos;

public class GetTopListMovieRequest
{
	public required long Id { get; set; }
    public required string Title { get; set; }
    public required long Year { get; set; }

    public required double AverageRating { get; set; }

	public long? DirectorId { get; set; }
	public string? DirectorName { get; set; }
    public long? DirectorBirth { get; set; }

	public required bool isFavorite { get; set; }
}
