using Microsoft.EntityFrameworkCore;
using OrderProcess.Core.Entities;
using OrderProcess.Core.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderProcess.Data.Repositories
{
    public class CategoryGroupRepository : ICategoryGroupRepository
    {
        private readonly AppDbContext _context;

        public CategoryGroupRepository(AppDbContext context)
        {
            _context = context;
        }

        public void Add(categorygroup categorygroup)
        {
           _context.CategoryGroups.Add(categorygroup);
        }

        public void Delete(categorygroup categorygroup)
        {
            _context.CategoryGroups.Remove(categorygroup);
        }

        public Task<List<categorygroup>> GetAll()
        {
            return _context.CategoryGroups.OrderBy(p=>p.groupno).ToListAsync();
        }

        public Task<categorygroup> GetByGroupno(int groupno)
        {
            return _context.CategoryGroups.FirstOrDefaultAsync(p => p.groupno == groupno);
        }

        public Task<categorygroup> GetById(Guid id)
        {
            return _context.CategoryGroups.FirstOrDefaultAsync(p=>p.Id==id);
        }

        public Task<int> SaveChangesAsync()
        {
           return _context.SaveChangesAsync();
        }
    }
}
