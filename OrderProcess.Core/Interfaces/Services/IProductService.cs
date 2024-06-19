using OrderProcess.Core.Models.Requests;
using OrderProcess.Core.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderProcess.Core.Interfaces.Services
{
    public interface IProductService
    {
        Task<List<ProductResponse>> GetAll();
        Task<ProductResponse> GetById(Guid id);

        Task<ProductResponse>Create(ProductRequest request);

        Task<ProductResponse> Update(Guid id ,ProductRequest request);

        Task<bool> Delete(Guid id);
    }
}
