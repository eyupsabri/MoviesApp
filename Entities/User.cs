using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string? NickName { get; set; }
        public DateTime BirthDate { get; set; }

        public virtual ICollection<MovieReview>? MovieReviews { get; set; }
        public virtual ICollection<UserReview>? UserReviews { get; set;}
    }
}
