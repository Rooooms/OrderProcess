using OrderProcess.Core.Models.Requests;
using OrderProcess.Core.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderProcess.Core.Interfaces.Services
{
    public interface ICustomerDetailsService
    {
        Task<List<CustomerDetailsResponse>> GetAll();

        Task<CustomerDetailsResponse> GetById(Guid id);

        Task<CustomerDetailsResponse> Create(CustomerDetailsRequest request);

        Task<CustomerDetailsResponse> Update(Guid id, CustomerDetailsRequest request);

        Task<bool> Delete(Guid id);
        Task<CustomerDetailsResponse> GetByCustKey(string custkey);
    }
}
