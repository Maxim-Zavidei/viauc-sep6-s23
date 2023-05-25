using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Via.Movies.Api.Data.Migrations.ViaMoviesDbContextMigrations
{
    /// <inheritdoc />
    public partial class AddedTopLists : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "toplist_movie",
                columns: table => new
                {
                    user_email = table.Column<string>(type: "text", nullable: false),
                    movie_id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_toplist_movie_movies_movie_id",
                        column: x => x.movie_id,
                        principalTable: "movies",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_toplist_movie_movie_id",
                table: "toplist_movie",
                column: "movie_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "toplist_movie");
        }
    }
}
