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
    public class CategoryScopeRepository : ICustomerScopeRepository
    {
        private readonly AppDbContext _context;

        public CategoryScopeRepository(AppDbContext context)
        {
            _context = context;
        }

        public void Add(DealCustomerScope customerScope)
        {
            _context.DealCodeCustomerScope.Add(customerScope);
        }

        public void Delete(DealCustomerScope customerScope)
        {
            _context.DealCodeCustomerScope.Remove(customerScope);
        }

        public Task<List<DealCustomerScope>> GetAll()
        {
            return _context.DealCodeCustomerScope.ToListAsync();
        }

        public Task<DealCustomerScope> GetById(Guid id)
        {
            return _context.DealCodeCustomerScope.FirstOrDefaultAsync(p => p.Id == id);
        }
        public Task<DealCustomerScope> GetByDealCode(int dealCode)
        {
            return _context.DealCodeCustomerScope.FirstOrDefaultAsync(p => p.DealCode == dealCode);
        }

        public Task<int> SaveChangesAsync()
        {
            return _context.SaveChangesAsync();
        }
    }
}
