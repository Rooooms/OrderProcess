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
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customer;

        public CustomerService(ICustomerRepository customer)
        {
            _customer = customer;
        }

        public async Task<CustomerResponse> Create(CustomerRequest request)
        {
            var customer = request.Adapt<Customer>();

            _customer.Add(customer);

            await _customer.SaveChangesAysnc();

            var customerDto = customer.Adapt<CustomerResponse>();

            return customerDto;
        }

        public async Task<bool> Delete(Guid id)
        {
            var customer = await _customer.GetById(id);

            if (customer == null) return false;

            _customer.Delete(customer);

            await _customer.SaveChangesAysnc();
            return true;
           

            
        }

        public async Task<List<CustomerResponse>> GetAll()
        {
            var customer = await _customer.GetAll();

            var customerDto = customer.Adapt<List<CustomerResponse>>();

            return customerDto;
        }

        public async Task<CustomerResponse> GetById(Guid id)
        {
            var customer = await _customer.GetById(id);

            var customerDto = customer.Adapt<CustomerResponse>();
            return customerDto;
        }

        public async Task<CustomerResponse> Update(Guid id, CustomerRequest request)
        {
            var customer = await _customer.GetById(id);

            if (customer == null) throw new Exception("No Customer Found");

            request.Adapt(customer);

            await _customer.SaveChangesAysnc();

            return customer.Adapt<CustomerResponse>();
        }
    }
}
