using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class MovieReviewDTO
    {
        public string Title { get; set; }
        public string UserName { get; set; }
        public string? UserNickName { get; set; }

        public string MovieId { get; set; }
        public string Description { get; set; }
        public int Star { get; set; }
        public DateTime Created { get; set; }
    }
}
