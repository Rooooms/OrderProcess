using Mapster;
using OrderProcess.Core.Entities;
using OrderProcess.Core.Interfaces.Repositories;
using OrderProcess.Core.Interfaces.Services;
using OrderProcess.Core.Models.Requests;
using OrderProcess.Core.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderProcess.Service.Services
{
    public  class ProductsService : IProductsService
    {

        private readonly IProductsRepository _products;
        private readonly ICategoryRepository _categories;

        public ProductsService(IProductsRepository products, ICategoryRepository category )
        {
            _categories = category;
            _products = products;
        }

        public async Task<ProductsReponse> Create(ProductsRequest request)
        {
            var category = await _categories.GetByCatcode(request.catcode);
            if (category == null) throw new Exception("No Category Found");

            var product = request.Adapt<Products>();

            product.category = category.CategoryName;
            product.TaxRate = 0.12;
            product.pricewtax = request.basePrice * product.TaxRate;

            _products.Add( product );

            await _products.SaveChangesAsync();

            var productDto = product.Adapt<ProductsReponse>();

            return productDto;  

        }

        public async Task<bool> Delete(Guid id)
        {
            var product = await _products.GetById(id);

            if (product == null) return false;

            _products.Delete( product );

            await _products.SaveChangesAsync();

            return true;
        }

        public async Task<List<ProductsReponse>> GetAll()
        {
            var products = await _products.GetAll();

            var productsdto = products.Adapt<List<ProductsReponse>>();

            return productsdto;
        }

        public async Task<ProductsReponse> GetById(Guid id)
        {
            var product = await _products.GetById(id);

            if (product == null) throw new Exception("No Product Found");

            var productDto = product.Adapt<ProductsReponse>();

            return productDto;
        }

        public async Task<ProductsReponse> Update(Guid id, ProductsRequest request)
        {
            var product = await _products.GetById(id);

            if (product == null) throw new Exception("No Product Found");

            request.Adapt(product);

            var category = await _categories.GetByCatcode(product.catcode);
            if (product == null) throw new Exception("No category Found");

            await _products.SaveChangesAsync();

            return product.Adapt<ProductsReponse>();    
        }
    }
}
