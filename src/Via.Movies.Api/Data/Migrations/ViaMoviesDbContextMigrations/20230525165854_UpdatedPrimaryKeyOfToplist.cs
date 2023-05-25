using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Via.Movies.Api.Data.Migrations.ViaMoviesDbContextMigrations
{
    /// <inheritdoc />
    public partial class UpdatedPrimaryKeyOfToplist : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_toplist_movie_movie_id",
                table: "toplist_movie");

            migrationBuilder.AddPrimaryKey(
                name: "PK_toplist_movie",
                table: "toplist_movie",
                columns: new[] { "movie_id", "user_email" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_toplist_movie",
                table: "toplist_movie");

            migrationBuilder.CreateIndex(
                name: "IX_toplist_movie_movie_id",
                table: "toplist_movie",
                column: "movie_id");
        }
    }
}
