using Microsoft.EntityFrameworkCore;
using Via.Movies.Api.Models;

namespace Via.Movies.Api.Data;

public class ViaMoviesDbContext : DbContext
{
    public ViaMoviesDbContext()
    {
    }

    public ViaMoviesDbContext(DbContextOptions<ViaMoviesDbContext> options) : base(options)
    {
    }

    public required virtual DbSet<Director> Directors { get; set; }
    public required virtual DbSet<Movie> Movies { get; set; }
    public required virtual DbSet<Person> People { get; set; }
    public required virtual DbSet<Rating> Ratings { get; set; }
    public required virtual DbSet<Star> Stars { get; set; }
	public required virtual DbSet<TopListMovie> TopListMovies { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Director>(entity =>
        {
            entity.HasNoKey();
            entity.ToTable("directors");

            entity.Property(e => e.MovieId).HasColumnName("movie_id");
            entity.Property(e => e.PersonId).HasColumnName("person_id");

            entity.HasOne(d => d.Movie)
                .WithMany()
                .HasForeignKey(d => d.MovieId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Person)
                .WithMany()
                .HasForeignKey(d => d.PersonId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<Movie>(entity =>
        {
            entity.ToTable("movies");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");

            entity.Property(e => e.Title).HasColumnName("title");

            entity.Property(e => e.Year)
                .HasColumnType("NUMERIC")
                .HasColumnName("year");
        });

        modelBuilder.Entity<Person>(entity =>
        {
            entity.ToTable("people");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");

            entity.Property(e => e.Birth)
                .HasColumnType("NUMERIC")
                .HasColumnName("birth");

            entity.Property(e => e.Name).HasColumnName("name");
        });

        modelBuilder.Entity<Rating>(entity =>
        {
            entity.HasNoKey();
            entity.ToTable("ratings");

            entity.Property(e => e.MovieId).HasColumnName("movie_id");
            entity.Property(e => e.RatingValue).HasColumnName("rating");
            entity.Property(e => e.Votes).HasColumnName("votes");

            entity.HasOne(d => d.Movie)
                .WithMany()
                .HasForeignKey(d => d.MovieId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<Star>(entity =>
        {
            entity.HasNoKey();
            entity.ToTable("stars");

            entity.Property(e => e.MovieId).HasColumnName("movie_id");
            entity.Property(e => e.PersonId).HasColumnName("person_id");

            entity.HasOne(d => d.Movie)
                .WithMany()
                .HasForeignKey(d => d.MovieId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Person)
                .WithMany()
                .HasForeignKey(d => d.PersonId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

		modelBuilder.Entity<TopListMovie>(entity =>
        {
            entity.HasNoKey();
            entity.ToTable("toplist_movie");

            entity.Property(e => e.MovieId).HasColumnName("movie_id");
            entity.Property(e => e.UserEmail).HasColumnName("user_email");

            entity.HasOne(d => d.Movie)
                .WithMany()
                .HasForeignKey(d => d.MovieId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });
    }
}
