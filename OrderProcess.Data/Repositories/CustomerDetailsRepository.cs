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
    public class CustomerDetailsRepository : ICustomerDetailsRepository
    {
        private readonly AppDbContext _context;

        public CustomerDetailsRepository(AppDbContext context)
        {
            _context = context;
        }

        public void Add(CustomerDetails customerDetails)
        {
            _context.Details.Add(customerDetails);
        }

        public void Delete(CustomerDetails customerDetails)
        {
            _context.Details.Remove(customerDetails);
        }

        public Task<List<CustomerDetails>> GetAll()
        {
            return _context.Details.OrderBy(p => p.CustName).ToListAsync();
        }

        public Task<CustomerDetails> GetById(Guid id)
        {
            return _context.Details.FirstOrDefaultAsync(p => p.Id == id);
        }

        public Task<CustomerDetails> GetByCustName(string custName)
        {
            return _context.Details.FirstOrDefaultAsync(p => p.CustName == custName);
        }
        public Task<CustomerDetails> GetByCustKey(string custKey)
        {
            return _context.Details.FirstOrDefaultAsync(p => p.CustKey == custKey);
        }

        public Task<int> SaveChangesAysnc()
        {
            return _context.SaveChangesAsync();
        }
    }
}
