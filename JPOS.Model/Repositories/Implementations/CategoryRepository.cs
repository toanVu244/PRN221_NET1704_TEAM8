using JPOS.Model.Entities;
using JPOS.Model.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JPOS.Model.Repositories.Implementations
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        private readonly JPOSDbContext _context;

        public CategoryRepository(JPOSDbContext context):base(context) 
        {
            _context = context;
        }

        public async Task<Category> GetCategoryByID(int cateId)
        {
            return await _context.Categories.FirstOrDefaultAsync(c => c.CatID == cateId);
        }
    }
}
