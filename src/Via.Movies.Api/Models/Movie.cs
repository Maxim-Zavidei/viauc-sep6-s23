﻿namespace Via.Movies.Api.Models;

public partial class Movie
{
    public required int Id { get; set; }
    public required string Title { get; set; }
    public required long Year { get; set; }
}