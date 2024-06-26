using Mapster;
using Microsoft.EntityFrameworkCore.Infrastructure;
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
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _order;
        private readonly IProductRepository _product;
        private readonly ICustomerRepository _customer;

        public OrderService(IOrderRepository order,
                            IProductRepository product,
                            ICustomerRepository customer)
        {
            _order = order;
            _product = product;
            _customer = customer;
        }

        public async Task<List<OrderResponse>> Create(OrderRequest request)
        {
            var customer = await _customer.GetByCustKey(request.CustName);
            if (customer == null)
            {
                throw new Exception("No Customer Found");
            }

            var orderlist = new List<OrderEntities>();

            foreach (var productNo in request.ProdNo)
            {

                int counter = 0;

                var product = await _product.GetByProdNo(productNo);

                if (product == null)
                {
                    throw new Exception("No Product Found");
                }

                var order = new OrderEntities
                {
                    Id = Guid.NewGuid(),  // Ensure a unique ID for each order
                    CustKey = request.CustKey,
                    CustName = request.CustName,
                    poNo = request.poNo,
                    poDate = request.poDate,
                    Remarks = request.Remarks,
                    ProdNo = productNo,
                    ProdDescription = product.ProdDescription,
                    Packing = product.Packing,
                    Products = product,
                    ProductId = product.Id,
                    customer = customer,
                    CustomerId = customer.Id,
                    OrderCS = request.OrderCS[counter],
                    price = request.price[counter],
                    basePrice = request.basePrice[counter],
                };

                counter++;

                orderlist.Add(order);
            }

             _order.Add(orderlist);
            await _order.SaveChangesAsync();

            var orderlistDto = orderlist.Adapt<List<OrderResponse>>();

            return orderlistDto;
        }

        public async Task<bool> Delete(Guid id)
        {
            var order = await _order.GetById(id);
            if(order == null) return false;

            _order.Delete(order);
            await _order.SaveChangesAsync();
            return true;
        }

        public async Task<List<OrderResponse>> GetAll()
        {
            var order = await _order.GetAll();

            var orderDto = order.Adapt<List<OrderResponse>>();

            return orderDto;
        }

        public async Task<OrderResponse> GetById(Guid id)
        {
            var order = await _order.GetById(id);
            if (order == null) throw new Exception("No Order Found");

            var orderDto = order.Adapt<OrderResponse>();
            return orderDto;
        }

        public async Task<List<OrderResponse>>GetOrderByPoNo(int poNo)
        {
            var order = await _order.GetBypoNo(poNo);

            if (order == null) throw new Exception("No Purchase Order Found");

            var orderDto = order.Adapt<List<OrderResponse>>();

            return orderDto;
        }

        //public async Task<OrderResponse> Update(Guid id, OrderRequest request)
        //{
        //    var order = await _
        //}
    }
}
