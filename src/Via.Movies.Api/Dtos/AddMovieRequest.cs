namespace Via.Movies.Api.Dtos
{
    public class AddMovieRequest
    {
        public required int MovieId { get; set; }
        public required string Title { get; set; }
        public required int Year { get; set; }
    }
}