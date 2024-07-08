using OrderProcess.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderProcess.Core.Interfaces.Repositories
{
    public interface IDealCodeRepository
    {
        Task<List<DealCodes>> GetAll();

        Task<DealCodes> GetById(Guid id);

        Task<DealCodes> GetByDesc(string desc);

        void Add(DealCodes dealcodes);

        void Delete (DealCodes dealcodes);

        Task<int> SaveChangesAsync();
        Task<DealCodes> GetByDealcode(int dealcode);
    }
}
