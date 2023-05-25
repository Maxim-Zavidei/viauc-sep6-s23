namespace Via.Movies.Api.Dtos;

public class UpdateRatingRequest
{
    public required int MovieId { get; set; }
    public required double RatingValue { get; set; }
    public required int Votes { get; set; }
}
