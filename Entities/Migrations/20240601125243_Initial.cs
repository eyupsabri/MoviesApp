using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Entities.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MovieCategory = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IMDBstar = table.Column<double>(type: "float", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContentRating = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TrailerURL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageURL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BannerURL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MovieLength = table.Column<int>(type: "int", nullable: false),
                    Plot = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NickName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MovieCategories",
                columns: table => new
                {
                    MovieId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieCategories", x => new { x.MovieId, x.CategoryId });
                    table.ForeignKey(
                        name: "FK_MovieCategories_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovieCategories_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MoviesReviews",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    MovieId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Star = table.Column<int>(type: "int", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MoviesReviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MoviesReviews_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MoviesReviews_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserReviews",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AuthorId = table.Column<int>(type: "int", nullable: false),
                    ReviewedUserId = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Star = table.Column<double>(type: "float", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserReviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserReviews_Users_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserReviews_Users_ReviewedUserId",
                        column: x => x.ReviewedUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "MovieCategory" },
                values: new object[,]
                {
                    { 1, 0 },
                    { 2, 1 },
                    { 3, 2 },
                    { 4, 3 },
                    { 5, 4 },
                    { 6, 5 },
                    { 7, 7 },
                    { 8, 8 },
                    { 9, 9 },
                    { 10, 10 },
                    { 11, 11 },
                    { 12, 12 },
                    { 13, 13 },
                    { 14, 14 },
                    { 15, 15 },
                    { 16, 16 },
                    { 17, 17 },
                    { 18, 18 },
                    { 19, 19 },
                    { 20, 20 },
                    { 21, 21 },
                    { 22, 22 },
                    { 23, 23 },
                    { 24, 24 },
                    { 25, 25 },
                    { 26, 26 }
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "BannerURL", "ContentRating", "Description", "IMDBstar", "ImageURL", "MovieLength", "Plot", "Title", "TrailerURL", "Year" },
                values: new object[,]
                {
                    { "tt0175142", "https://m.media-amazon.com/images/M/MV5BMGEzZjdjMGQtZmYzZC00N2I4LThiY2QtNWY5ZmQ3M2ExZmM4XkEyXkFqcGdeQXVyMTQxNzMzNDI@._V1_.jpg", "R", "A group of teenagers including Cindy Campbell and Bobby Prinze, accidentally hit a man when driving, and dispose of the body, but now they are being stalked by a very recognisable masked killer. The victim count increases, whilst Cindy must survive the carnage that has she has seen in so many films before.", 6.2000000000000002, "https://m.media-amazon.com/images/M/MV5BMGEzZjdjMGQtZmYzZC00N2I4LThiY2QtNWY5ZmQ3M2ExZmM4XkEyXkFqcGdeQXVyMTQxNzMzNDI@._V1_UX182_CR0,0,182,268_AL_.jpg", 88, "A year after disposing of the body of a man they accidentally killed, a group of dumb teenagers are stalked by a bumbling serial killer.", "Scary Movie", "https://www.youtube.com/embed/SzpGYrrcJZw", 2000 },
                    { "tt0181875", "https://m.media-amazon.com/images/M/MV5BMzY1ZjMwMGEtYTY1ZS00ZDllLTk0ZmUtYzA3ZTA4NmYwNGNkXkEyXkFqcGdeQXVyNDk3NzU2MTQ@._V1_.jpg", "R", "The early 1970s. William Miller is 15-years old and an aspiring rock journalist. He gets a job writing for Rolling Stone magazine. His first assignment: tour with the band Stillwater and write about the experience. Miller will get to see what goes on behind the scenes in a famous band, including the moments when things fall apart. Moreover, for him, it will be a period of new experiences and finding himself.", 7.9000000000000004, "https://m.media-amazon.com/images/M/MV5BMzY1ZjMwMGEtYTY1ZS00ZDllLTk0ZmUtYzA3ZTA4NmYwNGNkXkEyXkFqcGdeQXVyNDk3NzU2MTQ@._V1_UX182_CR0,0,182,268_AL_.jpg", 98, "A high-school boy is given the chance to write a story for Rolling Stone Magazine about an up-and-coming rock band as he accompanies them on their concert tour.", "Almost Famous", "https://www.youtube.com/embed/aQXh_AaJXaM", 2000 },
                    { "tt0187078", "https://m.media-amazon.com/images/M/MV5BMTIwMzExNDEwN15BMl5BanBnXkFtZTYwODMxMzg2._V1_.jpg", "PG-13", "In exchange for his little brother's life, the reformed car thief, Randall \"Memphis\" Raines, has to do the impossible: in less than three days, he has to steal not one, but fifty exotic supercars for the ruthless crime lord, Ray Calitri. To stand a chance of pulling off this intricate and time-sensitive grand theft auto, once more, Memphis has to rely on his old gang--his knowledgeable mentor, Otto; the old friends, Sphinx and Donny; his reluctant ex-girlfriend, Sway, and a band of tech-savvy young thieves--however, the police are already onto them. Now, fast Lamborghinis, precious Ferraris, luxurious Porsches, and Eleanor--a rare Ford Shelby Mustang GT500--are just some of the cars in Raines' long list. Can Memphis execute the perfect car heist?", 6.5, "https://m.media-amazon.com/images/M/MV5BMTIwMzExNDEwN15BMl5BanBnXkFtZTYwODMxMzg2._V1_UX182_CR0,0,182,268_AL_.jpg", 118, "A retired master car thief must come back to the industry and steal fifty cars with his crew in one night to save his brother's life.", "Gone in Sixty Seconds", "https://www.youtube.com/embed/ap5RqRzjS6g", 2000 },
                    { "tt0190590", "https://m.media-amazon.com/images/M/MV5BMjZkOTdmMWItOTkyNy00MDdjLTlhNTQtYzU3MzdhZjA0ZDEyXkEyXkFqcGdeQXVyMTMxODk2OTU@._V1_.jpg", "PG-13", "Loosely based on Homer's \"Odyssey,\" the movie deals with the picaresque adventures of Ulysses Everett McGill and his companions Delmar and Pete in 1930s Mississipi. Sprung from a chain gang and trying to reach Everett's home to recover the buried loot of a bank heist they are confronted by a series of strange characters--among them sirens, a cyclops, bank robber George \"Baby Face\" Nelson (very annoyed by that nickname), a campaigning governor and his opponent, a KKK lynch mob, and a blind prophet who warns the trio that \"the treasure you seek shall not be the treasure you find.\"", 7.7000000000000002, "https://m.media-amazon.com/images/M/MV5BMjZkOTdmMWItOTkyNy00MDdjLTlhNTQtYzU3MzdhZjA0ZDEyXkEyXkFqcGdeQXVyMTMxODk2OTU@._V1_UX182_CR0,0,182,268_AL_.jpg", 107, "In the deep south during the 1930s, three escaped convicts search for hidden treasure while a relentless lawman pursues them.", "O Brother, Where Art Thou?", "https://www.youtube.com/embed/eW9Xo2HtlJI", 2000 },
                    { "tt0204946", "https://m.media-amazon.com/images/M/MV5BNjhiMjk1YWYtMjgyYy00YTFhLTk0NTMtN2Q5MDZjMWEyYWI1XkEyXkFqcGdeQXVyMTQxNzMzNDI@._V1_.jpg", "PG-13", "The Toro cheerleading squad from Rancho Carne High School in San Diego has got spirit, spunk, sass and a killer routine that's sure to land them the national championship trophy for the sixth year in a row. But for newly-elected team captain Torrance, the Toros' road to total cheer glory takes a shady turn when she discovers that their perfectly-choreographed routines were in fact stolen from the Clovers, a hip-hop squad from East Compton, by the Toro's former captain. While the Toros scramble to come up with a new routine, the Clovers, led by squad captain Isis have their own problems - coming up with enough money to cover their travel expenses to the championships. With time running out and the pressure mounting, both captains drive their squads to the point of exhaustion: Torrance, hell bent on saving the Toros' reputation, and Isis more determined than ever to see that the Clovers finally get the recognition that they deserve. But only one team can bring home the title, so may the...", 6.0, "https://m.media-amazon.com/images/M/MV5BNjhiMjk1YWYtMjgyYy00YTFhLTk0NTMtN2Q5MDZjMWEyYWI1XkEyXkFqcGdeQXVyMTQxNzMzNDI@._V1_UX182_CR0,0,182,268_AL_.jpg", 90, "A champion high school cheerleading squad discovers its previous captain stole all their best routines from an inner-city school and must scramble to compete at this year's championships.", "Bring It On", "https://www.youtube.com/embed/Pg0UYb8U2Dg", 2000 },
                    { "tt0210945", "https://m.media-amazon.com/images/M/MV5BYThkMzgxNjEtMzFiOC00MTI0LWI5MDItNDVmYjA4NzY5MDQ2L2ltYWdlL2ltYWdlXkEyXkFqcGdeQXVyMTQxNzMzNDI@._V1_.jpg", "PG", "Suburban Virginia schools have been segregated for generations. One Black and one White high school are closed and the students sent to T.C. Williams High School under federal mandate to integrate. The year is seen through the eyes of the football team where the man hired to coach the Black school is made head coach over the highly successful white coach. Based on the actual events of 1971, the team becomes the unifying symbol for the community as the boys and the adults learn to depend on and trust each other.", 7.7999999999999998, "https://m.media-amazon.com/images/M/MV5BYThkMzgxNjEtMzFiOC00MTI0LWI5MDItNDVmYjA4NzY5MDQ2L2ltYWdlL2ltYWdlXkEyXkFqcGdeQXVyMTQxNzMzNDI@._V1_UX182_CR0,0,182,268_AL_.jpg", 113, "The true story of a newly appointed African-American coach and his high school team on their first season as a racially integrated unit.", "Remember the Titans", "https://www.youtube.com/embed/35MvdHBWjwU", 2000 },
                    { "tt0218839", "https://m.media-amazon.com/images/M/MV5BMTQ5OTc0NDU1MF5BMl5BanBnXkFtZTYwNzk1OTI3._V1_.jpg", "PG-13", "At the prestigious Mayflower Dog Show, a \"documentary film crew\" captures the excitement and tension displayed by the eccentric participants in the outrageously hilarious satire Best In Show. This biting send-up exposes the wondrously diverse dog owners who travel from all over America to showcase their four-legged contenders. Mild-mannered salesman Gerry Fleck (Eugene Levy) and his vivacious wife, Cookie (Catherine O'Hara), happily prepare their Norwich Terrier, while shop owner Harlan Pepper (Christopher Guest) hopes his Bloodhound wins top prize. As two upwardly mobile attorneys (Parker Posey and Michael Hitchcock) anxiously ready their neurotic Weimaraner and an ecstatically happy gay couple (Michael McKean and John Michael Higgins) dote on their tiny Shih Tzu, inept commentator Buck Laughlin (Fred Willard) vainly attempts to provide colorful tidbits about each breed.", 7.5, "https://m.media-amazon.com/images/M/MV5BMTQ5OTc0NDU1MF5BMl5BanBnXkFtZTYwNzk1OTI3._V1_UX182_CR0,0,182,268_AL_.jpg", 90, "A behind-the-scenes look into the highly competitive and cut-throat world of dog shows through the eyes of a group of ruthless dog owners.", "Best in Show", "https://www.youtube.com/embed/94y9n9lNy2Y", 2000 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "BirthDate", "Email", "Name", "NickName", "Password" },
                values: new object[] { 1, new DateTime(1992, 12, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "husnu.cemre@gmail.com", "Hüsnü Cemre", "trc10", "123Abc." });

            migrationBuilder.InsertData(
                table: "MovieCategories",
                columns: new[] { "CategoryId", "MovieId" },
                values: new object[,]
                {
                    { 6, "tt0175142" },
                    { 1, "tt0181875" },
                    { 5, "tt0181875" },
                    { 6, "tt0181875" },
                    { 19, "tt0181875" },
                    { 4, "tt0187078" },
                    { 9, "tt0187078" },
                    { 10, "tt0187078" },
                    { 1, "tt0190590" },
                    { 4, "tt0190590" },
                    { 6, "tt0190590" },
                    { 19, "tt0190590" },
                    { 6, "tt0204946" },
                    { 8, "tt0204946" },
                    { 13, "tt0204946" },
                    { 5, "tt0210945" },
                    { 8, "tt0210945" },
                    { 14, "tt0210945" },
                    { 1, "tt0218839" }
                });

            migrationBuilder.InsertData(
                table: "MoviesReviews",
                columns: new[] { "Id", "Created", "Description", "MovieId", "Star", "Title", "UserId" },
                values: new object[] { 1, new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Phasellus tincidunt molestie massa quis vulputate. Pellentesque mollis egestas lectus, in tempus lorem scelerisque vitae. Donec fermentum quam nec ligula sollicitudin, quis tincidunt orci laoreet. Donec ut tincidunt tortor. Integer eget neque pellentesque risus varius gravida ac sit amet augue. Morbi tristique risus nec augue venenatis, id viverra dolor lobortis. Curabitur malesuada enim libero, nec tincidunt sem varius at. Proin id auctor magna, in pellentesque quam. In hac habitasse platea dictumst. Donec suscipit rutrum risus. Maecenas tristique lorem et nisl ullamcorper, at iaculis nisl laoreet. Etiam sed gravida felis, quis fringilla nisi. Maecenas in urna dolor. Nullam tincidunt varius vestibulum.", "tt0218839", 10, "Flawless", 1 });

            migrationBuilder.CreateIndex(
                name: "IX_MovieCategories_CategoryId",
                table: "MovieCategories",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_MoviesReviews_MovieId",
                table: "MoviesReviews",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_MoviesReviews_UserId",
                table: "MoviesReviews",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserReviews_AuthorId",
                table: "UserReviews",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_UserReviews_ReviewedUserId",
                table: "UserReviews",
                column: "ReviewedUserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MovieCategories");

            migrationBuilder.DropTable(
                name: "MoviesReviews");

            migrationBuilder.DropTable(
                name: "UserReviews");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Movies");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
