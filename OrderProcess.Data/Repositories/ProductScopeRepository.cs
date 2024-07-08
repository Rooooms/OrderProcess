using Microsoft.EntityFrameworkCore;
using OrderProcess.Core.Entities;
using OrderProcess.Core.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderProcess.Data.Repositories
{
    public class ProductScopeRepository : IProductScopeRepository
    {
        private readonly AppDbContext _context;

        public ProductScopeRepository(AppDbContext context)
        {
            _context = context;
        }

        public void Add(DealProductScope customerScope)
        {
            _context.ProductScope.Add(customerScope);
        }

        public void Delete(DealProductScope customerScope)
        {
            _context.ProductScope.Remove(customerScope);
        }

        public Task<List<DealProductScope>> GetAll()
        {
            return _context.ProductScope.ToListAsync();
        }

        public Task<DealProductScope> GetByDealCode(int dealCode)
        {
            return _context.ProductScope.FirstOrDefaultAsync(p=>p.DealCode == dealCode);
        }

        public Task<DealProductScope> GetById(Guid id)
        {
            return _context.ProductScope.FirstOrDefaultAsync(p => p.Id == id);
        }

        public Task<int> SaveChangesAsync()
        {
            return _context.SaveChangesAsync();
        }
    }
}
