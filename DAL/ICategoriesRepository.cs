using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Entities.Enums.DBEnums;

namespace DAL
{
    public interface ICategoriesRepository
    {
        public Task<Category> GetCategory(MovieCategoryOptions categoryName);
    }
}
