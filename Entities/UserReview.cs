﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class UserReview
    {
        public int Id { get; set; }
        public int AuthorId { get; set; }
        public int ReviewedUserId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public double Star { get; set; }
        public DateTime Created { get; set; }
        public virtual User ReviewedUser { get; set; }
        public virtual User Author { get; set; }
    }
}
