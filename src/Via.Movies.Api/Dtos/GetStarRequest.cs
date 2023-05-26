namespace Via.Movies.Api.Dtos
{
  public class GetStarRequest
  {
    public long MovieId { get; set; }
    public long PersonId { get; set; }
    public string? PersonName { get; set; }
    public long? PersonBirth { get; set; }
  }
}