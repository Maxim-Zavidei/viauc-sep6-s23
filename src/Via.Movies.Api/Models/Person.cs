namespace Via.Movies.Api.Models;

public partial class Person
{
    public required int Id { get; set; }
    public required string Name { get; set; }
    public required long Birth { get; set; }
}
