using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Entities.Enums.DBEnums;

namespace Business.Services
{
    public interface ICategoriesService
    {
        public Task<Category> GetCategory(MovieCategoryOptions category);
    }
}
