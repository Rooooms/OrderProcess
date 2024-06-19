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
    public class ProductService : IProductService
    {
        private readonly IProductRepository _product;
        public ProductService(IProductRepository product)
        {
            _product = product;
        }

        public async Task<ProductResponse> Create(ProductRequest request)
        {
            var product = request.Adapt<Product>();

            _product.Add(product);

            await _product.SaveChangesAsync();

            var productDto = product.Adapt<ProductResponse>();

            return productDto;
        }

        public async Task<bool> Delete(Guid id)
        {
            var product = await _product.GetById(id);
            if (product == null) return false;

            _product.Delete(product);

            await _product.SaveChangesAsync();

            return true;
        }

        public async Task<List<ProductResponse>> GetAll()
        {
            var product = await _product.GetAll();

            var productDto = product.Adapt<List<ProductResponse>>();

            return productDto;
        }

        public async Task<ProductResponse> GetById(Guid id)
        {
            var product = await _product.GetById(id);

            if (product == null) throw new Exception("No Product Found");

            var productDto = product.Adapt<ProductResponse>();
            return productDto;
        }

        public async Task<ProductResponse> Update(Guid id, ProductRequest request)
        {
            var product = await _product.GetById(id);

            if (product == null) throw new Exception("No Product found");

            request.Adapt(product);

            await _product.SaveChangesAsync();

            return product.Adapt<ProductResponse>();    


        }
    }
}
