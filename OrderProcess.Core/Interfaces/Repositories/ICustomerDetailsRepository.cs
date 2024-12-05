using OrderProcess.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderProcess.Core.Interfaces.Repositories
{
    public interface ICustomerDetailsRepository
    {
        Task<List<CustomerDetails>> GetAll();
        Task<CustomerDetails> GetById(Guid id);

        void Add(CustomerDetails customerDetails);

        void Delete(CustomerDetails customerDetails);

        public Task<int> SaveChangesAysnc();
        Task<CustomerDetails> GetByCustKey(string custKey);
        Task<CustomerDetails> GetByCustName(string custName);
    }
}
