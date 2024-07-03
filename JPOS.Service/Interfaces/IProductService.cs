using JPOS.Model.Entities;
using JPOS.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JPOS.Service.Interfaces
{
    public interface IProductService
    {
        public Task<Product?> GetProductByID(int? id);   
        public Task<Product?> GetProductByRequest(string key);
        public Task<List<Product>?> GetAllProduct();
        public Task<int> DuplicateProduct(int id);
        public Task<bool?> UpdateProduct(ProductModel model);
        public Task<ProductDetailModel?> GetProductDetail(int id);
        public Task<bool?> CreateProduct(ProductModel model, List<ProductMaterialModel> materialofproduct);
    }
}
