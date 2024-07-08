using OrderProcess.Core.Models.Requests;
using OrderProcess.Core.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderProcess.Core.Interfaces.Services
{
    public interface IProductScopeService
    {
        Task<List<ProductScopeResponse>> GetAll();

        Task<ProductScopeResponse> Create(ProductScopeRequest request);

        Task<ProductScopeResponse> Update(Guid id, ProductScopeRequest request);

        Task<bool> Delete(Guid id);
    }
}
