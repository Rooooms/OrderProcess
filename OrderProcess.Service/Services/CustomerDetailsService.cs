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
    public class CustomerDetailsService : ICustomerDetailsService
    {
        private readonly ICustomerDetailsRepository _customerDetails;

        public CustomerDetailsService(ICustomerDetailsRepository customerDetails)
        {
            _customerDetails = customerDetails;
        }

        public async Task<CustomerDetailsResponse> Create(CustomerDetailsRequest request)
        {
            var customerDetails = request.Adapt<CustomerDetails>();

            _customerDetails.Add(customerDetails);

            await _customerDetails.SaveChangesAysnc();

            var customerDetailsDto = customerDetails.Adapt < CustomerDetailsResponse>();

            return customerDetailsDto;
        }

        public async Task<bool> Delete(Guid id)
        {
            var customerDetails = await _customerDetails.GetById(id);

            if (customerDetails == null) return false;

            _customerDetails.Delete(customerDetails);

            await _customerDetails.SaveChangesAysnc();
            return true;



        }


        public async Task<List<CustomerDetailsResponse>> GetAll()
        {
            var customerDetails = await _customerDetails.GetAll();

            var customerDetailsDto = customerDetails.Adapt<List<CustomerDetailsResponse>>();

            return customerDetailsDto;
        }

        public async Task<CustomerDetailsResponse> GetById(Guid id)
        {
            var customerDetails = await _customerDetails.GetById(id);

            var customerDetailsDto = customerDetails.Adapt<CustomerDetailsResponse>();
            return customerDetailsDto;
        }

        public async Task<CustomerDetailsResponse> GetByCustKey(string custkey)
        {
            var customerDetails = await _customerDetails.GetByCustKey(custkey);

            var customerDetailsDto = customerDetails.Adapt<CustomerDetailsResponse>();
            return customerDetailsDto;
        }

        public async Task<CustomerDetailsResponse> Update(Guid id, CustomerDetailsRequest request)
        {
            var customerDetails = await _customerDetails.GetById(id);

            if (customerDetails == null) throw new Exception("No Customer Found");

            request.Adapt(customerDetails);

            await _customerDetails.SaveChangesAysnc();

            return customerDetails.Adapt<CustomerDetailsResponse>();
        }
    }
}
