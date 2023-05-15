using Microsoft.EntityFrameworkCore;
using Via.Movies.Api.Models;

namespace Via.Movies.Api.Data;

public partial class ViaMoviesDbContext : DbContext
{
    public ViaMoviesDbContext()
    {
    }

    public ViaMoviesDbContext(DbContextOptions<ViaMoviesDbContext> options) : base(options)
    {
    }

    public virtual DbSet<Director> Directors { get; set; } = null!;
    public virtual DbSet<Movie> Movies { get; set; } = null!;
    public virtual DbSet<Person> People { get; set; } = null!;
    public virtual DbSet<Rating> Ratings { get; set; } = null!;
    public virtual DbSet<Star> Stars { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Director>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("directors");

            entity.Property(e => e.MovieId).HasColumnName("movie_id");
            entity.Property(e => e.PersonId).HasColumnName("person_id");
        });

        modelBuilder.Entity<Movie>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("movies");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Title).HasColumnName("title");
            entity.Property(e => e.Year).HasColumnName("year");
        });

        modelBuilder.Entity<Person>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("people");

            entity.Property(e => e.Birth).HasColumnName("birth");
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name).HasColumnName("name");
        });

        modelBuilder.Entity<Rating>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("ratings");

            entity.Property(e => e.MovieId).HasColumnName("movie_id");
            entity.Property(e => e.Rating1).HasColumnName("rating");
            entity.Property(e => e.Votes).HasColumnName("votes");
        });

        modelBuilder.Entity<Star>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("stars");

            entity.Property(e => e.MovieId).HasColumnName("movie_id");
            entity.Property(e => e.PersonId).HasColumnName("person_id");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
