using OrderProcess.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderProcess.Core.Interfaces.Repositories
{
    public interface ICategoryRepository
    {
        Task<List<Category>> GetAll();

        Task<Category> GetById(Guid id);

        Task<Category> GetByCatcode(int catcode);

        Task<List<Category>> GetByGroup(int groupno);

        void Add(Category category);

        void Delete(Category category);

        Task<int> SaveChangesAsync();
    }
}
