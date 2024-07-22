namespace MoviesAppUser.Models
{
    public class MovieReviewModel
    {

        public string Title { get; set; }
        public int? UserId { get; set; }
        public string MovieId { get; set; }
        public string Description { get; set; }
        public int Star { get; set; }
        public DateTime Created { get; set; }

    }
}
