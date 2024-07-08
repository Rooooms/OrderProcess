using OrderProcess.Core.Models.Requests;
using OrderProcess.Core.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderProcess.Core.Interfaces.Services
{
    public interface ICustomerScopeService
    {
        Task<List<CustomerScopeResponse>>GetAll();

        Task<CustomerScopeResponse>Create(CustomerScopeRequest request);

        Task<CustomerScopeResponse>Update(Guid id, CustomerScopeRequest request);

        Task<bool> Delete(Guid id);
    }
}
