using DAL;
using Entities;
using Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public class CategoriesService : ICategoriesService
    {
        private ICategoriesRepository _catRepo;

        public CategoriesService(ICategoriesRepository categoriesRepository)
        {
            _catRepo = categoriesRepository;
        }
        public async Task<Category> GetCategory(DBEnums.MovieCategoryOptions category)
        {
            return await _catRepo.GetCategory(category);
        }
    }
}
