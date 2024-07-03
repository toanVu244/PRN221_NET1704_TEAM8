using JPOS.Model.Entities;
using JPOS.Model.Repositories.Interfaces;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JPOS.Model.Repositories.Implementations
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        private readonly JPOSDbContext _context;

        public ProductRepository(JPOSDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Product>?> GetAllproduct()
        {
           return await _context.Products.ToListAsync();
        }

        public async Task<Product?> GetLastproduct()
        {
            var lastRequest = await _context.Products
               .OrderByDescending(r => r.ProductID)
               .FirstOrDefaultAsync();
            return lastRequest;
        }

        public async Task<Product?> GetproductByRequest(string key)
        {
            return await _context.Products.FirstOrDefaultAsync(x => x.CreateBy == key);
        }

        public async Task<Product?> GetProductWithMaterialsAsync(int productId)
        {
            return await _context.Products
                .Include(p => p.ProductMaterial)
                .ThenInclude(pm => pm.Material)
                .Include(p => p.Category)
                .FirstOrDefaultAsync(p => p.ProductID == productId);
        }
    }
}
