using Mapster;
using OrderProcess.Core.Entities;
using OrderProcess.Core.Interfaces.Repositories;
using OrderProcess.Core.Interfaces.Services;
using OrderProcess.Core.Models.Requests;
using Newtonsoft.Json;
using OrderProcess.Core.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace OrderProcess.Service.Services
{
    public class CustomerScopeService: ICustomerScopeService
    {
        private readonly ICustomerScopeRepository _customerScope;
        private readonly ICustomerRepository _customer;
        private readonly IDealCodeRepository _dealCode;

        public CustomerScopeService(ICustomerScopeRepository customerScope, ICustomerRepository customer, IDealCodeRepository dealcode)
        {
            _customerScope = customerScope;
            _customer = customer;
            _dealCode = dealcode;
        }

        public async Task<CustomerScopeResponse> Create(CustomerScopeRequest request)
        {
            var dealcode = await _dealCode.GetByDealcode(request.DealCode);

            if (dealcode == null) throw new Exception("No Dealcode Found");

            var customerScope = request.Adapt<DealCustomerScope>();

            var listcustomer = new List<CustomerScope>();

            foreach (var item in request.customerProfile)
            {
                var customer = await _customer.GetByCust(item.CustKey);
                if (customer == null) throw new Exception("No Customer Found");

                var cust = new CustomerScope
                {
                    CustKey = item.CustKey,
                    CustName = customer.CustName,
                    StartDate = item.StartDate,
                    EndDate = item.EndDate
                };

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

            customerScope.DealDesc = dealcode.DealDesc;
            customerScope.CustomerScopeJson = JsonConvert.SerializeObject(listcustomer);

            _customerScope.Add(customerScope);

            await _customerScope.SaveChangesAsync();

            var customerScopeDto = customerScope.Adapt<CustomerScopeResponse>();

            return customerScopeDto;
        }


        public async Task<bool> Delete(Guid id)
        {
            var customerScope = await _customerScope.GetById(id);

            if (customerScope == null) return false;

            _customerScope.Delete(customerScope);

            await _customerScope.SaveChangesAsync();

            return true;
        }

        public async Task<List<CustomerScopeResponse>> GetAll()
        {
            var customerScope = await _customerScope.GetAll();

            var customerScopeDto = customerScope?.Adapt<List<CustomerScopeResponse>>();

            return customerScopeDto;
        }

        public async Task<CustomerScopeResponse> Update(Guid id, CustomerScopeRequest request)
        {
            var customerScope = await _customerScope.GetById(id);

            if (customerScope == null) throw new Exception("No Customer Scope Found in Deal");

            request.Adapt(customerScope);

            var listcustomer = new List<CustomerScope>();

            var cust = new CustomerScope();

            foreach (var item in request.customerProfile)
            {
                var customer = await _customer.GetByCust(item.CustKey);
                if (customer == null) throw new Exception("No Customer Found");

                cust.CustKey = item.CustKey;
                cust.CustName = customer.CustName;
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

            
            customerScope.CustomerScopeJson = JsonConvert.SerializeObject(listcustomer);

            await _customerScope.SaveChangesAsync();

            return customerScope.Adapt<CustomerScopeResponse>();
        }
    }
}
