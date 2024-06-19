using OrderProcess.Core.Models.Requests;
using OrderProcess.Core.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderProcess.Core.Interfaces.Services
{
    public interface ICustomerService
    {
        Task<List<CustomerResponse>> GetAll();

        Task<CustomerResponse> GetById(Guid id);

        Task<CustomerResponse> Create(CustomerRequest request);

        Task<CustomerResponse> Update(Guid id, CustomerRequest request);

        Task<bool> Delete(Guid id);
    }
}
