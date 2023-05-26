namespace Via.Movies.Api.Dtos;

public class AddDirectorRequest
{
    public required int MovieId { get; set; }
    public required int PersonId { get; set; }
}
