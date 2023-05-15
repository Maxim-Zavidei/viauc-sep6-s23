namespace Via.Movies.Api.Models;

public partial class Rating
{
    public required int MovieId { get; set; }
    public required float Rating1 { get; set; }
    public required int Votes { get; set; }
}
