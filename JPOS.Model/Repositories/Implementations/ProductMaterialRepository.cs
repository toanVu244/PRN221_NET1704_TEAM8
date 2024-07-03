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
    public class ProductMaterialRepository : GenericRepository<ProductMaterial>, IProductMaterialRepository
    {
        private readonly JPOSDbContext _context;

        public ProductMaterialRepository(JPOSDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<ProductMaterial>> GetMaterialsByProductID(int pid)
        {
            return await _context.ProductMaterials.Where(pm=> pm.ProductID ==  pid).ToListAsync();
        }
    }
}
