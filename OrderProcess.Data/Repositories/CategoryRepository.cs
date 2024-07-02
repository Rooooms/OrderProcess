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
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext _context;

        public CategoryRepository(AppDbContext context)
        {
            _context = context;
        }

        public void Add(Category category)
        {
            _context.Categories.Add(category);
        }

        public void Delete(Category category)
        {
            _context.Categories.Remove(category);
        }

        public Task<List<Category>> GetAll()
        {
            return _context.Categories.OrderBy(p=>p.CategoryCode).ToListAsync();
        }

        public Task<Category> GetByCatcode(int catcode)
        {
            return _context.Categories.FirstOrDefaultAsync(p => p.CategoryCode == catcode);
        }

        public Task<List<Category>> GetByGroup(int groupno)
        {
            return _context.Categories.Where(p=>p.groupno == groupno).ToListAsync();
        }

        public Task<Category> GetById(Guid id)
        {
            return _context.Categories.FirstOrDefaultAsync(p => p.Id == id);
        }

        public Task<int> SaveChangesAsync()
        {
            return _context.SaveChangesAsync();
        }
    }
}
