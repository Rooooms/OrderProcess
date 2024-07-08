using OrderProcess.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderProcess.Core.Interfaces.Repositories
{
    public interface ICustomerScopeRepository
    {

        Task<List<DealCustomerScope>> GetAll();

        Task<DealCustomerScope> GetByDealCode(int dealCode); 

        void Add(DealCustomerScope customerScope);

        void Delete(DealCustomerScope customerScope);

        Task<int> SaveChangesAsync();
        Task<DealCustomerScope> GetById(Guid id);
    }
}
