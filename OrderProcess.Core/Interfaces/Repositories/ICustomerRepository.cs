using OrderProcess.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderProcess.Core.Interfaces.Repositories
{
    public interface ICustomerRepository
    {
        Task<List<Customer>> GetAll();
        Task<Customer> GetById(Guid id);

        void Add(Customer customer);

        void Delete(Customer customer);

        public Task<int> SaveChangesAysnc();
        Task<Customer> GetByCustKey(string custName);
        Task<Customer> GetByCust(string custName);
    }
}
