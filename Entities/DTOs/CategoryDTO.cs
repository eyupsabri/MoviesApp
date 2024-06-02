using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Entities.Enums.DBEnums;

namespace Entities.DTOs
{
    public class CategoryDTO
    {
        public MovieCategoryOptions MovieCategory { get; set; }
    }
}
