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
    public class SalesmanRepository : ISalesmanRepository
    {
        private readonly AppDbContext _context;

        public SalesmanRepository(AppDbContext context)
        {
            _context = context;
        }

        public Task<Salesman> GetById(int salesman)
        {
            return _context.Set<Salesman>().FirstOrDefaultAsync(p=>p.salesman == salesman);
        }
    }
}
