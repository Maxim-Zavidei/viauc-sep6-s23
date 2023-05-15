namespace Via.Movies.Api.Dtos;

public class AddStarRequest
{
    public required int MovieId { get; set; }
    public required int PersonId { get; set; }
}
