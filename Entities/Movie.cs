namespace Entities
{
    public class Movie
    {
        public string Id { get; set; }
        public double IMDBstar { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }
        public string Description { get; set; }
        public string ContentRating { get; set; }
        public string TrailerURL { get; set; }
        public string ImageURL { get; set; }
        public string BannerURL { get; set; }
        public int MovieLength { get; set; }
        public string Plot { get; set; }
        public virtual ICollection<MovieReview>? Reviews { get; set; }
        public virtual ICollection<MovieCategory> MovieCategories { get; set; }
    }
}