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
    public class ProductsRepository : IProductsRepository
    {
        private readonly AppDbContext _context;

        public ProductsRepository(AppDbContext context)
        {
            _context = context;
        }

        public void Add(Products product)
        {
            _context.RamProduct.Add(product);
        }

        public void Delete(Products product)
        {
            _context.RamProduct.Remove(product);
        }

        public Task<List<Products>> GetAll()
        {
            return _context.RamProduct.OrderBy(p=>p.prodno).ToListAsync();
        }

        public Task<List<Products>> GetByCategory(int catCode)
        {
            return _context.RamProduct.Where(p=>p.catcode == catCode).ToListAsync();
        }

        public Task<Products> GetById(Guid id)
        {
            return _context.RamProduct.FirstOrDefaultAsync(p=>p.Id == id);
        }

        public Task<Products> GetByProdno(int prodno)
        {
            return _context.RamProduct.FirstOrDefaultAsync(p => p.prodno == prodno);
        }

        public Task<int> SaveChangesAsync()
        {
            return _context.SaveChangesAsync();
        }
    }
}
