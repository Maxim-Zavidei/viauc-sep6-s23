using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Via.Movies.Api.Data.Migrations.ViaMoviesDbContextMigrations
{
    /// <inheritdoc />
    public partial class RetryCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "movies",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false),
                    title = table.Column<string>(type: "text", nullable: false),
                    year = table.Column<decimal>(type: "NUMERIC", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_movies", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "people",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    birth = table.Column<decimal>(type: "NUMERIC", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_people", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "ratings",
                columns: table => new
                {
                    movie_id = table.Column<long>(type: "bigint", nullable: false),
                    rating = table.Column<double>(type: "double precision", nullable: false),
                    votes = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_ratings_movies_movie_id",
                        column: x => x.movie_id,
                        principalTable: "movies",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "directors",
                columns: table => new
                {
                    movie_id = table.Column<long>(type: "bigint", nullable: false),
                    person_id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_directors_movies_movie_id",
                        column: x => x.movie_id,
                        principalTable: "movies",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_directors_people_person_id",
                        column: x => x.person_id,
                        principalTable: "people",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "stars",
                columns: table => new
                {
                    movie_id = table.Column<long>(type: "bigint", nullable: false),
                    person_id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_stars_movies_movie_id",
                        column: x => x.movie_id,
                        principalTable: "movies",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_stars_people_person_id",
                        column: x => x.person_id,
                        principalTable: "people",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_directors_movie_id",
                table: "directors",
                column: "movie_id");

            migrationBuilder.CreateIndex(
                name: "IX_directors_person_id",
                table: "directors",
                column: "person_id");

            migrationBuilder.CreateIndex(
                name: "IX_ratings_movie_id",
                table: "ratings",
                column: "movie_id");

            migrationBuilder.CreateIndex(
                name: "IX_stars_movie_id",
                table: "stars",
                column: "movie_id");

            migrationBuilder.CreateIndex(
                name: "IX_stars_person_id",
                table: "stars",
                column: "person_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "directors");

            migrationBuilder.DropTable(
                name: "ratings");

            migrationBuilder.DropTable(
                name: "stars");

            migrationBuilder.DropTable(
                name: "movies");

            migrationBuilder.DropTable(
                name: "people");
        }
    }
}
