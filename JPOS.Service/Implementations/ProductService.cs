using AutoMapper;
using JPOS.Model;
using JPOS.Model.Entities;
using JPOS.Model.Models;
using JPOS.Service.Interfaces;
using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JPOS.Service.Implementations
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProductService(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<bool?> CreateProduct(ProductModel model, List<ProductMaterialModel> materialofproduct)
        {
           if (model == null)
            {
                return false;
            }
            await _unitOfWork.Products.InsertAsync(_mapper.Map<Product>(model));
            var GetIdProduct = await _unitOfWork.Products.GetLastproduct();
            for (int i = 0; i < materialofproduct.Count(); i++)
            {
                materialofproduct[i].ProductID = GetIdProduct.ProductID;
                await _unitOfWork.ProductMaterials.InsertAsync(_mapper.Map<ProductMaterial>(materialofproduct[i]));
            }

            return true;
        }

        public async Task<int> DuplicateProduct(int id)
        {
            var product = await _unitOfWork.Products.GetByIdAsync(id);
            var listProductMaterial = await _unitOfWork.ProductMaterials.GetMaterialsByProductID(product.ProductID);
            product.ProductID = 0;
            product.Status = "Pending";
            await _unitOfWork.Products.InsertAsync(product);
            var LastProduct = await _unitOfWork.Products.GetLastproduct();          
            for (int i = 0; i < listProductMaterial.Count; i++)
            {
                listProductMaterial[i].ProductID = LastProduct.ProductID;
                listProductMaterial[i].ProductMaterialID = 0;
                await _unitOfWork.ProductMaterials.InsertAsync(listProductMaterial[i]);
            }
            return LastProduct.ProductID;
        }

        public async Task<List<Product>?> GetAllProduct()
        {
            return await _unitOfWork.Products.GetAllAsync();
        }

        public async Task<Product?> GetProductByID(int? id)
        {
            if (id != null) {
                return await _unitOfWork.Products.GetByIdAsync(id);
            }
           return null;
        }

        public async Task<Product?> GetProductByRequest(string key)
        {
            if (key == null)
            {
                return null;
            }
            return await _unitOfWork.Products.GetproductByRequest(key);
        }

        public async Task<ProductDetailModel?> GetProductDetail(int productId)
        {
            var product = await _unitOfWork.Products.GetProductWithMaterialsAsync(productId);
            if (product == null)
            {
                return null;
            }

            var productDetailModel = new ProductDetailModel
            {
                ProductID = productId,
                ProductName = product.ProductName,
                Description = product.Description,
                Image = product.Image,
                Status = product.Status,
                MaterialPrice = product.PriceMaterial,
                ProcessPrice = product.ProcessPrice,
                DesignPrice = product.PriceDesign,
                CategoryName = product.Category?.CatName,
                Materials = product.ProductMaterial.Select(pm => new ProdMatModel
                {
                    MaterialID = pm.MaterialID,
                    MaterialName = pm.Material?.Name,
                    Quantity = pm.Quantity,
                    Price = pm.Price,
                }).ToList()
            };

            return productDetailModel;
        }

        public async Task<bool?> UpdateProduct(ProductModel model)
        {
           if(model != null)
            {
                await _unitOfWork.Products.UpdateAsync(_mapper.Map<Product>(model));
                await _unitOfWork.CompleteAsync();
                return true;
            }
           return false;
            
        }
    }
}
