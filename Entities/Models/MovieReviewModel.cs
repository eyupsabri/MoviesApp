using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
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
