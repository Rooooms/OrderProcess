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
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _context;
        public ProductRepository(AppDbContext context)
        {

            _context = context;
        }

        public void Add(Product product)
        {
            _context.Products.Add(product);
        }

        public void Delete(Product product)
        {
            _context.Products.Remove(product);
        }

        public Task<Product>GetByProdNo(int prodNo)
        {
            return _context.Products.FirstOrDefaultAsync(p => p.ProdNo == prodNo);
        }

        public Task<List<Product>> GetAll()
        {
            return _context.Products.OrderBy(p => p.ProdNo).ToListAsync();
        }
        public Task<Product> GetById (Guid id)
        {
            return _context.Products.FirstOrDefaultAsync(p => p.Id == id);
        }

        public Task<int> SaveChangesAsync()
        {
            return _context.SaveChangesAsync();
        }
    }
}
