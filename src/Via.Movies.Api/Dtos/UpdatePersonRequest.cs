namespace Via.Movies.Api.Dtos;

public class UpdatePersonRequest
{
	public required int Id { get; set; }
	public required string Name { get; set; }
    public required long Birth { get; set; }
}
