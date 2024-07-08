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
    public class DealCodeRepository : IDealCodeRepository
    {
        private readonly AppDbContext _context;

        public DealCodeRepository(AppDbContext context)
        {
            _context = context;
        }

        public void Add(DealCodes dealcodes)
        {
            _context.DealCodes.Add(dealcodes);
        }

        public void Delete(DealCodes dealcodes)
        {
            _context.DealCodes.Remove(dealcodes);
        }

        public Task<List<DealCodes>> GetAll()
        {
            return _context.DealCodes.OrderBy(p=>p.DealStart).ToListAsync();
        }

        public Task<DealCodes> GetByDesc(string desc)
        {
            return _context.DealCodes.FirstOrDefaultAsync(p=>p.DealDesc == desc);
        }
        public Task<DealCodes> GetByDealcode(int dealcode)
        {
            return _context.DealCodes.FirstOrDefaultAsync(p => p.Dealcode == dealcode);
        }


        public Task<DealCodes> GetById(Guid id)
        {
            return _context.DealCodes.FirstOrDefaultAsync(p => p.Id == id);
        }

        public Task<int> SaveChangesAsync()
        {
            return _context.SaveChangesAsync();   
        }
    }
}
