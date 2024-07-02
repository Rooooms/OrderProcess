using OrderProcess.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderProcess.Core.Interfaces.Repositories
{
    public interface ICategoryGroupRepository
    {
        Task<List<categorygroup>> GetAll();

        Task<categorygroup> GetById(Guid id);

        Task<categorygroup> GetByGroupno(int groupno);

        void Add(categorygroup categorygroup);

        void Delete (categorygroup categorygroup);

        Task<int> SaveChangesAsync();
    }
}
