using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class MovieReview
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool IsDeleted { get; set; }
        public int UserId { get; set; }
        public string MovieId { get; set; }
        public string Description { get; set; }
        public int Star { get; set; }
        public DateTime Created { get; set; }
        public virtual User User { get; set; }
        public virtual Movie Movie { get; set; }
    }
}
