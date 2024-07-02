using OrderProcess.Core.Models.Requests;
using OrderProcess.Core.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderProcess.Core.Interfaces.Services
{
    public interface IProductsService
    {
        Task<List<ProductsReponse>> GetAll();

        Task<ProductsReponse> GetById(Guid id);

        Task<ProductsReponse> Create(ProductsRequest request);

        Task<ProductsReponse> Update(Guid id, ProductsRequest request);

        Task<bool> Delete(Guid id);

    }
}
