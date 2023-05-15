namespace Via.Movies.Api.Dtos;

public class UpdateRatingRequest
{
    public required int MovieId { get; set; }
    public required float Rating1 { get; set; }
    public required int Votes { get; set; }
}
