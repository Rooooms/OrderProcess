using OrderProcess.Core.Models.Requests;
using OrderProcess.Core.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderProcess.Core.Interfaces.Services
{
    public interface IOrderService
    {
        Task<List<OrderResponse>> GetAll();

        Task<OrderResponse> GetById(Guid id);

        Task<List<OrderResponse>> Create(OrderRequest request);

        //Task<OrderResponse> Update(Guid id, OrderRequest request);

        Task<bool> Delete(Guid id);
        Task<List<OrderResponse>> GetOrderByPoNo(int poNo);
    }
}
