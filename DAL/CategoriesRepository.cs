using Entities;
using Entities.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Entities.Enums.DBEnums;

namespace DAL
{
    public class CategoriesRepository: ICategoriesRepository
    {
        private readonly AppDbContext _db;

        public CategoriesRepository(AppDbContext context)
        {
            _db = context;
        }

        public async Task<Category> GetCategory(MovieCategoryOptions categoryName)
        {
            return await _db.Categories.FirstOrDefaultAsync(m => m.MovieCategory == categoryName);
        }
    }
}
