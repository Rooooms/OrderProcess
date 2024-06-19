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
    public class CustomerRepository : ICustomerRepository
    {
        private readonly AppDbContext _context;

        public CustomerRepository(AppDbContext context)
        {
            _context=context;
        }

        public void Add(Customer customer)
        {
           _context.Customers.Add(customer);
        }

        public void Delete(Customer customer)
        {
            _context.Customers.Remove(customer);
        }

        public Task<List<Customer>> GetAll()
        {
            return _context.Customers.OrderBy(p=>p.CustName).ToListAsync();
        }

        public Task<Customer> GetById(Guid id)
        {
            return _context.Customers.FirstOrDefaultAsync(p => p.Id == id);
        }

        public Task<Customer>GetByCustKey(string custName)
        {
            return _context.Customers.FirstOrDefaultAsync(p=>p.CustName == custName);
        }

        public Task<int> SaveChangesAysnc()
        {
            return _context.SaveChangesAsync();
        }
    }
}
