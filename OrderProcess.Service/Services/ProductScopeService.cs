using Mapster;
using Newtonsoft.Json;
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
    public class ProductScopeService : IProductScopeService
    {
        private readonly IProductScopeRepository _productScope;
        private readonly IProductsRepository _products;
        private readonly IDealCodeRepository _dealCode;
        public ProductScopeService(IDealCodeRepository dealCode, IProductScopeRepository productScope, IProductsRepository products)
        {

            _dealCode = dealCode;
            _productScope = productScope;
            _products = products;

        }

        public async Task<ProductScopeResponse> Create(ProductScopeRequest request)
        {
            var dealcode = await _dealCode.GetByDealcode(request.DealCode);

            if (dealcode == null) throw new Exception("No Dealcode Found");

            var productScope = request.Adapt<DealProductScope>();

            var listProduct = new List<ProductScope>();

            var prod = new ProductScope();

            foreach (var item in request.productprofile)
            {
                var product = await _products.GetByProdno(item.prodno);
                if (product == null) throw new Exception("No Product Found");

                prod.prodno = item.prodno;
                prod.proddesc = product.proddesc;
                prod.StartDate = item.StartDate;
                prod.EndDate = item.EndDate;

                if (prod.EndDate < DateOnly.FromDateTime(DateTime.Now))
                {
                    prod.CanAvail = Avail.False;
                }
                else
                {
                    prod.CanAvail = Avail.True;
                }

                listProduct.Add(prod);
            }

            productScope.DealDesc = dealcode.DealDesc;
            productScope.ProductScopeJson = JsonConvert.SerializeObject(listProduct);

            _productScope.Add(productScope);

            await _productScope.SaveChangesAsync();

            var productScopeDto = productScope.Adapt<ProductScopeResponse>();

            return productScopeDto;
        }

        public async Task<bool> Delete(Guid id)
        {
            var productScope = await _productScope.GetById(id);

            if (productScope == null) return false;

            _productScope.Delete(productScope);

            await _productScope.SaveChangesAsync();

            return true;
        }

        public async Task<List<ProductScopeResponse>> GetAll()
        {
            var productScope = await _productScope.GetAll();

            var productScopedto = productScope.Adapt<List<ProductScopeResponse>>();

            return productScopedto;
        }

        public async Task<ProductScopeResponse> Update(Guid id, ProductScopeRequest request)
        {
            var productScope = await _productScope.GetById(id);

            if (productScope == null) throw new Exception("No Customer Scope Found in Deal");

            request.Adapt(productScope);

            var listcustomer = new List<ProductScope>();

            var cust = new ProductScope();

            foreach (var item in request.productprofile)
            {
                var customer = await _products.GetByProdno(item.prodno);
                if (customer == null) throw new Exception("No Customer Found");

                cust.prodno = item.prodno;
                cust.proddesc = customer.proddesc;
                cust.StartDate = item.StartDate;
                cust.EndDate = item.EndDate;

                if (cust.EndDate < DateOnly.FromDateTime(DateTime.Now))
                {
                    cust.CanAvail = Avail.False;
                }
                else
                {
                    cust.CanAvail = Avail.True;
                }

                listcustomer.Add(cust);
            }


            productScope.ProductScopeJson = JsonConvert.SerializeObject(listcustomer);

            await _productScope.SaveChangesAsync();

            return productScope.Adapt<ProductScopeResponse>();
        }
    }
}
