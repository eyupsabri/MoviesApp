using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Entities.Enums.DBEnums;
using static System.Net.WebRequestMethods;

namespace Entities
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<MovieReview> MoviesReviews { get; set; }
        public DbSet<UserReview> UserReviews { get; set; }
        public DbSet<MovieCategory> MovieCategories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MovieCategory>().HasKey(mc => new { mc.MovieId, mc.CategoryId });
            modelBuilder.Entity<MovieCategory>()
                .HasOne(mc => mc.Movie)
                .WithMany(m => m.MovieCategories)
                .HasForeignKey(mc => mc.MovieId);
            modelBuilder.Entity<MovieCategory>()
                .HasOne(mc => mc.Category)
                .WithMany(m => m.MovieCategories)
                .HasForeignKey(mc => mc.CategoryId);

            modelBuilder.Entity<MovieReview>()
             .HasOne(mr => mr.User)
             .WithMany(u => u.MovieReviews)
             .HasForeignKey(mr => mr.UserId);
            modelBuilder.Entity<MovieReview>()
               .HasOne(mr => mr.Movie)
               .WithMany(m => m.Reviews)
               .HasForeignKey(mr => mr.MovieId);

            modelBuilder.Entity<UserReview>()
            .HasOne(ur => ur.Author)
            .WithMany(u => u.UserReviews)
            .HasForeignKey(ur => ur.AuthorId)
            .OnDelete(DeleteBehavior.Restrict);  // To avoid cascading delete issues

            modelBuilder.Entity<UserReview>()
            .HasOne(ur => ur.ReviewedUser)
            .WithMany()
            .HasForeignKey(ur => ur.ReviewedUserId)
            .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Movie>().HasData(new Movie
            {
                Id = "tt0218839",
                IMDBstar = 7.5,
                Plot = "A behind-the-scenes look into the highly competitive and cut-throat world of dog shows through the eyes of a group of ruthless dog owners.",
                BannerURL = "https://m.media-amazon.com/images/M/MV5BMTQ5OTc0NDU1MF5BMl5BanBnXkFtZTYwNzk1OTI3._V1_.jpg",
                ImageURL = "https://m.media-amazon.com/images/M/MV5BMTQ5OTc0NDU1MF5BMl5BanBnXkFtZTYwNzk1OTI3._V1_UX182_CR0,0,182,268_AL_.jpg",
                TrailerURL = "https://www.youtube.com/embed/94y9n9lNy2Y",
                ContentRating = "PG-13",
                Description = "At the prestigious Mayflower Dog Show, a \"documentary film crew\" captures the excitement and tension displayed by the eccentric participants in the outrageously hilarious satire Best In Show. This biting send-up exposes the wondrously diverse dog owners who travel from all over America to showcase their four-legged contenders. Mild-mannered salesman Gerry Fleck (Eugene Levy) and his vivacious wife, Cookie (Catherine O'Hara), happily prepare their Norwich Terrier, while shop owner Harlan Pepper (Christopher Guest) hopes his Bloodhound wins top prize. As two upwardly mobile attorneys (Parker Posey and Michael Hitchcock) anxiously ready their neurotic Weimaraner and an ecstatically happy gay couple (Michael McKean and John Michael Higgins) dote on their tiny Shih Tzu, inept commentator Buck Laughlin (Fred Willard) vainly attempts to provide colorful tidbits about each breed.",
                Year = 2000,
                Title = "Best in Show",
                MovieLength = 90
            },
            new Movie
            {
                Id = "tt0204946",
                IMDBstar = 6,
                Plot = "A champion high school cheerleading squad discovers its previous captain stole all their best routines from an inner-city school and must scramble to compete at this year's championships.",
                BannerURL = "https://m.media-amazon.com/images/M/MV5BNjhiMjk1YWYtMjgyYy00YTFhLTk0NTMtN2Q5MDZjMWEyYWI1XkEyXkFqcGdeQXVyMTQxNzMzNDI@._V1_.jpg",
                ImageURL = "https://m.media-amazon.com/images/M/MV5BNjhiMjk1YWYtMjgyYy00YTFhLTk0NTMtN2Q5MDZjMWEyYWI1XkEyXkFqcGdeQXVyMTQxNzMzNDI@._V1_UX182_CR0,0,182,268_AL_.jpg",
                TrailerURL = "https://www.youtube.com/embed/Pg0UYb8U2Dg",
                ContentRating = "PG-13",
                Description = "The Toro cheerleading squad from Rancho Carne High School in San Diego has got spirit, spunk, sass and a killer routine that's sure to land them the national championship trophy for the sixth year in a row. But for newly-elected team captain Torrance, the Toros' road to total cheer glory takes a shady turn when she discovers that their perfectly-choreographed routines were in fact stolen from the Clovers, a hip-hop squad from East Compton, by the Toro's former captain. While the Toros scramble to come up with a new routine, the Clovers, led by squad captain Isis have their own problems - coming up with enough money to cover their travel expenses to the championships. With time running out and the pressure mounting, both captains drive their squads to the point of exhaustion: Torrance, hell bent on saving the Toros' reputation, and Isis more determined than ever to see that the Clovers finally get the recognition that they deserve. But only one team can bring home the title, so may the...",
                Year = 2000,
                Title = "Bring It On",
                MovieLength = 90
            },
            new Movie
            {
                Id = "tt0181875",
                IMDBstar = 7.9,
                Plot = "A high-school boy is given the chance to write a story for Rolling Stone Magazine about an up-and-coming rock band as he accompanies them on their concert tour.",
                BannerURL = "https://m.media-amazon.com/images/M/MV5BMzY1ZjMwMGEtYTY1ZS00ZDllLTk0ZmUtYzA3ZTA4NmYwNGNkXkEyXkFqcGdeQXVyNDk3NzU2MTQ@._V1_.jpg",
                ImageURL = "https://m.media-amazon.com/images/M/MV5BMzY1ZjMwMGEtYTY1ZS00ZDllLTk0ZmUtYzA3ZTA4NmYwNGNkXkEyXkFqcGdeQXVyNDk3NzU2MTQ@._V1_UX182_CR0,0,182,268_AL_.jpg",
                TrailerURL = "https://www.youtube.com/embed/aQXh_AaJXaM",
                ContentRating = "R",
                Description = "The early 1970s. William Miller is 15-years old and an aspiring rock journalist. He gets a job writing for Rolling Stone magazine. His first assignment: tour with the band Stillwater and write about the experience. Miller will get to see what goes on behind the scenes in a famous band, including the moments when things fall apart. Moreover, for him, it will be a period of new experiences and finding himself.",
                Year = 2000,
                Title = "Almost Famous",
                MovieLength = 98
            },
            new Movie
            {
                Id = "tt0187078",
                IMDBstar = 6.5,
                Plot = "A retired master car thief must come back to the industry and steal fifty cars with his crew in one night to save his brother's life.",
                BannerURL = "https://m.media-amazon.com/images/M/MV5BMTIwMzExNDEwN15BMl5BanBnXkFtZTYwODMxMzg2._V1_.jpg",
                ImageURL = "https://m.media-amazon.com/images/M/MV5BMTIwMzExNDEwN15BMl5BanBnXkFtZTYwODMxMzg2._V1_UX182_CR0,0,182,268_AL_.jpg",
                TrailerURL = "https://www.youtube.com/embed/ap5RqRzjS6g",
                ContentRating = "PG-13",
                Description = "In exchange for his little brother's life, the reformed car thief, Randall \"Memphis\" Raines, has to do the impossible: in less than three days, he has to steal not one, but fifty exotic supercars for the ruthless crime lord, Ray Calitri. To stand a chance of pulling off this intricate and time-sensitive grand theft auto, once more, Memphis has to rely on his old gang--his knowledgeable mentor, Otto; the old friends, Sphinx and Donny; his reluctant ex-girlfriend, Sway, and a band of tech-savvy young thieves--however, the police are already onto them. Now, fast Lamborghinis, precious Ferraris, luxurious Porsches, and Eleanor--a rare Ford Shelby Mustang GT500--are just some of the cars in Raines' long list. Can Memphis execute the perfect car heist?",
                Year = 2000,
                Title = "Gone in Sixty Seconds",
                MovieLength = 118

            },
            new Movie
            {
                Id = "tt0175142",
                IMDBstar = 6.2,
                Plot = "A year after disposing of the body of a man they accidentally killed, a group of dumb teenagers are stalked by a bumbling serial killer.",
                BannerURL = "https://m.media-amazon.com/images/M/MV5BMGEzZjdjMGQtZmYzZC00N2I4LThiY2QtNWY5ZmQ3M2ExZmM4XkEyXkFqcGdeQXVyMTQxNzMzNDI@._V1_.jpg",
                ImageURL = "https://m.media-amazon.com/images/M/MV5BMGEzZjdjMGQtZmYzZC00N2I4LThiY2QtNWY5ZmQ3M2ExZmM4XkEyXkFqcGdeQXVyMTQxNzMzNDI@._V1_UX182_CR0,0,182,268_AL_.jpg",
                TrailerURL = "https://www.youtube.com/embed/SzpGYrrcJZw",
                ContentRating = "R",
                Description = "A group of teenagers including Cindy Campbell and Bobby Prinze, accidentally hit a man when driving, and dispose of the body, but now they are being stalked by a very recognisable masked killer. The victim count increases, whilst Cindy must survive the carnage that has she has seen in so many films before.",
                Year = 2000,
                Title = "Scary Movie",
                MovieLength = 88
            },
            new Movie
            {
                Id = "tt0210945",
                IMDBstar = 7.8,
                Plot = "The true story of a newly appointed African-American coach and his high school team on their first season as a racially integrated unit.",
                BannerURL = "https://m.media-amazon.com/images/M/MV5BYThkMzgxNjEtMzFiOC00MTI0LWI5MDItNDVmYjA4NzY5MDQ2L2ltYWdlL2ltYWdlXkEyXkFqcGdeQXVyMTQxNzMzNDI@._V1_.jpg",
                ImageURL = "https://m.media-amazon.com/images/M/MV5BYThkMzgxNjEtMzFiOC00MTI0LWI5MDItNDVmYjA4NzY5MDQ2L2ltYWdlL2ltYWdlXkEyXkFqcGdeQXVyMTQxNzMzNDI@._V1_UX182_CR0,0,182,268_AL_.jpg",
                TrailerURL = "https://www.youtube.com/embed/35MvdHBWjwU",
                ContentRating = "PG",
                Description = "Suburban Virginia schools have been segregated for generations. One Black and one White high school are closed and the students sent to T.C. Williams High School under federal mandate to integrate. The year is seen through the eyes of the football team where the man hired to coach the Black school is made head coach over the highly successful white coach. Based on the actual events of 1971, the team becomes the unifying symbol for the community as the boys and the adults learn to depend on and trust each other.",
                Year = 2000,
                Title = "Remember the Titans",
                MovieLength = 113

            },
            new Movie
            {
                Id = "tt0190590",
                IMDBstar = 7.7,
                Plot = "In the deep south during the 1930s, three escaped convicts search for hidden treasure while a relentless lawman pursues them.",
                BannerURL = "https://m.media-amazon.com/images/M/MV5BMjZkOTdmMWItOTkyNy00MDdjLTlhNTQtYzU3MzdhZjA0ZDEyXkEyXkFqcGdeQXVyMTMxODk2OTU@._V1_.jpg",
                ImageURL = "https://m.media-amazon.com/images/M/MV5BMjZkOTdmMWItOTkyNy00MDdjLTlhNTQtYzU3MzdhZjA0ZDEyXkEyXkFqcGdeQXVyMTMxODk2OTU@._V1_UX182_CR0,0,182,268_AL_.jpg",
                TrailerURL = "https://www.youtube.com/embed/eW9Xo2HtlJI",
                ContentRating = "PG-13",
                Description = "Loosely based on Homer's \"Odyssey,\" the movie deals with the picaresque adventures of Ulysses Everett McGill and his companions Delmar and Pete in 1930s Mississipi. Sprung from a chain gang and trying to reach Everett's home to recover the buried loot of a bank heist they are confronted by a series of strange characters--among them sirens, a cyclops, bank robber George \"Baby Face\" Nelson (very annoyed by that nickname), a campaigning governor and his opponent, a KKK lynch mob, and a blind prophet who warns the trio that \"the treasure you seek shall not be the treasure you find.\"",
                Year = 2000,
                Title = "O Brother, Where Art Thou?",
                MovieLength = 107
            });
            modelBuilder.Entity<Category>().HasData(
                new { Id = 1, MovieCategory = MovieCategoryOptions.Adventure },
                new { Id = 2, MovieCategory = MovieCategoryOptions.Family },
                new { Id = 3, MovieCategory = MovieCategoryOptions.Fantasy },
                new { Id = 4, MovieCategory = MovieCategoryOptions.Crime },
                new { Id = 5, MovieCategory = MovieCategoryOptions.Drama },
                new { Id = 6, MovieCategory = MovieCategoryOptions.Comedy },
                new { Id = 7, MovieCategory = MovieCategoryOptions.SciFi },
                new { Id = 8, MovieCategory = MovieCategoryOptions.Sport },
                new { Id = 9, MovieCategory = MovieCategoryOptions.Action },
                new { Id = 10, MovieCategory = MovieCategoryOptions.Thriller },
                new { Id = 11, MovieCategory = MovieCategoryOptions.Mystery },
                new { Id = 12, MovieCategory = MovieCategoryOptions.Western },
                new { Id = 13, MovieCategory = MovieCategoryOptions.Romance },
                new { Id = 14, MovieCategory = MovieCategoryOptions.Biography },
                new { Id = 15, MovieCategory = MovieCategoryOptions.Horror },
                new { Id = 16, MovieCategory = MovieCategoryOptions.War },
                new { Id = 17, MovieCategory = MovieCategoryOptions.Musical },
                new { Id = 18, MovieCategory = MovieCategoryOptions.History },
                new { Id = 19, MovieCategory = MovieCategoryOptions.Music },
                new { Id = 20, MovieCategory = MovieCategoryOptions.Documentary },
                new { Id = 21, MovieCategory = MovieCategoryOptions.Short },
                new { Id = 22, MovieCategory = MovieCategoryOptions.TalkShow },
                new { Id = 23, MovieCategory = MovieCategoryOptions.GameShow },
                new { Id = 24, MovieCategory = MovieCategoryOptions.RealityTV },
                new { Id = 25, MovieCategory = MovieCategoryOptions.News },
                new { Id = 26, MovieCategory = MovieCategoryOptions.Adult }
                );


            modelBuilder.Entity<MovieCategory>().HasData(
              new MovieCategory { MovieId = "tt0218839", CategoryId = 1 }, // Assuming CategoryId 1 exists
              new MovieCategory { MovieId = "tt0204946", CategoryId = 6 },
              new MovieCategory { MovieId = "tt0204946", CategoryId = 8 },
              new MovieCategory { MovieId = "tt0204946", CategoryId = 13 },
              new MovieCategory { MovieId = "tt0181875", CategoryId = 1 },
              new MovieCategory { MovieId = "tt0181875", CategoryId = 5 },
              new MovieCategory { MovieId = "tt0181875", CategoryId = 6 },
              new MovieCategory { MovieId = "tt0181875", CategoryId = 19 },
              new MovieCategory { MovieId = "tt0187078", CategoryId = 4 },
              new MovieCategory { MovieId = "tt0187078", CategoryId = 9 },
              new MovieCategory { MovieId = "tt0187078", CategoryId = 10 },
              new MovieCategory { MovieId = "tt0175142", CategoryId = 6 },
              new MovieCategory { MovieId = "tt0210945", CategoryId = 5 },
              new MovieCategory { MovieId = "tt0210945", CategoryId = 8 },
              new MovieCategory { MovieId = "tt0210945", CategoryId = 14 },
              new MovieCategory { MovieId = "tt0190590", CategoryId = 1 },
              new MovieCategory { MovieId = "tt0190590", CategoryId = 4 },
              new MovieCategory { MovieId = "tt0190590", CategoryId = 6 },
              new MovieCategory { MovieId = "tt0190590", CategoryId = 19 }
            );

            modelBuilder.Entity<MovieReview>().HasData(
                new MovieReview
                {
                    Id = 1,
                    Title = "Flawless",
                    UserId = 1,
                    MovieId = "tt0218839",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Phasellus tincidunt molestie massa quis vulputate. Pellentesque mollis egestas lectus, in tempus lorem scelerisque vitae. Donec fermentum quam nec ligula sollicitudin, quis tincidunt orci laoreet. Donec ut tincidunt tortor. Integer eget neque pellentesque risus varius gravida ac sit amet augue. Morbi tristique risus nec augue venenatis, id viverra dolor lobortis. Curabitur malesuada enim libero, nec tincidunt sem varius at. Proin id auctor magna, in pellentesque quam. In hac habitasse platea dictumst. Donec suscipit rutrum risus. Maecenas tristique lorem et nisl ullamcorper, at iaculis nisl laoreet. Etiam sed gravida felis, quis fringilla nisi. Maecenas in urna dolor. Nullam tincidunt varius vestibulum.",
                    Star = 10,
                    Created = new DateTime(2024, 6, 1),
                    IsDeleted = false,
                }
            );

            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, Name = "Hüsnü Cemre", Email = "husnu.cemre@gmail.com", Password = "123Abc.", NickName = "trc10", BirthDate = new DateTime(1992, 12, 14) }
            );
        }

    }
}
