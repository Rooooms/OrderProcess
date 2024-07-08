using OrderProcess.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderProcess.Core.Interfaces.Repositories
{
    public interface IProductScopeRepository
    {
        Task<List<DealProductScope>> GetAll();

        Task<DealProductScope> GetByDealCode(int dealCode);

        void Add(DealProductScope customerScope);

        void Delete(DealProductScope customerScope);

        Task<int> SaveChangesAsync();
        Task<DealProductScope> GetById(Guid id);
    }
}
