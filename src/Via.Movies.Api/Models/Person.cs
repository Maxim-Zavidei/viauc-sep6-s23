namespace Via.Movies.Api.Models;

public class Person
{
    public required long Id { get; set; }
    public required string Name { get; set; }
    public required int? Birth { get; set; }
}
