using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Entities.Enums.DBEnums;

namespace Entities
{
    public class Category
    {
        public int Id { get; set; }
        public MovieCategoryOptions MovieCategory { get; set; }
        public virtual ICollection<MovieCategory> MovieCategories { get; set;}
    }
}
