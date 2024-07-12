using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class MovieDTO
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
        public string Plot { get; set; }
        public ICollection<string> MovieCategories { get; set; }
    }
}
