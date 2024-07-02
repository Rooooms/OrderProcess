using OrderProcess.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderProcess.Core.Interfaces.Repositories
{
    public interface IProductsRepository
    {
        Task<List<Products>>GetAll();

        Task<List<Products>> GetByCategory(int catCode);

        Task<Products> GetById (Guid id);

        Task<Products>GetByProdno (int prodno);

        void Add(Products product);

        void Delete(Products product);

        Task<int> SaveChangesAsync();
    }
}
